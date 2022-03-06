﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ScheduleWPF.Entity
{
	using System;
	using System.Data.Entity;
	using System.Data.Entity.Infrastructure;

	public partial class ARMEntities : DbContext
	{
		private static ARMEntities _ctx;

		public static ARMEntities GetContext()
		{
			if (_ctx == null)
				_ctx = new ARMEntities();
			return _ctx;
		}
		public ARMEntities()
				: base("name=ARMEntities")
		{
		}

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			throw new UnintentionalCodeFirstException();
		}

		public virtual DbSet<Classroom> Classrooms { get; set; }
		public virtual DbSet<Exam> Exams { get; set; }
		public virtual DbSet<Group> Groups { get; set; }
		public virtual DbSet<Holiday> Holidays { get; set; }
		public virtual DbSet<Journal> Journals { get; set; }
		public virtual DbSet<Lesson> Lessons { get; set; }
		public virtual DbSet<LessonSpezialization> LessonSpezializations { get; set; }
		public virtual DbSet<LessonTeacher> LessonTeachers { get; set; }
		public virtual DbSet<Module> Modules { get; set; }
		public virtual DbSet<Schedule> Schedules { get; set; }
		public virtual DbSet<Specialization> Specializations { get; set; }
		public virtual DbSet<Student> Students { get; set; }
		public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
		public virtual DbSet<Teacher> Teachers { get; set; }
		public virtual DbSet<User> Users { get; set; }
	}
}
