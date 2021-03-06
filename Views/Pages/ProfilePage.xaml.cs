using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using ScheduleWPF.Classes;
using ScheduleWPF.Models.Entity;

namespace ScheduleWPF.Views.Pages
{
	public partial class ProfilePage : Page
	{
		private Student _currentStudentProfile;
		private Teacher _currentTeacherProfile;
		#region Init
		public ProfilePage()
		{
			InitializeComponent();
			if (Data.IsStudent)
			{
				TbCode.Visibility = Visibility.Collapsed;
				CbGroup.ItemsSource = ARMEntities.GetContext().Groups.ToList();
				_currentStudentProfile = ARMEntities.GetContext().Students.Any(x => x.IDUser == Data.IDUser) ? ARMEntities.GetContext().Students.First(x => x.IDUser == Data.IDUser) : new Student();
				_currentStudentProfile.User = ARMEntities.GetContext().Users.First(x => x.ID == Data.IDUser);
				DataContext = _currentStudentProfile;
				if (_currentStudentProfile.ID == 0) TbGroup.Visibility = Visibility.Hidden;
				else CbGroup.Visibility = Visibility.Hidden;
			}
			else if (Data.IsTeacher)
			{
				CbGroup.Visibility = Visibility.Collapsed;
				TbGroup.Visibility = Visibility.Collapsed;
				_currentTeacherProfile = ARMEntities.GetContext().Teachers.Any(x => x.IDUser == Data.IDUser) ? ARMEntities.GetContext().Teachers.First(x => x.IDUser == Data.IDUser) : new Teacher();
				_currentTeacherProfile.User = ARMEntities.GetContext().Users.First(x => x.ID == Data.IDUser);
				DataContext = _currentTeacherProfile;
			}
		}
		#endregion
		#region BtnSave
		private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
		{
			if (Data.IsStudent)
			{
				if (string.IsNullOrWhiteSpace(_currentStudentProfile.Surname) || string.IsNullOrWhiteSpace(_currentStudentProfile.Firstname) ||
					string.IsNullOrWhiteSpace(_currentStudentProfile.Patronymic))
				{
					MessageBox.Show("Заполните обязательные поля!"); return;
				}
				if (string.IsNullOrWhiteSpace(TbOldPassword.Text) ||
					string.IsNullOrWhiteSpace(TbNewPassword.Text) ||
					string.IsNullOrWhiteSpace(TbConfirmNewPassword.Text))
				{
					if (_currentStudentProfile.ID == 0) ARMEntities.GetContext().Students.Add(_currentStudentProfile);
				}
				else
				{
					if (_currentStudentProfile.User.Password == TbOldPassword.Text)
					{
						if (TbNewPassword.Text == TbConfirmNewPassword.Text)
							_currentStudentProfile.User.Password = TbNewPassword.Text;
						else { MessageBox.Show("Новые пароли не совпадают!"); }
					}
					else { MessageBox.Show("Старый пароль введен не верно!"); return; }
				}
				ARMEntities.GetContext().SaveChanges();
				MessageBox.Show("Данные сохранены!"); Manager.GoBack();
			}
			else if (Data.IsTeacher)
			{
				if (string.IsNullOrWhiteSpace(_currentTeacherProfile.Surname) ||
					string.IsNullOrWhiteSpace(_currentTeacherProfile.Firstname) ||
					string.IsNullOrWhiteSpace(_currentTeacherProfile.Patronymic))
				{
					MessageBox.Show("Заполните обязательные поля!");
					return;
				}
				if (string.IsNullOrWhiteSpace(TbOldPassword.Text) ||
				string.IsNullOrWhiteSpace(TbNewPassword.Text) ||
				string.IsNullOrWhiteSpace(TbConfirmNewPassword.Text))
				{
					if (!ARMEntities.GetContext().Teachers.Any(x => x.Code == _currentTeacherProfile.Code))
						ARMEntities.GetContext().Teachers.Add(_currentTeacherProfile);
				}
				else
				{
					if (_currentTeacherProfile.User.Password == TbOldPassword.Text)
					{
						if (TbNewPassword.Text == TbConfirmNewPassword.Text)
							_currentTeacherProfile.User.Password = TbNewPassword.Text;
						else
						{
							MessageBox.Show("Новые пароли не совпадают!");
						}
					}
					else
					{
						MessageBox.Show("Старый пароль введен не верно!");
						return;
					}
				}
				ARMEntities.GetContext().SaveChanges();
				MessageBox.Show("Данные сохранены!");
				Manager.GoBack();
			}
		}
		#endregion
		private bool _oldPasswordVisibility = true;
		private bool _newPasswordVisibility = true;
		private bool _confirmNewPasswordVisibility = true;
		#region TogglePassword
		#region ToggleVisibility
		private void IconOldPassword_Click(object sender, MouseButtonEventArgs e)
		{
			if (_oldPasswordVisibility)
			{
				_oldPasswordVisibility = false;
				TbOldPassword.Visibility = Visibility.Visible;
				PbOldPassword.Visibility = Visibility.Collapsed;
			}
			else
			{
				_oldPasswordVisibility = true;
				TbOldPassword.Visibility = Visibility.Collapsed;
				PbOldPassword.Visibility = Visibility.Visible;
			}
		}
		private void IconNewPassword_Click(object sender, MouseButtonEventArgs e)
		{
			if (_newPasswordVisibility)
			{
				_newPasswordVisibility = false;
				TbNewPassword.Visibility = Visibility.Visible;
				PbNewPassword.Visibility = Visibility.Collapsed;
			}
			else
			{
				_newPasswordVisibility = true;
				TbNewPassword.Visibility = Visibility.Collapsed;
				PbNewPassword.Visibility = Visibility.Visible;
			}
		}
		private void IconConfirmNewPassword_Click(object sender, MouseButtonEventArgs e)
		{
			if (_confirmNewPasswordVisibility)
			{
				_confirmNewPasswordVisibility = false;
				TbConfirmNewPassword.Visibility = Visibility.Visible;
				PbConfirmNewPassword.Visibility = Visibility.Collapsed;
			}
			else
			{
				_confirmNewPasswordVisibility = true;
				TbConfirmNewPassword.Visibility = Visibility.Collapsed;
				PbConfirmNewPassword.Visibility = Visibility.Visible;
			}
		}
		#endregion
		#region ToggleText
		private void PbOldPassword_OnPasswordChanged(object sender, RoutedEventArgs e)
		{
			if (_oldPasswordVisibility) TbOldPassword.Text = PbOldPassword.Password;
		}
		private void TbOldPassword_OnTextChanged(object sender, TextChangedEventArgs e)
		{
			if (_oldPasswordVisibility == false) PbOldPassword.Password = TbOldPassword.Text;
		}
		private void PbNewPassword_OnPasswordChanged(object sender, RoutedEventArgs e)
		{
			if (_newPasswordVisibility) TbNewPassword.Text = PbNewPassword.Password;
		}
		private void TbNewPassword_OnTextChanged(object sender, TextChangedEventArgs e)
		{
			if (_newPasswordVisibility == false) PbNewPassword.Password = TbNewPassword.Text;
		}

		private void PbConfirmNewPassword_OnPasswordChanged(object sender, RoutedEventArgs e)
		{
			if (_confirmNewPasswordVisibility) TbConfirmNewPassword.Text = PbConfirmNewPassword.Password;
		}
		private void TbConfirmNewPassword_OnTextChanged(object sender, TextChangedEventArgs e)
		{
			if (_confirmNewPasswordVisibility == false) PbConfirmNewPassword.Password = TbConfirmNewPassword.Text;
		}
		#endregion
		#endregion
		private void TbPersonalInfo_OnTextChanged(object sender, TextChangedEventArgs e)
		{
			GetPersonalInfo();
		}
		private void GetPersonalInfo()
		{
			try
			{
				if (string.IsNullOrWhiteSpace(TbSurname.Text) || string.IsNullOrWhiteSpace(TbFirstname.Text) || string.IsNullOrWhiteSpace(TbPatronymic.Text)) return;
				if (Data.IsStudent)
				{
					if (!ARMEntities.GetContext().Students.Any(x => x.Surname.Contains(TbSurname.Text) && x.Firstname.Contains(TbFirstname.Text))) return;
					_currentStudentProfile = ARMEntities.GetContext().Students.First(x =>
					x.Surname.Contains(TbSurname.Text) && x.Firstname.Contains(TbFirstname.Text));
					_currentStudentProfile.User = ARMEntities.GetContext().Users.First(x => x.ID == Data.IDUser);
					CbGroup.Visibility = Visibility.Hidden;
					TbGroup.Visibility = Visibility.Visible;
					TbGroup.Text = _currentStudentProfile.Group.Title;
				}
				else if (Data.IsTeacher)
				{
					if (!int.TryParse(TbCode.Text, out var code)) return;
					if (!ARMEntities.GetContext().Teachers.Any(x => x.Code == code)) return;
					_currentTeacherProfile = ARMEntities.GetContext().Teachers.First(x => x.Code == code);
					_currentTeacherProfile.User = ARMEntities.GetContext().Users.First(x => x.ID == Data.IDUser);
				}
			}
			catch (Exception e)
			{
				MessageBox.Show($"Ошибка: {e.Message} \nВнутреннее исключение:\n{e.InnerException}");
			}
		}
		private void TbCode_OnTextChanged(object sender, TextChangedEventArgs e)
		{
			try
			{
				if (!int.TryParse(TbCode.Text, out var code)) return;
				if (!ARMEntities.GetContext().Teachers.Any(x => x.Code == code)) return;
				var teacher = ARMEntities.GetContext().Teachers.First(x => x.Code == code);
				TbSurname.Text = teacher.Surname;
				TbFirstname.Text = teacher.Firstname;
				TbPatronymic.Text = teacher.Patronymic;
			}
			catch (Exception xe)
			{
				MessageBox.Show($"Ошибка: {xe.Message} \nВнутреннее исключение:\n{xe.InnerException}");
			}
		}
	}
}
