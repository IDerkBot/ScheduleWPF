using System;
using System.Windows;
using System.Windows.Controls;
using ScheduleWPF.Classes;
using ScheduleWPF.Models.Entity;

namespace ScheduleWPF.Views.Pages.EditPages
{
	/// <summary>
	/// Логика взаимодействия для JournalEditPage.xaml
	/// </summary>
	public partial class JournalEditPage : Page
	{
		private readonly Journal _currentJournal;
		public JournalEditPage(Student selectedStudent, Lesson selectedLesson)
		{
			InitializeComponent();
			_currentJournal = new Journal()
			{
				Student = selectedStudent,
				Lesson = selectedLesson,
				Date = DateTime.Now
			};
			DataContext = _currentJournal;
		}

		private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
		{
			if (DpDate.SelectedDate != null) _currentJournal.Date = (DateTime) DpDate.SelectedDate;
			ARMEntities.GetContext().Journals.Add(_currentJournal);
			ARMEntities.GetContext().SaveChanges();
			MessageBox.Show("Данные сохранены");
			Manager.GoBack();
		}
	}
}
