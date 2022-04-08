using ScheduleWPF.Classes;
using ScheduleWPF.Entity;
using System.Windows;
using System.Windows.Controls;

namespace ScheduleWPF.Pages.EditPages
{
	/// <summary>
	/// Логика взаимодействия для ClassroomEditPage.xaml
	/// </summary>
	public partial class ClassroomEditPage : Page
	{
		private readonly Classroom _currentClassroom;
		public ClassroomEditPage(Classroom selectedClassroom = null)
		{
			InitializeComponent();
			_currentClassroom = selectedClassroom ?? new Classroom();
			DataContext = _currentClassroom;
		}

		private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
		{
			if (_currentClassroom.ID == 0) ARMEntities.GetContext().Classrooms.Add(_currentClassroom);
			ARMEntities.GetContext().SaveChanges();
			MessageBox.Show("Данные сохранены");
			Manager.GoBack();
		}
	}
}
