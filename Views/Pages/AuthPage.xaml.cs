using ScheduleWPF.Classes;
using System.Windows;
using System.Windows.Controls;
using ScheduleWPF.Models;
using ScheduleWPF.Views.Pages;
using Menu = ScheduleWPF.Views.Pages.Menu;

namespace ScheduleWPF.Pages
{
	/// <summary>
	/// Логика взаимодействия для AuthPage.xaml
	/// </summary>
	public partial class AuthPage : Page
	{
		public AuthPage() => InitializeComponent();
		private void BtnAuth_Click(object sender, RoutedEventArgs e)
		{
			if(string.IsNullOrWhiteSpace(TbLogin.Text) || string.IsNullOrWhiteSpace(PbPassword.Password)) return;
			if (Authorization.HaveUser(TbLogin.Text))
			{
				if (Authorization.CheckPassword(TbLogin.Text, PbPassword.Password))
				{
					var user = Authorization.GetUser(TbLogin.Text);
					if (CbRemember.IsChecked == true)
					{
						var config = FileManager.GetConfig();
						config.Login = TbLogin.Text;
						config.Password = PbPassword.Password;
						config.IsRemember = true;
						FileManager.SetConfig(config);
					}
					else
					{
						var config = FileManager.GetConfig();
						config.Login = "";
						config.Password = "";
						config.IsRemember = false;
					}
					Data.IDUser = user.ID;
					Data.Access = user.Access;
					Manager.Navigate(new Menu());
				}
				else MessageBox.Show("Пароль не верный!");
			}
		}

		private void BtnRegMove_Click(object sender, RoutedEventArgs e) => Manager.Navigate(new RegPage());

		private void AuthPage_OnLoaded(object sender, RoutedEventArgs e)
		{
			var config = FileManager.GetConfig();
			if (!config.IsRemember) return;
			TbLogin.Text = config.Login;
			PbPassword.Password = config.Password;
			CbRemember.IsChecked = config.IsRemember;
		}
	}
}