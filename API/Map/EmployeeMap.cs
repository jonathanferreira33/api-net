using API.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Map
{
    public class EmployeeMap : BaseMap<Employee>
    {
        public EmployeeMap() : base("TB_EMPLOYEES")
        {

        }

        public override void Configure(EntityTypeBuilder<Employee> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.Id).HasColumnName("RegistrationNumber");
            builder.Property(e => e.Email).IsRequired();
            builder.Property(e => e.FullName).IsRequired().HasPrecision(100);
            builder.Property(e => e.Remuneration).HasPrecision(7, 2);
        }
    }
}
