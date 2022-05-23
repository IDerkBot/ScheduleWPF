using System.Linq;
using System.Windows;
using System.Windows.Controls;
using ScheduleWPF.Classes;
using ScheduleWPF.Models.Entity;

namespace ScheduleWPF.Views.Pages
{
	/// <summary>
	/// Логика взаимодействия для LessonsPage.xaml
	/// </summary>
	public partial class LessonsPage : Page
	{
		public LessonsPage()
		{
			InitializeComponent();
		}
		// TODO Sort
		// TODO Search
		private void LessonsPage_OnLoaded(object sender, RoutedEventArgs e)
		{
			var lessons = ARMEntities.GetContext().Lessons.ToList();
			lessons.ForEach(x =>
			{
				if (!ARMEntities.GetContext().LessonTeachers.Any(lt => lt.IDLesson == x.ID)) return;
				var teachers = ARMEntities.GetContext().LessonTeachers.Where(lt => lt.IDLesson == x.ID).Select(t => t.Teacher).ToList();
				x.Teachers = string.Join(", ", teachers.Select(t => t.Fullname));
			});
			DGridLessons.ItemsSource = lessons;
			CbSort.ItemsSource = DGridLessons.Columns.Select(x => x.Header).ToList();
			BtnAdd.Visibility = Data.IsAdmin ? Visibility.Visible : Visibility.Collapsed;
			BtnDelete.Visibility = Data.IsAdmin ? Visibility.Visible : Visibility.Collapsed;
			CellEdit.Visibility = Data.IsAdmin ? Visibility.Visible : Visibility.Collapsed;
		}

		private void CbSort_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
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
	}
}
