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

namespace ScheduleWPF.Pages
{
	/// <summary>
	/// Логика взаимодействия для HolidaysPage.xaml
	/// </summary>
	public partial class HolidaysPage : Page
	{
		public HolidaysPage()
		{
			InitializeComponent();
		}

		private void HolidaysPage_OnLoaded(object sender, RoutedEventArgs e)
		{
			//BtnAdd.Visibility = Data.IsAdmin ? Visibility.Visible : Visibility.Collapsed;
			//BtnDelete.Visibility = Data.IsAdmin ? Visibility.Visible : Visibility.Collapsed;
			//CellEdit.Visibility = Data.IsAdmin ? Visibility.Visible : Visibility.Collapsed;
		}
	}
}
