using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Employee.Models
{
    [Table("Employee")]
    public class EmployeeModel
    {
        [Required]
        [Key]
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Designation { get; set; }

        public int StateID { get; set; }

        public int CityID { get; set; }
    }

    [Table("State")]
    public class State
    {
        public int Id { get; set; }
        public string StateName { get; set; }

    }

    [Table("City")]
    public class City
    {
        public int Id { get; set; }
        public int StateId { get; set; }
        public string CityName { get; set; }
                
    }

}