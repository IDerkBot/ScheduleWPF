using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ScheduleWPF.Classes;
using ScheduleWPF.Entity;

namespace ScheduleWPF.Pages.EditPages
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
