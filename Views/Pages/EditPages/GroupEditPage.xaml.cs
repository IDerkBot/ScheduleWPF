using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using ScheduleWPF.Classes;
using ScheduleWPF.Models.Entity;

namespace ScheduleWPF.Views.Pages.EditPages
{
	/// <summary>
	/// Логика взаимодействия для GroupEditPage.xaml
	/// </summary>
	public partial class GroupEditPage : Page
	{
		private readonly Group _currentGroup;
		public GroupEditPage(Group selectedGroup = null)
		{
			InitializeComponent();
			_currentGroup = selectedGroup ?? new Group();
			DataContext = _currentGroup;
		}

		private void GroupEditPage_OnLoaded(object sender, RoutedEventArgs e)
		{
			CbSpecialization.ItemsSource = ARMEntities.GetContext().Specializations.ToList();
			CbTeacher.ItemsSource = ARMEntities.GetContext().Teachers.ToList();
		}

		private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
		{
			try
			{
				if (string.IsNullOrWhiteSpace(_currentGroup.Title) || CbSpecialization.SelectedItem == null)
				{
					MessageBox.Show("Заполните все поля");
					return;
				}
				if (_currentGroup.ID == 0)
					ARMEntities.GetContext().Groups.Add(_currentGroup);
				ARMEntities.GetContext().SaveChanges();
				MessageBox.Show("Данные сохранены");
				Manager.GoBack();
			}
			catch (Exception exception)
			{
				MessageBox.Show($"{exception.Message}\n{exception.InnerException}");
			}
		}
	}
}
