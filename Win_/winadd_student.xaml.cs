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
using System.Windows.Shapes;
using System.IO;

namespace DiplomDimaDen.Win_
{
    /// <summary>
    /// Логика взаимодействия для winadd_student.xaml
    /// </summary>
    public partial class winadd_student : Window
    {

        public winadd_student()
        {
            InitializeComponent();
            var NBD = new NedDB();
            CB_group.ItemsSource = NBD.Группы.ToList();
            CB_status.ItemsSource = NBD.Статус_студента.ToList();
            CB_forma.ItemsSource = NBD.Форма_обучения.ToList();

            var stud = new Студенты();
            stud = NBD.Студенты.FirstOrDefault(i => i.ID == studClass.studID);
            string path = Environment.CurrentDirectory + "//" + stud.Изображение;
            MessageBox.Show(path);
            Img_photo.Source = new BitmapImage(new Uri(path));
        }

        private void Btn_Pick_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog fileDialog = new OpenFileDialog();
                fileDialog.Filter = "Image files (*.JPG, *.PNG)|*.jpg;*.png*";
                string fileName = "";
                if (fileDialog.ShowDialog() == true)
                {
                    fileName = fileDialog.FileName;
                    Img_photo.Source = new BitmapImage(new Uri(fileName));
                }
                MessageBox.Show(fileName);
                string path = Environment.CurrentDirectory + $@"\Images\Student\trash.png";
                File.Copy(fileName, path);
                TB_photo.Text = fileName;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
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
