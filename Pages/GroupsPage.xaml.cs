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
using ScheduleWPF.Pages.EditPages;

namespace ScheduleWPF.Pages
{
	/// <summary>
	/// Логика взаимодействия для GroupsPage.xaml
	/// </summary>
	public partial class GroupsPage : Page
	{
		public GroupsPage()
		{
			InitializeComponent();
		}
		
		private void CbSort_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			// TODO Sort
		}

		private void TbSearch_OnTextChanged(object sender, TextChangedEventArgs e)
		{
			var groups = ARMEntities.GetContext().Groups.ToList();
			var searchText = TbSearch.Text.ToLower();
			var searchGroups = new List<Group>();
			groups.ForEach(x =>
			{
				if (x.Title.ToLower().Contains(searchText) ||
				    x.Specialization.Title.ToLower().Contains(searchText) ||
				    x.Teacher.Fullname.ToLower().Contains(searchText))
				{
					searchGroups.Add(x);
				}
			});
			DGridGroups.ItemsSource = searchGroups;
		}

		private void BtnEdit_OnClick(object sender, RoutedEventArgs e) => Manager.Navigate(new GroupEditPage((sender as Button)?.DataContext as Group));

		private void BtnAdd_OnClick(object sender, RoutedEventArgs e) => Manager.Navigate(new GroupEditPage());

		private void BtnDelete_OnClick(object sender, RoutedEventArgs e)
		{
			var groupsForDelete = DGridGroups.ItemsSource.Cast<Group>().ToList();

		}

		private void GroupsPage_OnLoaded(object sender, RoutedEventArgs e)
		{
			DGridGroups.ItemsSource = ARMEntities.GetContext().Groups.ToList();
			BtnAdd.Visibility = Data.IsAdmin ? Visibility.Visible : Visibility.Collapsed;
			BtnDelete.Visibility = Data.IsAdmin ? Visibility.Visible : Visibility.Collapsed;
			CellEdit.Visibility = Data.IsAdmin ? Visibility.Visible : Visibility.Collapsed;

			var sortList = DGridGroups.Columns.Select(x => x.Header).ToList();
			sortList.RemoveAt(DGridGroups.Columns.Count - 1);
			CbSort.ItemsSource = sortList;
		}
	}
}
