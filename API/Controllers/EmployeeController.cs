using API.Models.DTOs;
using API.Models.Entities;
using API.Service.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IServiceEmployee _service;
        private readonly IMapper _mapper;

        public EmployeeController(IServiceEmployee service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet("get-employee/{id}")]
        public async Task<IActionResult> GetbyId(int id)
        {
            var employee = await _service.GetAsync(id);
            var employeeResponse = _mapper.Map<EmployeeDTO>(employee);

            return Ok(employeeResponse);
        }

        [HttpGet("get-all-employees")]
        public async Task<IActionResult> GetAllAsync()
        {
            var employees = await _service.GetAllAsync();
            return employees.Any() 
                ? Ok(employees)
                : BadRequest("Funcionarios não encontrados!");
        }

        [HttpPost("post-employee")]
        public async Task<IActionResult> Post(EmployeeRequestDTO item)
        {
            if (item == null) return BadRequest("Inserir dados funcionário");


            var employeeNew = _mapper.Map<Employee>(item);
                
            _service.Post(employeeNew);

            return await (_service.SaveChanges())
                ? Created("", employeeNew)
                : BadRequest($"Erro ao cadastrar {item.FullName}");
        }

        [HttpDelete("delete-employee/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var employee = await _service.GetAsync(id);
            if (employee != null)
            {
                _service.Delete(id);
                return Ok($"Funcionário {employee.FullName} excluido com sucesso");
            }

            return BadRequest("Produto não encontrado");
        }


        [HttpPut("put-employee/")]
        public async Task<IActionResult> Put(EmployeePutDTO employeePut)
        {
            var employeeBase = await _service.GetAsync(employeePut.RegistrationNumber);
            if (employeeBase == null || employeePut.RegistrationNumber <= 0) return BadRequest("Funcionario não encontrado");

            var employeeAtt = _mapper.Map(employeePut, employeeBase);
            employeeAtt.DateLastModification = DateTime.Now;

            _service.Put(employeeAtt);

            return await (_service.SaveChanges())
                ? Ok()
                : BadRequest($"Erro ao cadastrar {employeePut.FullName}");
        }
    }
}
