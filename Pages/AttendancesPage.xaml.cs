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

namespace ScheduleWPF.Pages
{
	/// <summary>
	/// Логика взаимодействия для AttendancesPage.xaml
	/// </summary>
	public partial class AttendancesPage : Page
	{
		public AttendancesPage()
		{
			InitializeComponent();
		}
		// TODO Made all
		private void CbGroups_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			
		}

		private void CbFilter_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			
		}

		private void TbSearch_OnTextChanged(object sender, TextChangedEventArgs e)
		{
			
		}

		private void BtnEdit_OnClick(object sender, RoutedEventArgs e)
		{
			
		}

		private void BtnAdd_OnClick(object sender, RoutedEventArgs e)
		{
			
		}

		private void BtnDelete_OnClick(object sender, RoutedEventArgs e)
		{
			
		}

		private void LbLessons_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			
		}

		private void AttendancesPage_OnLoaded(object sender, RoutedEventArgs e)
		{
			if (Data.IsStudent)
			{
				LbLessons.ItemsSource = ARMEntities.GetContext().Lessons.ToList();
				BtnAdd.Visibility = Data.IsStudent ? Visibility.Collapsed : Visibility.Visible;
				BtnDelete.Visibility = Data.IsStudent ? Visibility.Collapsed : Visibility.Visible;
				CellEdit.Visibility = Data.IsStudent ? Visibility.Collapsed : Visibility.Visible;
				DpDate.Visibility = Data.IsStudent ? Visibility.Collapsed : Visibility.Visible;
				ColStudents.Visibility = Data.IsStudent ? Visibility.Collapsed : Visibility.Visible;
			}
			else if (Data.IsTeacher)
			{
				LbLessons.ItemsSource = ARMEntities.GetContext().LessonTeachers.Where(x => x.Teacher.IDUser == Data.IDUser)
					.Select(x => x.Lesson).ToList();
				if (LbLessons.SelectedItem == null || LbStudents.SelectedItem == null) return;

				var selectedStudent = LbStudents.SelectedItem as Student;
				var selectedLesson = LbLessons.SelectedItem as Lesson;
				DGridStudents.ItemsSource = ARMEntities.GetContext().Journals.Where(x => x.Lesson.Title == selectedLesson.Title && x.Student.ID == selectedStudent.ID).ToList();

			}
		}

		private void LbStudents_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			
		}
	}
}
