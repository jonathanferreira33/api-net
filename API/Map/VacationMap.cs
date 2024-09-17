using API.Models.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Map
{
    public class VacationMap : BaseMap<Vacation>
    {
        public VacationMap() : base("TB_VACATIONS")
        {
        }

        public override void Configure(EntityTypeBuilder<Vacation> builder)
        {
            base.Configure(builder);

        }
    }
}
