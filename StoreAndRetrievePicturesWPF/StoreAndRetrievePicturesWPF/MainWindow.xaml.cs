using Microsoft.Win32;
using StoreAndRetrievePicturesWPF.Model;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace StoreAndRetrievePicturesWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Store_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DB db = new DB();
                User user = new User();
                user.ImagePath = txtpicture.Text;
                user.ImageToByte = File.ReadAllBytes(txtpicture.Text);
                user.Nom = txtname.Text;
                user.Prenom = txtprenom.Text;
                user.Tel = txttel.Text;
                user.Fonction = txtfonction.Text;
                db.Users.Add(user);
                db.SaveChanges();

                image1.Source = null;
                txtfonction.Text = "";
                txtname.Text = "";
                txtprenom.Text = "";
                txttel.Text = "";
            }
            catch (Exception)
            {
                MessageBox.Show("Veuillez saisir les donnees !!");
            }
           
           
        }

        private void Browse_Click(object sender, RoutedEventArgs e)
        {
            DB db = new DB();
            User user = new User();
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.ShowDialog();
            openFileDialog1.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif";
            openFileDialog1.DefaultExt = ".jpeg";
            txtpicture.Text = openFileDialog1.FileName;
            ImageSource imageSource = new BitmapImage(new Uri(txtpicture.Text));
            image1.Source = imageSource;
        }

        private void Retrieve_Click(object sender, RoutedEventArgs e)
        {
            DB db = new DB();
            User user = new User();
            var result = (from t in db.Users
                          where t.ImagePath == txtpicture.Text
                          select t).FirstOrDefault();
            Stream StreamObj = new MemoryStream(result.ImageToByte);
            BitmapImage BitObj = new BitmapImage();
            BitObj.BeginInit();
            BitObj.StreamSource = StreamObj;
            BitObj.EndInit();
            this.image1.Source = BitObj;

            txtfonction.Text = result.Fonction;
            txtname.Text = result.Nom;
            txtprenom.Text = result.Prenom;
            txttel.Text = result.Tel;

        }
    }
}
