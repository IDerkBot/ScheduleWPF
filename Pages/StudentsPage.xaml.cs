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
	/// Логика взаимодействия для StudentsPage.xaml
	/// </summary>
	public partial class StudentsPage : Page
	{
		// TODO Sort
		// TODO Filter
		// TODO Search
		#region OnLoad
		
		public StudentsPage() => InitializeComponent();
		private void StudentsPage_OnLoaded(object sender, RoutedEventArgs e)
		{
			DGridStudents.ItemsSource = ARMEntities.GetContext().Students.ToList();
			CbFilter.ItemsSource = ARMEntities.GetContext().Students.GroupBy(x => x.Group.Title).Select(x => x.Key).ToList();
			BtnAdd.Visibility = Data.IsAdmin ? Visibility.Visible : Visibility.Collapsed;
			BtnDelete.Visibility = Data.IsAdmin ? Visibility.Visible : Visibility.Collapsed;
			CellEdit.Visibility = Data.IsAdmin ? Visibility.Visible : Visibility.Collapsed;
		}

		#endregion

		#region Buttons

		private void BtnDelete_OnClick(object sender, RoutedEventArgs e)
		{
			// TODO Delete
		}

		private void BtnAdd_OnClick(object sender, RoutedEventArgs e)
		{
			// TODO Add
		}

		private void BtnEdit_OnClick(object sender, RoutedEventArgs e)
		{
			// TODO Edit
		}

		#endregion

		private void CbFilter_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			DGridStudents.ItemsSource = ARMEntities.GetContext().Students
				.Where(x => x.Group.Title == CbFilter.SelectedItem.ToString()).ToList();
		}

		private void CbSort_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			var list = DGridStudents.ItemsSource.Cast<Student>().ToList();
			var enumerable = new List<Student>();
			switch (CbSort.SelectedItem.ToString())
			{
				case "ФИО":
					enumerable = list.OrderBy(x => x.Fullname).ToList();
					break;
				case "Телефон":
					enumerable = list.OrderBy(x => x.Phone).ToList();
					break;
				case "Почта":
					enumerable = list.OrderBy(x => x.Email).ToList();
					break;
				case "Адрес":
					enumerable = list.OrderBy(x => x.Address).ToList();
					break;
				case "Группа":
					enumerable = list.OrderBy(x => x.Group).ToList();
					break;
			}
			DGridStudents.ItemsSource = enumerable;
		}

		private void TbSearch_OnTextChanged(object sender, TextChangedEventArgs e)
		{
			
		}
	}
}