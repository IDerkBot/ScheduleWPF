using System.Windows;
using ScheduleWPF.Models.Entity;
using System.Linq;

namespace ScheduleWPF.Models
{
	internal class Authorization
	{
		public static bool HaveUser(string login)
		{
			if (ARMEntities.GetContext().Users.Any(x => x.Login == login))
				return true;
			MessageBox.Show("Пользователь не найден");
			return false;
		}
		public static User GetUser(string login)
		{
			return string.IsNullOrEmpty(login) ? new User() : ARMEntities.GetContext().Users.First(x => x.Login == login);
		}
		public static bool CheckPassword(string login, string password)
		{
			return GetUser(login).Password == password;
		}
	}
}
