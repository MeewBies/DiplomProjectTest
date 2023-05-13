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
using System.IO;
using System.Reflection;
using System.Resources;

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

        private void Btn_Pick_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog fileDialog = new OpenFileDialog();
                fileDialog.Filter = "Image files (*.JPG, *.PNG)|*.jpg;*.png*";

                if (fileDialog.ShowDialog() == true)
                {
                    string fileName = fileDialog.FileName;
                    string fullName = Path.GetFileName(fileName);

                    Img_photo.Source = new BitmapImage(new Uri(fileName));
                    MessageBox.Show(fileName);

                    string path = Path.Combine(Environment.CurrentDirectory, "Images", "Student", fullName);

                    // Копирование файла в папку проекта
                    File.Copy(fileName, path);

                    // Загрузка изображения
                    BitmapImage bitmapImage = new BitmapImage();
                    bitmapImage.BeginInit();
                    bitmapImage.UriSource = new Uri(path);
                    bitmapImage.EndInit();

                    // Конвертация BitmapImage в byte[]
                    byte[] imageBytes;
                    JpegBitmapEncoder encoder = new JpegBitmapEncoder();
                    encoder.Frames.Add(BitmapFrame.Create(bitmapImage));
                    using (MemoryStream ms = new MemoryStream())
                    {
                        encoder.Save(ms);
                        imageBytes = ms.ToArray();
                    }

                    AddResource(fullName, imageBytes);
                }
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
