using DiplomDimaDen.Win_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.Windows.Threading;

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
            Pimer.Tick += new EventHandler(_Tick);
        }
        int count = 0;
        DispatcherTimer Pimer = new DispatcherTimer() { Interval = new TimeSpan(0, 0, 10) };

        private void Btn_Vhod_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DB.NedDB NDB = new DB.NedDB();
                var users = NDB.Сотрудники.FirstOrDefault(i => i.Логин == tb_log.Text ||
                i.Эл_почта == tb_log.Text && i.Пароль == tb_pas.Text);
                if (users != null)
                {
                    if(users.ID_Тип_сотрудника == 1)
                    {
                        MessageBox.Show("Успешный вход как Администратор.");
                        winmain_admin WinAd = new winmain_admin();
                        SotClass.SotID = users.ID;
                        WinAd.Show();
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("Успешный вход как Сотрудник.");
                        winmain_sotrdnik WinSot = new winmain_sotrdnik();
                        SotClass.SotID = users.ID;
                        WinSot.Show();
                        Close();
                    }    
                }
               else
               {
                    MessageBox.Show($"Введены неверные данные! Осталось попыток ({5 - count})");
                    count++;
                    if(count > 5)
                    {
                        Btn_Vhod.IsEnabled = false;
                        Pimer.Start();
                        Btn_Vhod.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#FFFF8074");
                        MessageBox.Show("Превышен лимит входа. Повторите попытку позже.");
                    }
               }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }      
        }

       private void _Tick(object sender, EventArgs e)
        {
            Pimer.Stop();
            Btn_Vhod.Background = (SolidColorBrush)new BrushConverter().ConvertFromString("#FFC8F9A7");
            Btn_Vhod.IsEnabled = true;
            count = 0;
       }

        private void HLreg_Click(object sender, RoutedEventArgs e)
        {
            AccRecovery ARwin = new AccRecovery();
            ARwin.Show();
        }
    }
}
