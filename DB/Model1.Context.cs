﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class NedDB : DbContext
    {
        public NedDB()
            : base("name=NedDB")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Группы> Группы { get; set; }
        public virtual DbSet<Заявки> Заявки { get; set; }
        public virtual DbSet<Преподаватель> Преподаватель { get; set; }
        public virtual DbSet<Сотрудники> Сотрудники { get; set; }
        public virtual DbSet<Специальности> Специальности { get; set; }
        public virtual DbSet<Статус_заявки> Статус_заявки { get; set; }
        public virtual DbSet<Статус_студента> Статус_студента { get; set; }
        public virtual DbSet<Студенты> Студенты { get; set; }
        public virtual DbSet<Тип_сотрудника> Тип_сотрудника { get; set; }
        public virtual DbSet<Форма_обучения> Форма_обучения { get; set; }
    }
}
