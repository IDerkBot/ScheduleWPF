//------------------------------------------------------------------------------
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
	using System.Collections.Generic;

	public partial class User
	{
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
		public User()
		{
			this.Students = new HashSet<Student>();
			this.Teachers = new HashSet<Teacher>();
		}
		public User(string login, string password)
		{
			this.Students = new HashSet<Student>();
			this.Teachers = new HashSet<Teacher>();
			this.Login = login;
			this.Password = password;
		}

		public int ID { get; set; }
		public string Login { get; set; }
		public string Password { get; set; }
		public byte Access { get; set; }

		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
		public virtual ICollection<Student> Students { get; set; }
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
		public virtual ICollection<Teacher> Teachers { get; set; }
	}
}
