using API.Data.DataAccess;
using API.Data.Repository.Interfaces;
using API.Models.Entities;
using Microsoft.EntityFrameworkCore;

using Dapper;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Data.Repository
{
    public class ProductRepository : BaseRepository, IProductRepository
    {
        private readonly AppDbContext _context;
        public ProductRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            var products = _context.Products.Include(x => x.Movements).ToListAsync();
            return await products;
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            var product = _context.Products
                .Include(x => x.Movements)
                .ThenInclude(x => x.Products)
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();

            return await product;
        }

        public async Task<IEnumerable<Product>> GetProductsAvailableAsync()
        {
            return await _context.Products
                .Where(x => x.Available == true)
                .Include(x => x.Movements).ToListAsync();
        }


    }
}

public class BulkInsertExample
{
    private readonly string _connectionString;

    public BulkInsertExample(string connectionString)
    {
        _connectionString = connectionString;
    }

    public async Task InsertDataAsync(List<MyEntity> entities)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            await connection.OpenAsync();

            using (var transaction = connection.BeginTransaction())
            {
                try
                {
                    // 1. Criar tabela temporária
                    var createTempTableSql = @"
                        CREATE TABLE #TempTable (
                            Id INT,
                            Name NVARCHAR(100),
                            Value DECIMAL(18,2)
                        );
                    ";

                    await connection.ExecuteAsync(createTempTableSql, transaction: transaction);

                    // 2. Fazer bulk insert na tabela temporária
                    var bulkInsertSql = @"
                        INSERT INTO #TempTable (Id, Name, Value) 
                        VALUES (@Id, @Name, @Value);
                    ";

                    await connection.ExecuteAsync(bulkInsertSql, entities, transaction: transaction);

                    // 3. Inserir dados em outras tabelas
                    var insertIntoFinalTableSql = @"
                        INSERT INTO FinalTable (Id, Name, Value)
                        SELECT Id, Name, Value
                        FROM #TempTable;
                    ";

                    await connection.ExecuteAsync(insertIntoFinalTableSql, transaction: transaction);

                    // Confirma a transação
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    // Se algo der errado, faz rollback
                    transaction.Rollback();
                    Console.WriteLine($"Erro: {ex.Message}");
                    throw;
                }
            }
        }
    }
}



// Classe de exemplo para os dados que serão inseridos

public class MyEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Value { get; set; }
}