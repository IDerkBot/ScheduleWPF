using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using ScheduleWPF.Models;
using ScheduleWPF.Models.Entity;

namespace ScheduleWPF.Views.Pages
{
    /// <summary>
    /// Логика взаимодействия для SchedulePage.xaml
    /// </summary>
    public partial class SchedulePage : Page
    {
        public SchedulePage()
        {
            InitializeComponent();
        }
        // TODO Made all
        private void SchedulePage_OnLoaded(object sender, RoutedEventArgs e)
        {
            //DGridSchedule.ItemsSource = ARMEntities.GetContext().Schedules.ToList();
            var schedules = new List<ScheduleGroup>();
            //получить список всего расписания на сегодня
            var nowDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            var scheduleToday = ARMEntities.GetContext().Schedules.Where(x => x.Date == nowDate).ToList();
            if(scheduleToday.Count == 0) return;
            //получаем список всех групп
            var groups = ARMEntities.GetContext().Groups.ToList();
            groups.ForEach(group =>
            {
                //выбрать уроки для группы такой то
                var scheduleForGroup = scheduleToday.Where(x => x.Group.Title == group.Title).ToList();
                if(scheduleForGroup.Count == 0) return;
                var sch = new ScheduleGroup
                {
                    Group = group,
                    FirstLesson = scheduleForGroup.Single(x => x.Couple == 1).Lesson,
                    SecondLesson = scheduleForGroup.Single(x => x.Couple == 2).Lesson,
                    ThirdLesson = scheduleForGroup.Single(x => x.Couple == 3).Lesson,
                    FourthLesson = scheduleForGroup.Single(x => x.Couple == 4).Lesson,
                };
                schedules.Add(sch);
            });
            LvSchedule.ItemsSource = schedules;
        }
    }
    public class WorkDay
    {
        public int IDGroup;

    }
}
