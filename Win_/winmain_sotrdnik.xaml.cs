using DiplomDimaDen.DB;
using System;
using System.Collections.Generic;
using System.Linq;
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
using System.Data.Entity;
using System.Diagnostics.Contracts;
using System.Windows.Media.Media3D;

namespace DiplomDimaDen.Win_
{
    /// <summary>
    /// Логика взаимодействия для winmain_sotrdnik.xaml
    /// </summary>
    public partial class winmain_sotrdnik : Window
    {
        public winmain_sotrdnik()
        {
            InitializeComponent();
            NedDB NDB = new NedDB();
            LVsotrdnik.ItemsSource = NDB.Студенты.ToList();

        }

        private void Btn_Del_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (MessageBox.Show($"Действительно хотите удалить данные?",
                "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    NedDB NDB = new DB.NedDB();
                    int removeId = (LVsotrdnik.SelectedItem as Студенты).ID;
                    var removeStudent = NDB.Студенты.FirstOrDefault(i => i.ID == removeId);
                    NDB.Студенты.Remove(removeStudent);
                    NDB.SaveChanges();
                    MessageBox.Show("Данные удалены!");

                    LVsotrdnik.ItemsSource = NDB.Студенты.ToList();
                }
                else
                {
                    MessageBox.Show("Ошибка.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void Btn_Edit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var ID = LVsotrdnik.SelectedItem as DB.Студенты;
                Edit_class.ID = ID.ID;
                winadd_student ad = new winadd_student();
                ad.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void LVsotrdnik_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                NedDB NDB = new DB.NedDB();
                int removeID = (LVsotrdnik.SelectedItem as Студенты).ID;
                var removeStud = NDB.Студенты.FirstOrDefault(i => i.ID == removeID);
                if (removeStud != null)
                {
                    studClass.studID = removeStud.ID;
                    winadd_student winst = new winadd_student();
                    winst.Show();
                }
                else
                {
                    MessageBox.Show("Ошибка!");
                }
            }
            catch
            {
                
            }
        }

        private void tb_search_TextChanged(object sender, TextChangedEventArgs e)
        {
            var BDB = new DB.NedDB();
            var search = BDB.Студенты.ToList();
            search = search.Where(i => i.ФИО.Contains(tb_search.Text)).ToList();
            LVsotrdnik.ItemsSource = search.OrderBy(p => p.ФИО).ToList();
        }

        private void Btn_add_Click(object sender, RoutedEventArgs e)
        {
            winRealaddStud wi = new winRealaddStud();
            wi.Show();
            Close();
        }

        private void refresh_Click(object sender, RoutedEventArgs e)
        {
            NedDB NDB = new NedDB();
            LVsotrdnik.ItemsSource = NDB.Студенты.ToList();
        }
    }
}
