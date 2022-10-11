using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FIT_Api_Examples.Modul1.ViewModels
{
    public class EmployeeGetAllVM
    {
        public int id { get; set; }
        public string employee_name { get; set; }
        public float? employee_salary { get; set; }
        public int? employee_age { get; set; }
        public DateTime created_time { get; set; }
        public string profile_image { get; set; }
        public int task_count { get; set; }
    }
}
