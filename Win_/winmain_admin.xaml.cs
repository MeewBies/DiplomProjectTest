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
    /// Логика взаимодействия для winmain_admin.xaml
    /// </summary>
    public partial class winmain_admin : Window
    {
        public winmain_admin()
        {
            InitializeComponent();
            DB.NedDB NDB = new DB.NedDB();
            LVadmin.ItemsSource = NDB.Сотрудники.ToList();
        }
    }
}
