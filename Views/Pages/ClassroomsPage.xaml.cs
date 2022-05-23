using ScheduleWPF.Classes;
using ScheduleWPF.Models.Entity;
using ScheduleWPF.Views.Pages.EditPages;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace ScheduleWPF.Views.Pages
{
    /// <summary>
    /// Логика взаимодействия для ClassroomsPage.xaml
    /// </summary>
    public partial class ClassroomsPage : Page
	{
		public ClassroomsPage() => InitializeComponent();
		private void ClassroomsPage_OnLoaded(object sender, RoutedEventArgs e)
		{
			DGridClassrooms.ItemsSource = ARMEntities.GetContext().Classrooms.ToList();
			BtnAdd.Visibility = Data.IsAdmin ? Visibility.Visible : Visibility.Collapsed;
			BtnDelete.Visibility = Data.IsAdmin ? Visibility.Visible : Visibility.Collapsed;
			CellEdit.Visibility = Data.IsAdmin ? Visibility.Visible : Visibility.Collapsed;
			CbSort.ItemsSource = DGridClassrooms.Columns.Select(x => x.Header).ToList();
		}
		private void CbSort_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			switch (CbSort.SelectedItem.ToString())
			{
				case "Номер":
					DGridClassrooms.ItemsSource = ARMEntities.GetContext().Classrooms.OrderBy(x => x.Number).ToList();
					break;
				case "Название":
					DGridClassrooms.ItemsSource = ARMEntities.GetContext().Classrooms.OrderBy(x => x.Title).ToList();
					break;
			}
		}
		private void TbSearch_OnTextChanged(object sender, TextChangedEventArgs e)
		{
			var searchText = TbSearch.Text;
			var searchResult = new List<Classroom>();
			ARMEntities.GetContext().Classrooms.ToList().ForEach(x =>
			{
				if (x.Number.ToString().Contains(searchText) ||
				    x.Title.ToLower().Contains(searchText))
					searchResult.Add(x);
			});
			DGridClassrooms.ItemsSource = searchResult;
		}
		private void BtnEdit_OnClick(object sender, RoutedEventArgs e) => Manager.Navigate(new ClassroomEditPage((sender as Button)?.DataContext as Classroom));
		private void BtnAdd_OnClick(object sender, RoutedEventArgs e) => Manager.Navigate(new ClassroomEditPage());
		private void BtnDelete_OnClick(object sender, RoutedEventArgs e)
		{
			var items = DGridClassrooms.SelectedItems.Cast<Classroom>().ToList();
			if(MessageBox.Show($"Вы действительно хотите удалить {items.Count} элементов?", "Удаление", MessageBoxButton.YesNo) != MessageBoxResult.Yes) return;
			ARMEntities.GetContext().Classrooms.RemoveRange(items);
			ARMEntities.GetContext().SaveChanges();
			DGridClassrooms.ItemsSource = ARMEntities.GetContext().Classrooms.ToList();
		}
	}
}