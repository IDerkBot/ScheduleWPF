namespace ScheduleWPF.Classes
{
	internal class Data
	{
		public static int IDUser { get; set; }
		public static int Access { get; set; }
		public static bool IsStudent => Access == 0;
		public static bool IsStaffOrAdmin => Access >= 1;
		public static bool IsTeacher => Access == 1;
		public static bool IsLessonWork => Access == 2;
		public static bool IsEducationWork => Access == 3;
		public static bool IsAdmin => Access == 4;
		public static string CurrentDirectory { get; set; } = "ARMWPF";
		public static string CurrentConfigFile { get; set; } = "config";
		public static string CurrentConfigExtension { get; set; } = "json";
	}
}
