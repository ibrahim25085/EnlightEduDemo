using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EnlightEdu.Models
{
    public class Subject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }

        public int DepartmentId { get; set; }
        public Department Department { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }
}