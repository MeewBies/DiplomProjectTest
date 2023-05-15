using DiplomDimaDen.DB;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.IO;
using System.Reflection;
using System.Resources;

namespace DiplomDimaDen.Win_
{
    /// <summary>
    /// Логика взаимодействия для winadd_student.xaml
    /// </summary>
    public partial class winadd_student : Window
    {

        public static NedDB con = new NedDB();
        public winadd_student()
        {
            InitializeComponent();
            var stud = con.Студенты.FirstOrDefault(i => i.ID == studClass.studID);  // студент для привязки данных
            Img_photo.Source = stud._Контент;
            CB_group.ItemsSource = con.Группы.ToList();
            CB_group.SelectedItem = stud.Группы;
            CB_status.ItemsSource = con.Статус_студента.ToList();
            CB_status.SelectedItem = stud.Статус_студента;
            CB_forma.ItemsSource = con.Форма_обучения.ToList();
            CB_forma.SelectedItem = stud.Форма_обучения;
            DP_Birthhday.SelectedDate = stud.Дата_рождения;
            TB_telefon.Text = stud.Номер_телефона;
            DP_datezacis.SelectedDate = stud.Дата_зачисления;
            DP_datevibit.SelectedDate = stud.Дата_выбытия;
            TB_FIO.Text = stud.ФИО;



        }

        private void AddResource(string resourceName, byte[] imageBytes)
        {
            // Создание менеджера ресурсов
            ResourceManager resourceManager = new ResourceManager("MyNamespace.MyResourceFile", Assembly.GetExecutingAssembly());

            // Сохранение ресурса
            using (ResourceWriter resourceWriter = new ResourceWriter("MyResourceFile.resx"))
            {
                resourceWriter.AddResource(resourceName, imageBytes);
                resourceWriter.Generate();
            }
        }

        private void Btn_Pick_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var stud = con.Студенты.FirstOrDefault(i => i.ID == studClass.studID);  // студент для привязки данных

                stud.ID_Группы = ((DB.Группы)CB_group.SelectedItem).ID;
                stud.ID_Форма_обучения = ((DB.Форма_обучения)CB_forma.SelectedItem).ID;
                stud.ID_Статус_студента = ((DB.Статус_студента)CB_status.SelectedItem).ID;

                stud.Дата_рождения = DP_Birthhday.SelectedDate;
                stud.Номер_телефона = TB_telefon.Text;
                stud.Дата_зачисления = DP_datezacis.SelectedDate;
                stud.Дата_выбытия = DP_datevibit.SelectedDate;
                stud.ФИО = TB_FIO.Text;
                con.SaveChanges();
                NedDB NDB = new NedDB();
                //LVsotrdnik.ItemsSource = NDB.Студенты.ToList();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Ошибка", ex.Message);
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var NBD = new DB.NedDB();
            var selection_gp = CB_group.SelectedItem as Группы;
        }

        private void CB_status_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var NBD = new DB.NedDB();
            var selection_gp = CB_status.SelectedItem as Статус_студента;
        }

        private void CB_forma_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var NBD = new DB.NedDB();
            var selection_gp = CB_forma.SelectedItem as Форма_обучения;
        }
    }
}
