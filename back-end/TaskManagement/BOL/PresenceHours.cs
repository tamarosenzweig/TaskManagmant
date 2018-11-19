using BOL.Help.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL
{
    public class PresenceHours
    {
        [Key]
        public int PresenceHoursId { get; set; }

        [ForeignKey("Worker")]
        public int WorkerId { get; set; }

        [ForeignKey("Project")]
        public int ProjectId { get; set; }

        [Required(ErrorMessage = "Required field")]
        [Column(TypeName = "Date")]
        [Today]
        //start hours less than endhours
        public DateTime StartHour { get; set; }

        [Column(TypeName = "Date")]
        [Today]
        public DateTime? EndHour { get; set; }

        //Navigation Properties

        public User Worker { get; set; }

        public Project Project { get; set; }

    }
}
