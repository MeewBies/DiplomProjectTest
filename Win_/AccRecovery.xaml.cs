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

        private void Btn_rec_Click(object sender, RoutedEventArgs e)
        {
            //DB.NedDB NDB = new DB.NedDB();
            //var mail = NDB.Сотрудники.FirstOrDefault(i => i.Эл_почта == tb_rec.Text);
            //if(mail != null)
            //{
                MailAddress MAfrom = new MailAddress("k_aguero@list.ru", "Учет оучающихся колледжа");
                MailAddress to = new MailAddress(tb_rec.Text);
                MailMessage m = new MailMessage(MAfrom, to);
                m.Subject = "Восстановление доступа.";
                m.Body = "<h2>Код восстановления</h2>";
                m.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient("smtp.mail.ru", 2525);
                smtp.Credentials = new NetworkCredential("k_aguero@list.ru", "DFH10VkWEttxTW5QdP5e");
                smtp.EnableSsl = true;
                smtp.Send(m);
                Console.Read();
                MessageBox.Show($"Сообщение с кодом было отправлено на {tb_rec.Text}");
            //}
            //else
            //{
            //    MessageBox.Show("Ошибка!");
            //}
        }
    }
}
