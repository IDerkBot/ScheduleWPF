using System.Linq;
using System.Windows;
using System.Windows.Controls;
using ScheduleWPF.Classes;
using ScheduleWPF.Models.Entity;
using ScheduleWPF.Pages;
using ScheduleWPF.Views.Pages.EditPages;

namespace ScheduleWPF.Views.Pages
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
			switch (Data.IsAdmin)
			{
				case true:
					BtnProfile.Visibility = Data.IsAdmin ? Visibility.Collapsed : Visibility.Visible;
					BtnJournal.Visibility = Data.IsAdmin ? Visibility.Collapsed : Visibility.Visible;
					BtnAttendance.Visibility = Data.IsAdmin ? Visibility.Collapsed : Visibility.Visible;
					break;
			}
			switch (Data.IsStudent)
			{
				//BtnHolidays.Visibility = Data.IsStudent ? Visibility.Collapsed : Visibility.Visible;
				case true when !ARMEntities.GetContext().Students.Any(x => x.IDUser == Data.IDUser):
					MessageBox.Show("Добавьте данные в профиль!");
					BtnLessons.Visibility = Visibility.Collapsed;
					BtnTeachers.Visibility = Visibility.Collapsed;
					BtnJournal.Visibility = Visibility.Collapsed;
					BtnAttendance.Visibility = Visibility.Collapsed;
					BtnGroups.Visibility = Visibility.Collapsed;
					BtnExams.Visibility = Visibility.Collapsed;
					BtnClassrooms.Visibility = Visibility.Collapsed;
					BtnSchedule.Visibility = Visibility.Collapsed;
					BtnStudents.Visibility = Visibility.Collapsed;
					BtnSpecializations.Visibility = Visibility.Collapsed;
					BtnModules.Visibility = Visibility.Collapsed;
					BtnHolidays.Visibility = Visibility.Collapsed;
					break;
				case true when ARMEntities.GetContext().Students.Any(x => x.IDUser == Data.IDUser):
					BtnLessons.Visibility = Visibility.Visible;
					BtnTeachers.Visibility = Visibility.Visible;
					BtnJournal.Visibility = Visibility.Visible;
					BtnAttendance.Visibility = Visibility.Visible;
					BtnGroups.Visibility = Visibility.Visible;
					BtnExams.Visibility = Visibility.Collapsed;
					BtnClassrooms.Visibility = Visibility.Visible;
					BtnSchedule.Visibility = Visibility.Visible;
					BtnStudents.Visibility = Visibility.Collapsed;
					BtnSpecializations.Visibility = Visibility.Collapsed;
					BtnModules.Visibility = Visibility.Collapsed;
					BtnHolidays.Visibility = Visibility.Collapsed;
					break;
			}
			switch (Data.IsTeacher)
			{
				case true when !ARMEntities.GetContext().Teachers.Any(x => x.IDUser == Data.IDUser):
					BtnLessons.Visibility = Visibility.Collapsed;
					BtnTeachers.Visibility = Visibility.Collapsed;
					BtnJournal.Visibility = Visibility.Collapsed;
					BtnAttendance.Visibility = Visibility.Collapsed;
					BtnGroups.Visibility = Visibility.Collapsed;
					BtnExams.Visibility = Visibility.Collapsed;
					BtnClassrooms.Visibility = Visibility.Collapsed;
					BtnSchedule.Visibility = Visibility.Collapsed;
					BtnStudents.Visibility = Visibility.Collapsed;
					BtnSpecializations.Visibility = Visibility.Collapsed;
					BtnModules.Visibility = Visibility.Collapsed;
					BtnHolidays.Visibility = Visibility.Collapsed;
					break;
				case true when ARMEntities.GetContext().Teachers.Any(x => x.IDUser == Data.IDUser):
					BtnLessons.Visibility = Visibility.Visible;
					BtnTeachers.Visibility = Visibility.Visible;
					BtnJournal.Visibility = Visibility.Visible;
					BtnAttendance.Visibility = Visibility.Visible;
					BtnGroups.Visibility = Visibility.Visible;
					BtnExams.Visibility = Visibility.Collapsed;
					BtnClassrooms.Visibility = Visibility.Visible;
					BtnSchedule.Visibility = Visibility.Visible;
					BtnHolidays.Visibility = Visibility.Visible;
					BtnSpecializations.Visibility = Visibility.Visible;
					BtnModules.Visibility = Visibility.Collapsed;
					BtnHolidays.Visibility = Visibility.Visible;
					break;
			}
		}

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e) => Manager.Navigate(new ScheduleEditPage());
	}
}