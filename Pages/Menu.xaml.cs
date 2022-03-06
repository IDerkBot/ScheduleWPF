using ScheduleWPF.Classes;
using System.Windows;
using System.Windows.Controls;

namespace ScheduleWPF.Pages
{
	/// <summary>
	/// Логика взаимодействия для Menu.xaml
	/// </summary>
	public partial class Menu : Page
	{
		public Menu() => InitializeComponent();
		private void BtnProfileMove_Click(object sender, RoutedEventArgs e) => Manager.Navigate(new ProfilePage());
		private void BtnLessonsMove_Click(object sender, RoutedEventArgs e) => Manager.Navigate(new LessonsPage());
		private void BtnTeachersMove_Click(object sender, RoutedEventArgs e) => Manager.Navigate(new TeachersPage());
		private void BtnJournalMove_Click(object sender, RoutedEventArgs e) => Manager.Navigate(new JournalPage());
		private void BtnAttendanceMove_Click(object sender, RoutedEventArgs e) => Manager.Navigate(new AttendancesPage());
		private void BtnGroupsMove_Click(object sender, RoutedEventArgs e) => Manager.Navigate(new GroupsPage());
		private void BtnExamsMove_Click(object sender, RoutedEventArgs e) => Manager.Navigate(new ExamsPage());
		private void BtnScheduleMove_Click(object sender, RoutedEventArgs e) => Manager.Navigate(new SchedulePage());
		private void BtnStudentsMove_Click(object sender, RoutedEventArgs e) => Manager.Navigate(new StudentsPage());
		private void BtnClassroomsMove_Click(object sender, RoutedEventArgs e) => Manager.Navigate(new ClassroomsPage());
		private void BtnSpecializationsMove_Click(object sender, RoutedEventArgs e) => Manager.Navigate(new SpecializationsPage());
		private void BtnModulesMove_Click(object sender, RoutedEventArgs e) => Manager.Navigate(new ModulesPage());
		private void BtnHolidaysMove_Click(object sender, RoutedEventArgs e) => Manager.Navigate(new HolidaysPage());
		private void Menu_OnLoaded(object sender, RoutedEventArgs e)
		{
			BtnProfile.Visibility = Data.IsAdmin ? Visibility.Collapsed : Visibility.Visible;
			BtnLessons.Visibility = Data.IsStudent ? Visibility.Collapsed : Visibility.Visible;
			BtnJournal.Visibility = Data.IsAdmin ? Visibility.Collapsed : Visibility.Visible;
			BtnAttendance.Visibility = Data.IsAdmin ? Visibility.Collapsed : Visibility.Visible;
			BtnGroups.Visibility = Data.IsStudent ? Visibility.Collapsed : Visibility.Visible;
			BtnExams.Visibility = Data.IsStudent ? Visibility.Collapsed : Visibility.Visible;
			BtnClassrooms.Visibility = Data.IsAdmin ? Visibility.Collapsed : Visibility.Visible;
			BtnSchedule.Visibility = Data.IsAdmin ? Visibility.Collapsed : Visibility.Visible;
			BtnStudents.Visibility = Data.IsStudent ? Visibility.Collapsed : Visibility.Visible;
			BtnSpecializations.Visibility = Data.IsStudent ? Visibility.Collapsed : Visibility.Visible;
			BtnModules.Visibility = Data.IsStudent ? Visibility.Collapsed : Visibility.Visible;
			BtnHolidays.Visibility = Data.IsStudent ? Visibility.Collapsed : Visibility.Visible;
		}
	}
}