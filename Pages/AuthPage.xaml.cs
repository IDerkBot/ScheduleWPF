using ScheduleWPF.Classes;
using ScheduleWPF.Entity;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace ScheduleWPF.Pages
{
	/// <summary>
	/// Логика взаимодействия для AuthPage.xaml
	/// </summary>
	public partial class AuthPage : Page
	{
		public AuthPage()
		{
			InitializeComponent();
		}

		private void BtnAuth_Click(object sender, RoutedEventArgs e)
		{
			if(string.IsNullOrWhiteSpace(TbLogin.Text) || string.IsNullOrWhiteSpace(PbPassword.Password)) return;
			if (Authorization.HaveUser(TbLogin.Text))
			{
				if (Authorization.CheckPassword(TbLogin.Text, PbPassword.Password))
				{
					var user = Authorization.GetUser(TbLogin.Text);
					Data.IDUser = user.ID;
					Data.Access = user.Access;
					Manager.Navigate(new Menu());
				}
				else
					MessageBox.Show("Пароль не верный!");
			}
			else
				MessageBox.Show("Пользователь не найден!");
		}

		private void BtnRegMove_Click(object sender, RoutedEventArgs e)
		{
			Manager.Navigate(new RegPage());
		}
	}
}
