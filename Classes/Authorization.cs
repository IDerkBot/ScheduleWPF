using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ScheduleWPF.Entity;

namespace ScheduleWPF.Classes
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
