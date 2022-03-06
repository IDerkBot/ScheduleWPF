using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleWPF.Classes
{
	internal class Data
	{
		public static int IDUser { get; set; }
		public static int Access { get; set; }
		public static bool IsStudent => Access == 0;
		public static bool IsTeacher => Access == 1;
		public static bool IsLessonWork => Access == 2;
		public static bool IsEducationWork => Access == 3;
		public static bool IsAdmin => Access == 4;
	}
}
