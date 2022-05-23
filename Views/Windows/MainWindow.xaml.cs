using ScheduleWPF.Classes;
using ScheduleWPF.Pages;
using System;
using System.Windows;
using System.Windows.Input;
using MaterialDesignThemes.Wpf;
using ScheduleWPF.Views.Pages;

namespace ScheduleWPF
{
	/// <summary>
	/// Логика взаимодействия для MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			Manager.MainFrame = MainFrame;
			Manager.Navigate(new AuthPage());
			MyCommand.InputGestures.Add(new KeyGesture(Key.Down, ModifierKeys.Alt));
		}

		private void MainFrame_ContentRendered(object sender, EventArgs e)
		{
			IconBack.Kind = Manager.MainFrame.Content.ToString().Contains("Menu") ? PackIconKind.ExitToApp : PackIconKind.ArrowLeft;
			BtnBack.Visibility = Manager.MainFrame.CanGoBack ? Visibility.Visible : Visibility.Collapsed;
		}
		private void ButtonBase_OnClick(object sender, RoutedEventArgs e) => Manager.GoBack();
		public static RoutedCommand MyCommand = new RoutedCommand();

		private void MyCommandExecuted(object sender, ExecutedRoutedEventArgs e)
		{
			if (!Manager.MainFrame.Content.ToString().Contains("RegPage")) return;
			MessageBox.Show("Вы вошли как админ!");
			Data.Access = 4;
			Manager.Navigate(new Menu());
		}
	}
}
