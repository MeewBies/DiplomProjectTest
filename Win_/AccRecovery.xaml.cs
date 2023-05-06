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
using System.Net;
using System.Net.Mail;

namespace DiplomDimaDen.Win_
{
    /// <summary>
    /// Логика взаимодействия для AccRecovery.xaml
    /// </summary>
    public partial class AccRecovery : Window
    {
        public AccRecovery()
        {
            InitializeComponent();
        }

        string pas = "";
        int mailacc;

        private void Btn_rec_Click(object sender, RoutedEventArgs e)
        {
            DB.NedDB NDB = new DB.NedDB();
            var mail = NDB.Сотрудники.FirstOrDefault(i => i.Эл_почта == tb_rec.Text);
            if (mail != null)
            {
            mailacc = mail.ID;
            int length = 5;
            const string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            StringBuilder res = new StringBuilder();
            Random rnd = new Random();
            while (0 < length--)
            {
                res.Append(valid[rnd.Next(valid.Length)]);
            }
            pas = res.ToString();
            

            MailAddress MAfrom = new MailAddress("k_aguero@list.ru", "Учет оучающихся колледжа");
            MailAddress to = new MailAddress(tb_rec.Text);
            MailMessage m = new MailMessage(MAfrom, to);
            m.Subject = "Восстановление доступа.";
            m.Body = $"<h2>Код восстановления пароля : {pas}</h2>";
            m.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient("smtp.mail.ru", 2525);
            smtp.Credentials = new NetworkCredential("k_aguero@list.ru", "DFH10VkWEttxTW5QdP5e");
            smtp.EnableSsl = true;
            smtp.Send(m);
            Console.Read();
            MessageBox.Show($"Сообщение с кодом было отправлено на {tb_rec.Text}");
        }
        else
        {
            MessageBox.Show("Ошибка!");
        }
    }

        private void BtnAcp_ac_Click(object sender, RoutedEventArgs e)
        {
            if(tb_cod.Text == pas)
            {
                tb_izpas.IsEnabled = true;
                BtnEdit_ac.IsEnabled = true;
            }
            else
            {
                MessageBox.Show("Неверный код.");
            }
        }

        private void BtnEdit_ac_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DB.NedDB NDB = new DB.NedDB();
                var user = NDB.Сотрудники.FirstOrDefault(i => i.ID == mailacc);
                user.Пароль = tb_izpas.Text;
                NDB.SaveChanges();
                MessageBox.Show("Пароль был изменён.");
                Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
