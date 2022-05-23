using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using ScheduleWPF.Classes;
using ScheduleWPF.Models.Entity;

namespace ScheduleWPF.Views.Pages
{
	/// <summary>
	/// Логика взаимодействия для RegPage.xaml
	/// </summary>
	public partial class RegPage : Page
	{
		public RegPage() => InitializeComponent();

		private void BtnReg_Click(object sender, RoutedEventArgs e)
		{
			var login = TbLogin.Text;
			var password = PbPassword.Password;
			if (!ARMEntities.GetContext().Users.Any(x => x.Login == login))
			{
				ARMEntities.GetContext().Users.Add(new User(login, password, (byte)(CbRole.SelectedItem.ToString() == "Студент" ? 0 : 1)));
				ARMEntities.GetContext().SaveChanges();
				MessageBox.Show("Вы успешно зарегистрировались!");
				Manager.GoBack();
			}
			else
				MessageBox.Show("Такой пользователь уже существует!");
		}

		private void RegPage_OnLoaded(object sender, RoutedEventArgs e)
		{
			CbRole.ItemsSource = new List<string> { "Студент", "Преподаватель" };
		}
	}
}