using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MockAssessment6Practice.DALModels
{
    public class EmployeeDAL
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; }

        public string FirstName { get; set; }

        public int Age { get; set; }


        public decimal Salary  { get; set; }

    }
}
