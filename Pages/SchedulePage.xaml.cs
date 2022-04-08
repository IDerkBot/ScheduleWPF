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
using ScheduleWPF.Entity;

namespace ScheduleWPF.Pages
{
	/// <summary>
	/// Логика взаимодействия для SchedulePage.xaml
	/// </summary>
	public partial class SchedulePage : Page
	{
		public SchedulePage()
		{
			InitializeComponent();
		}
		// TODO Made all
		private void SchedulePage_OnLoaded(object sender, RoutedEventArgs e)
		{
			DGridSchedule.ItemsSource = ARMEntities.GetContext().Schedules.ToList();
		}
	}
	public class WorkDay
	{
		public int IDGroup;

	}
}
