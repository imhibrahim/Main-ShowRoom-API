using System.ComponentModel.DataAnnotations.Schema;

namespace ShowRoomManagment_API.Data
{
    public class Employee
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public  string Email { get; set; }

        public string Cnic { get; set; }

        public string Address { get; set; }

        public string Contact { get; set; }

        public string ProfileImagePath { get; set; }

        [ForeignKey("Departments")]
        public int DepartmentId { get; set; }

        // [NotMapped]
        //public Department Department { get; set; }

    }
}
