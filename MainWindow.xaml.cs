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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DiplomDimaDen
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Btn_Vhod_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int d = 5;
                DB.NedDB NDB = new DB.NedDB();
                var users = NDB.Сотрудники.FirstOrDefault(i => i.Логин == tb_log.Text || i.Эл_почта == tb_log.Text && i.Пароль == tb_pas.Text);
                if (users != null)
                {
                    MessageBox.Show("Успешный вход в систему.");
                }
                else if(users == null && d < 6)
                {
                    MessageBox.Show("Введены неверные данные!");
                }
                else
                {
                    MessageBox.Show("Блокировка!");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }      
        }
    }
}
