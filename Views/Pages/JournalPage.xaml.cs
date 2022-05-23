using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using ScheduleWPF.Classes;
using ScheduleWPF.Models.Entity;
using ScheduleWPF.Views.Pages.EditPages;

namespace ScheduleWPF.Views.Pages
{
	/// <summary>
	/// Логика взаимодействия для JournalPage.xaml
	/// </summary>
	public partial class JournalPage : Page
	{
		public JournalPage()
		{
			InitializeComponent();
		}
		// TODO нельзя добавлять оценку на пару на которой уже стоит оценка
		private bool _lessonSelect = false;
		private bool _groupSelect = false;
		private void BtnAdd_OnClick(object sender, RoutedEventArgs e)
		{
			Manager.Navigate(new JournalEditPage(LbStudents.SelectedItem as Student, LbLessons.SelectedItem as Lesson));
		}

		private void BtnDelete_OnClick(object sender, RoutedEventArgs e)
		{

		}

		private void JournalPage_OnLoaded(object sender, RoutedEventArgs e)
		{
			if (Data.IsStudent)
			{
				LbLessons.ItemsSource = ARMEntities.GetContext().Lessons.ToList();
				CbGroups.Visibility = Visibility.Collapsed;
				BtnAdd.Visibility = Visibility.Collapsed;
				ColStudents.Visibility = Visibility.Collapsed;
			}
			else if (Data.IsTeacher)
			{
				LbLessons.ItemsSource = ARMEntities.GetContext().LessonTeachers.Where(x => x.Teacher.IDUser == Data.IDUser)
					.Select(x => x.Lesson).ToList();
				if (LbLessons.SelectedItem == null || LbStudents.SelectedItem == null) return;

				var selectedStudent = LbStudents.SelectedItem as Student;
				var selectedLesson = LbLessons.SelectedItem as Lesson;
				DGridJournal.ItemsSource = ARMEntities.GetContext().Journals.Where(x => x.Lesson.Title == selectedLesson.Title && x.Student.ID == selectedStudent.ID).ToList();
			}
		}
		private void LbLessons_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			_lessonSelect = true;
			if (Data.IsStudent)
			{
				var lesson = LbLessons.SelectedItem as Lesson;
				var student = ARMEntities.GetContext().Students.First(x => x.IDUser == Data.IDUser);
				var scores = ARMEntities.GetContext().Journals.Where(x => x.Lesson.Title == lesson.Title && x.Student.ID == student.ID).ToList();
				DGridJournal.ItemsSource = scores;
				if (scores.Count <= 0) return;
				var sumScore = scores.Select(x => x.Score).Aggregate((x, y) => (byte?)(x + y));
				TbMiddle.Text = (sumScore / scores.Count).ToString();
			}
			else if (Data.IsTeacher)
			{
				try
				{
					var selectedLesson = LbLessons.SelectedItem as Lesson;
					CbGroups.IsEnabled = true;
					if (ARMEntities.GetContext().LessonSpezializations
							.Any(x => x.Lesson.Title == selectedLesson.Title))
					{
						var list = ARMEntities.GetContext().LessonSpezializations
							.Where(x => x.Lesson.Title == selectedLesson.Title).ToList();
						//CbGroups.ItemsSource = ARMEntities.GetContext().Groups.Where(gr => gr.Specialization.Title == )
					}
					else
					{
						CbGroups.ItemsSource = ARMEntities.GetContext().Groups.ToList();
					}
				}
				catch (Exception exception)
				{
					MessageBox.Show($"{exception.Message}\n{exception.InnerException}");
				}
			}
		}

		private void Selector_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			var selectedGroup = CbGroups.SelectedItem as Group;
			LbStudents.ItemsSource = ARMEntities.GetContext().Students
				.Where(x => x.IDGroup == selectedGroup.ID).ToList();
			_groupSelect = true;
		}

		private void LbStudents_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if(LbStudents.SelectedItem == null) return;
			var selectedStudent = LbStudents.SelectedItem as Student;
			var selectedLesson = LbLessons.SelectedItem as Lesson;
			var scores = ARMEntities.GetContext().Journals.Where(x => x.Lesson.Title == selectedLesson.Title && x.Student.ID == selectedStudent.ID).ToList();
			DGridJournal.ItemsSource = scores;
			if (scores.Count <= 0) return;
			var sumScore = scores.Select(x => x.Score).Aggregate((x, y) => (byte?)(x + y));
			TbMiddle.Text = (sumScore / scores.Count).ToString();
		}

		private void DpDate_OnSelectedDateChanged(object sender, SelectionChangedEventArgs e)
		{
			if (_lessonSelect == false) return;
			if (Data.IsStudent)
			{
				var lesson = LbLessons.SelectedItem as Lesson;
				var student = ARMEntities.GetContext().Students.First(x => x.IDUser == Data.IDUser);
				var lessons = ARMEntities.GetContext().Journals.Where(x => x.Lesson.Title == lesson.Title && x.Student.ID == student.ID && x.Date == DpDate.SelectedDate).ToList();
				DGridJournal.ItemsSource = lessons;
				if (lessons.Count <= 0) return;
				var sumScore = lessons.Select(x => x.Score).Aggregate((x, y) => (byte?)(x + y));
				TbMiddle.Text = (sumScore / lessons.Count).ToString();
			}
			else if (Data.IsTeacher)
			{
				if (_groupSelect == false) return;
				ColDate.Visibility = Visibility.Collapsed;
				var lesson = LbLessons.SelectedItem as Lesson;
				var selectedGroup = CbGroups.SelectedItem as Group;
				var scores = ARMEntities.GetContext().Journals
					.Where(x => x.Lesson.Title == lesson.Title && x.Student.IDGroup == selectedGroup.ID && x.Date == DpDate.SelectedDate).ToList();
				DGridJournal.ItemsSource = scores;
			}
		}
	}
}