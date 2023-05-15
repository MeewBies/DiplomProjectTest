using DiplomDimaDen.DB;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Shapes;

namespace DiplomDimaDen.Win_
{
    /// <summary>
    /// Логика взаимодействия для winRealaddStud.xaml
    /// </summary>
    public partial class winRealaddStud : Window
    {
        public winRealaddStud()
        {
            InitializeComponent();
            var NBD = new NedDB();
            CB_group.ItemsSource = NBD.Группы.ToList();
            CB_status.ItemsSource = NBD.Статус_студента.ToList();
            CB_forma.ItemsSource = NBD.Форма_обучения.ToList();
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

        private void Btn_Pick_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DB.NedDB con = new NedDB();
                var stud = new DB.Студенты();

                stud.ФИО = TB_FIO.Text;

                stud.ID_Группы = ((DB.Группы)CB_group.SelectedItem).ID;
                stud.ID_Форма_обучения = ((DB.Форма_обучения)CB_forma.SelectedItem).ID;
                stud.ID_Статус_студента = ((DB.Статус_студента)CB_status.SelectedItem).ID;

                stud.Номер_телефона = TB_telefon.Text;
                stud.Дата_зачисления = DP_datezacis.SelectedDate;
                stud.Дата_рождения = DP_Birthhday.SelectedDate;
                stud.Дата_выбытия = DP_datevibit.SelectedDate;
                var imaga = con.Студенты.FirstOrDefault(i => i.ID == 5);
                stud.Изображение = imaga.Изображение;
                con.Студенты.Add(stud);
                con.SaveChanges();
                winmain_sotrdnik win = new winmain_sotrdnik();
                win.Show();
                Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}