using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEB_Presentation.Models
{
    public class InternModel
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime BirthDate { get; set; }
        public virtual double AverageMark { get; set; }
    }
}