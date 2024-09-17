using API.Models.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace API.Map
{
    public class MovementMap : BaseMap<Movement>
    {
        public MovementMap() : base("TB_MOVIMENTS")
        {

        }

        public override void Configure(EntityTypeBuilder<Movement> builder)
        {
            base.Configure(builder);
            builder.Property(x => x.Id).HasColumnName("MovimentNumber");
            builder.Property(x => x.EmployeeID).HasColumnName("Id_Responsible");
            builder.HasOne(x => x.Employee).WithMany(x=> x.Movements).HasForeignKey(x => x.EmployeeID);
        }
    }
}