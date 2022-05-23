using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScheduleWPF.Models.Entity;

namespace ScheduleWPF.Models
{
    internal class ScheduleGroup
    {
        public Group Group { get; set; }
        public Lesson FirstLesson { get; set; }
        public Lesson SecondLesson { get; set; }
        public Lesson ThirdLesson { get; set; }
        public Lesson FourthLesson { get; set; }
    }
}
