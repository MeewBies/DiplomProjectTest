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
            var NBD = new DB.NedDB();
            CB_group.SelectedIndex = 0;
            CB_group.ItemsSource = NBD.Группы.ToList();
        }

        private void Btn_Pick_Click(object sender, RoutedEventArgs e)
        {
            //try
            //{
            //    //OpenFileDialog fileDialog = new OpenFileDialog();
            //    //fileDialog.Filter = "Image files (*.JPG, *.PNG)|*.jpg;*.png;";
            //    //if(fileDialog.ShowDialog() == true)
            //    //{
            //    //    string fileName = fileDialog.FileName;
            //    //    imagelogh.Source = new BitmapImage(new Url(fileName));
            //    //    path = fileName;
            //    //}
            //}
            //catch(Exception ex)
            //{
            //    MessageBox.Show(ex.Message.ToString());
            //}     
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var NBD = new DB.NedDB();
            var selection_gp = CB_group.SelectedItem as Группы;
        }

        private void CB_status_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void CB_forma_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
