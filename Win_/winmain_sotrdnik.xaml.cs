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
            DB.NedDB NDB = new DB.NedDB();
            LVsotrdnik.ItemsSource = NDB.Студенты.ToList();
        }
    }
}
