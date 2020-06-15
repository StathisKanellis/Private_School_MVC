using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment_MVC.Entities
{
    public class MarkAssignment
    {
        [Key,Column(Order = 1)]
        public int StudentId { get; set; }
        [Key, Column(Order = 2)]
        public int AssignmentId { get; set; }

        public string MarkCode { get; set; }
        public int TotalMark { get; set; }
        public DateTime EndTime { get; set; }

        //NavigationProperty
        //Relationships     with
        //Student           one
        //Assignment        one
        public virtual Student Student { get; set; }
        public virtual Assignment Assignment { get; set; }
    }
}
