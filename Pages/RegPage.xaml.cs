using ScheduleWPF.Classes;
using ScheduleWPF.Entity;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace ScheduleWPF.Pages
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
				ARMEntities.GetContext().Users.Add(new User(login, password));
				ARMEntities.GetContext().SaveChanges();
				MessageBox.Show("Вы успешно зарегистрировались!");
				Manager.GoBack();
			}
			else
				MessageBox.Show("Такой пользователь уже существует!");
		}
	}
}