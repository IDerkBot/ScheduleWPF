using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ScheduleWPF.Models;
using ScheduleWPF.Models.Entity;

namespace ScheduleWPF.Views.Pages.EditPages
{
    /// <summary>
    /// Логика взаимодействия для ScheduleEditPage.xaml
    /// </summary>
    public partial class ScheduleEditPage : Page
    {
        private readonly ScheduleGroup _currentScheduleGroup;

        public ScheduleEditPage()
        {
            InitializeComponent();
            CbGroups.ItemsSource = ARMEntities.GetContext().Groups.ToList();
            CbFirstLesson.ItemsSource = ARMEntities.GetContext().Lessons.ToList();
            CbSecondLesson.ItemsSource = ARMEntities.GetContext().Lessons.ToList();
            CbThirdLesson.ItemsSource = ARMEntities.GetContext().Lessons.ToList();
            CbFourthLesson.ItemsSource = ARMEntities.GetContext().Lessons.ToList();
            _currentScheduleGroup = new ScheduleGroup();
            DataContext = _currentScheduleGroup;
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            ARMEntities.GetContext().Schedules.Add(new Schedule
            {
                Group = _currentScheduleGroup.Group,
                Date = DateTime.Now,
                Classroom = ARMEntities.GetContext().Classrooms.Single(x => x.Number == 11),
                Couple = 1,
                Lesson = _currentScheduleGroup.FirstLesson
            });
            ARMEntities.GetContext().Schedules.Add(new Schedule
            {
                Group = _currentScheduleGroup.Group,
                Date = DateTime.Now,
                Classroom = ARMEntities.GetContext().Classrooms.Single(x => x.Number == 11),
                Couple = 2,
                Lesson = _currentScheduleGroup.SecondLesson
            });
            ARMEntities.GetContext().Schedules.Add(new Schedule
            {
                Group = _currentScheduleGroup.Group,
                Date = DateTime.Now,
                Classroom = ARMEntities.GetContext().Classrooms.Single(x => x.Number == 11),
                Couple = 3,
                Lesson = _currentScheduleGroup.ThirdLesson
            });
            ARMEntities.GetContext().Schedules.Add(new Schedule
            {
                Group = _currentScheduleGroup.Group,
                Date = DateTime.Now,
                Classroom = ARMEntities.GetContext().Classrooms.Single(x => x.Number == 11),
                Couple = 4,
                Lesson = _currentScheduleGroup.FourthLesson
            });
            ARMEntities.GetContext().SaveChanges();
        }
    }
}
