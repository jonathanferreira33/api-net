using API.Models.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace API.Map
{
    public class ProductMap : BaseMap<Product>
    {
        public ProductMap() : base("TB_PRODUCTS")
        {
        }

        public override void Configure(EntityTypeBuilder<Product> builder)
        {
            base.Configure(builder);

            builder.Property(p => p.EAN).HasColumnType("varchar(13)").IsRequired();
            builder.Property(p => p.Descrition).HasColumnType("varchar(1024)");
            builder.Property(p => p.Amount).IsRequired();
            builder.Property(p => p.MediumPrice).HasPrecision(7, 2);
            
            builder.HasMany(p => p.Movements)
                .WithMany(p => p.Products)
                .UsingEntity<ProductMoviment>(
                    p => p.HasOne(p => p.Movement).WithMany().HasForeignKey(x => x.MovementID), 
                    p => p.HasOne(p => p.Product).WithMany().HasForeignKey(x => x.ProductID),
                    p =>
                    {
                        p.ToTable("TB_PRODUCT_MOVEMENT");
                        p.HasKey(p =>new {p.MovementID, p.ProductID});
                        p.Property(p => p.MovementID).HasColumnName("ID_MOVEMENT").IsRequired();
                        p.Property(p => p.ProductID).HasColumnName("ID_PRODUCT").IsRequired();
                    }
                );
        }
    }
}
