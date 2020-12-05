using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Auh_angular_netcore.ir.Entities
{
    public class Course
    {
        [Key]
        public int CourseId { get; set; }
        public string Coursename { get; set; }
        public int CoursePrice { get; set; }
        public string CourseImageurl { get; set; }
    }
}
