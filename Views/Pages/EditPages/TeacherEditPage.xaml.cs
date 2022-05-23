using System.Linq;
using System.Windows;
using System.Windows.Controls;
using ScheduleWPF.Classes;
using ScheduleWPF.Models.Entity;

namespace ScheduleWPF.Views.Pages.EditPages
{
	/// <summary>
	/// Логика взаимодействия для TeacherEditPage.xaml
	/// </summary>
	public partial class TeacherEditPage : Page
	{
		private readonly Teacher _currentTeacher;
		public TeacherEditPage(Teacher selectedTeacher = null)
		{
			InitializeComponent();
			_currentTeacher = selectedTeacher ?? new Teacher();
			DataContext = _currentTeacher;
		}

		private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
		{
			if (string.IsNullOrWhiteSpace(_currentTeacher.Code.ToString()) ||
			    string.IsNullOrWhiteSpace(_currentTeacher.Surname) ||
			    string.IsNullOrWhiteSpace(_currentTeacher.Firstname) ||
			    string.IsNullOrWhiteSpace(_currentTeacher.Patronymic))
			{
				MessageBox.Show("");
				return;
			}

			if (!ARMEntities.GetContext().Teachers.Any(x => x.Code == _currentTeacher.Code))
				ARMEntities.GetContext().Teachers.Add(_currentTeacher);
			ARMEntities.GetContext().SaveChanges();
			MessageBox.Show("Данные сохранены");
			Manager.GoBack();
		}
	}
}
