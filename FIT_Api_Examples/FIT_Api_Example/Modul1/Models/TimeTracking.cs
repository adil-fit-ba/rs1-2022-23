using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FIT_Api_Examples.Modul1.Models
{
    public class TimeTracking
    { 
        [Key]
        public int id { get; set; }

        public ProjectTask project_task { get; set; }
        [ForeignKey(nameof(project_task))]
        public int project_task_id{ get; set; }
    
        public DateTime start_time{ get; set; }
        public DateTime end_time{ get; set; }
        public TimeSpan spent_time{ get; set; }
        public string description { get; set; }
    }
}
