using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ShowRoomManagment_API.Data
{
    public class Department
    {
        [Key]
        public int Id { get; set; }
        [Column("varchar(100)")]
        public string Name { get; set; }
        public string? Description { get; set; }

        //[NotMapped]
        public IList<Employee> Employees { get; set; }
    }
}
