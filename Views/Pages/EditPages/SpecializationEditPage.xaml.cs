using System.Linq;
using System.Windows;
using System.Windows.Controls;
using ScheduleWPF.Classes;
using ScheduleWPF.Models.Entity;

namespace ScheduleWPF.Views.Pages.EditPages
{
	/// <summary>
	/// Логика взаимодействия для SpecializationEditPage.xaml
	/// </summary>
	public partial class SpecializationEditPage : Page
	{
		private readonly Specialization _currentSpecialization;
		public SpecializationEditPage(Specialization selectedSpecialization = null)
		{
			InitializeComponent();
			_currentSpecialization = selectedSpecialization ?? new Specialization();
			DataContext = _currentSpecialization;
		}

		private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
		{
			if (string.IsNullOrWhiteSpace(_currentSpecialization.Code) ||
			    string.IsNullOrWhiteSpace(_currentSpecialization.Title))
			{
				MessageBox.Show("");
				return;
			}

			if (!ARMEntities.GetContext().Specializations.Any(x => x.Code == _currentSpecialization.Code))
				ARMEntities.GetContext().Specializations.Add(_currentSpecialization);
			ARMEntities.GetContext().SaveChanges();
			MessageBox.Show("Данные сохранены");
			Manager.GoBack();
		}
	}
}
