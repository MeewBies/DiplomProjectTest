//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DiplomDimaDen.DB
{
    using System;
    using System.Collections.Generic;
    
    public partial class Сотрудники
    {
        public int ID { get; set; }
        public string ФИО { get; set; }
        public string Эл_почта { get; set; }
        public string Номер_телефона { get; set; }
        public string Логин { get; set; }
        public string Пароль { get; set; }
        public Nullable<int> ID_Тип_сотрудника { get; set; }
        public string Изображение { get; set; }
    
        public virtual Тип_сотрудника Тип_сотрудника { get; set; }
    }
}
