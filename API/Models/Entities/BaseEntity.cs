using System.ComponentModel.DataAnnotations;

namespace API.Models.Entities
{
    public class BaseEntity
    {
        public int Id;
        public DateTime DateInclude = DateTime.Now.Date;
        public DateTime DateLastModification = DateTime.Now.Date;
    }
}
