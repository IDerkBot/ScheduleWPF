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
    
    public partial class LessonTeacher
    {
        public int IDLesson { get; set; }
        public int CodeTeacher { get; set; }
        public bool IsPractice { get; set; }
    
        public virtual Lesson Lesson { get; set; }
        public virtual Teacher Teacher { get; set; }
    }
}
