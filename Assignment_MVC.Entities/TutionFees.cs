using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment_MVC.Entities
{
    public class TutionFees
    {
        [ForeignKey("Course")]
        public int TutionFeesId { get; set; }
        public string CodeCourse { get; set; }
        public double Cost { get; set; }
        public double Vat { get; set; }

        

        //NavigationProperty
        //Relationships with
        //Course         one
        
        public virtual Course Course { get; set; }
    }
}
