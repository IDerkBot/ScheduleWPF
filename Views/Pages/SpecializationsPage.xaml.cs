using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using ScheduleWPF.Classes;
using ScheduleWPF.Models.Entity;
using ScheduleWPF.Views.Pages.EditPages;

namespace ScheduleWPF.Views.Pages
{
	/// <summary>
	/// Логика взаимодействия для SpecializationsPage.xaml
	/// </summary>
	public partial class SpecializationsPage : Page
	{
		public List<Specialization> Specializations { get; set; } = ARMEntities.GetContext().Specializations.ToList();
		public SpecializationsPage()
		{
			InitializeComponent();
		}
		// TODO Sort
		// TODO Filter

		private void CbSort_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			
		}

		private void TbSearch_OnTextChanged(object sender, TextChangedEventArgs e)
		{
			
		}

		private void BtnEdit_OnClick(object sender, RoutedEventArgs e) => Manager.Navigate(new SpecializationEditPage((sender as Button)?.DataContext as Specialization));

		private void BtnAdd_OnClick(object sender, RoutedEventArgs e) => Manager.Navigate(new SpecializationEditPage());

		private void BtnDelete_OnClick(object sender, RoutedEventArgs e)
		{
			var itemsForRemoving = DGridSpecialization.SelectedItems.Cast<Specialization>().ToList();
			if(MessageBox.Show($"Вы точно хотите удалить следующие {itemsForRemoving.Count} элементов?", "Удаление", MessageBoxButton.YesNo) != MessageBoxResult.Yes) return;
			ARMEntities.GetContext().Specializations.RemoveRange(itemsForRemoving);
			ARMEntities.GetContext().SaveChanges();
			MessageBox.Show("Данные удалены!");
			DGridSpecialization.ItemsSource = ARMEntities.GetContext().Specializations.ToList();
		}

		private void SpecializationsPage_OnLoaded(object sender, RoutedEventArgs e)
		{
			DGridSpecialization.ItemsSource = ARMEntities.GetContext().Specializations.ToList();
			BtnAdd.Visibility = Data.IsAdmin ? Visibility.Visible : Visibility.Collapsed;
			BtnDelete.Visibility = Data.IsAdmin ? Visibility.Visible : Visibility.Collapsed;
			CellEdit.Visibility = Data.IsAdmin ? Visibility.Visible : Visibility.Collapsed;
		}
	}
}
