using ScheduleWPF.Classes;
using ScheduleWPF.Entity;
using ScheduleWPF.Pages.EditPages;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace ScheduleWPF.Pages
{
	/// <summary>
	/// Логика взаимодействия для TeachersPage.xaml
	/// </summary>
	public partial class TeachersPage : Page
	{
		public TeachersPage() => InitializeComponent();
		private void TeachersPage_OnLoaded(object sender, RoutedEventArgs e)
		{
			var teachers = ARMEntities.GetContext().Teachers.ToList();
			teachers.ForEach(x =>
			{
				if (x.Groups == null) return;
				x.Group = string.Join(", ", x.Groups.Select(group => @group.Title));
			});
			DGridTeachers.ItemsSource = teachers;

			CellEdit.Visibility = Data.IsStudent || Data.IsTeacher ? Visibility.Collapsed : Visibility.Visible;
			BtnAdd.Visibility = Data.IsStudent || Data.IsTeacher ? Visibility.Collapsed : Visibility.Visible;
			BtnDelete.Visibility = Data.IsStudent || Data.IsTeacher ? Visibility.Collapsed : Visibility.Visible;
		}

		private void CbSort_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			switch (CbSort.SelectedItem.ToString())
			{
				case "Фамилия имя отчество":
					DGridTeachers.ItemsSource = ARMEntities.GetContext().Teachers.OrderBy(x => x.Fullname).ToList();
					break;
				case "Телефон":
					DGridTeachers.ItemsSource = ARMEntities.GetContext().Teachers.OrderBy(x => x.Phone).ToList();
					break;
				case "Почта":
					DGridTeachers.ItemsSource = ARMEntities.GetContext().Teachers.OrderBy(x => x.Email).ToList();
					break;
				case "Адрес":
					DGridTeachers.ItemsSource = ARMEntities.GetContext().Teachers.OrderBy(x => x.Address).ToList();
					break;
			}
		}
		private void TbSearch_OnTextChanged(object sender, TextChangedEventArgs e)
		{
			var searchText = TbSearch.Text;
			var searchResult = new List<Teacher>();
			ARMEntities.GetContext().Teachers.ToList().ForEach(x =>
			{
				if (x.Fullname.ToLower().Contains(searchText) ||
				    x.Phone.ToLower().Contains(searchText) ||
				    x.Email.ToLower().Contains(searchText) ||
				    x.Address.ToLower().Contains(searchText))
					searchResult.Add(x);
			});
			DGridTeachers.ItemsSource = searchResult;
		}

		private void BtnEdit_OnClick(object sender, RoutedEventArgs e) => Manager.Navigate(new TeacherEditPage((sender as Button)?.DataContext as Teacher));
		private void BtnAdd_OnClick(object sender, RoutedEventArgs e) => Manager.Navigate(new TeacherEditPage());

		private void BtnDelete_OnClick(object sender, RoutedEventArgs e)
		{
			var items = DGridTeachers.SelectedItems.Cast<Teacher>().ToList();
			if (MessageBox.Show($"Вы действительно хотите удалить {items.Count} элементов?", "Удаление", MessageBoxButton.YesNo) != MessageBoxResult.Yes) return;
			ARMEntities.GetContext().Teachers.RemoveRange(items);
			ARMEntities.GetContext().SaveChanges();
			DGridTeachers.ItemsSource = ARMEntities.GetContext().Teachers.ToList();
		}
	}
}
