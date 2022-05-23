using System.Windows.Controls;

namespace ScheduleWPF.Classes
{
	internal class Manager
	{
		public static Frame MainFrame { get; set; }
		public static void Navigate(Page moveToPage) => MainFrame.Navigate(moveToPage);
		public static void GoBack()
		{
			if(MainFrame.CanGoBack) MainFrame.GoBack();
		}
	}
}
