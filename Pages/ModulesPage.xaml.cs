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

namespace ScheduleWPF.Pages
{
	/// <summary>
	/// Логика взаимодействия для ModulesPage.xaml
	/// </summary>
	public partial class ModulesPage : Page
	{
		public ModulesPage()
		{
			InitializeComponent();
		}
		// TODO Made all

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

		private void ModulesPage_OnLoaded(object sender, RoutedEventArgs e)
		{
			BtnAdd.Visibility = Data.IsAdmin ? Visibility.Visible : Visibility.Collapsed;
			BtnDelete.Visibility = Data.IsAdmin ? Visibility.Visible : Visibility.Collapsed;
			CellEdit.Visibility = Data.IsAdmin ? Visibility.Visible : Visibility.Collapsed;
		}
	}
}
