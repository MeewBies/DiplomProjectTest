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
    using System.IO;
    using System.Windows.Media.Imaging;

    public partial class Студенты
    {
        public int ID { get; set; }
        public string ФИО { get; set; }
        public Nullable<System.DateTime> Дата_рождения { get; set; }
        public Nullable<int> ID_Группы { get; set; }
        public Nullable<int> ID_Статус_студента { get; set; }
        public Nullable<int> ID_Форма_обучения { get; set; }
        public Nullable<System.DateTime> Дата_зачисления { get; set; }
        public Nullable<System.DateTime> Дата_выбытия { get; set; }
        public string Номер_телефона { get; set; }
        public byte[] Изображение { get; set; }

        public virtual Группы Группы { get; set; }
        public virtual Статус_студента Статус_студента { get; set; }
        public virtual Форма_обучения Форма_обучения { get; set; }

        // Пользовательские свойства
        public BitmapImage _Контент
        {
            get
            {
                byte[] imageBytes = Изображение; // здесь вы должны указать нужный вам идентификатор
                if (imageBytes != null && imageBytes.Length > 0)
                {
                    using (MemoryStream stream = new MemoryStream(imageBytes))
                    {
                        BitmapImage image = new BitmapImage();
                        image.BeginInit();
                        image.CacheOption = BitmapCacheOption.OnLoad;
                        image.StreamSource = stream;
                        image.EndInit();
                        return image;
                    }
                }
                return null;
            }
            set { }
        }


    }
}
