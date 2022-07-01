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

namespace hetman
{
    /// <summary>
    /// Logika interakcji dla klasy WPF_1_POLICJA.xaml
    /// </summary>
    public partial class WPF_1_POLICJA : Window
    {
        public WPF_1_POLICJA()
        {
            InitializeComponent();

            KomendaPolicjiDBEntities db = new KomendaPolicjiDBEntities();
            var policjas = from p in db.Policjancis
                           select new
                           {
                               Imie = p.Imie,
                               Nazwisko = p.Nazwisko
                           };
            foreach (var item in policjas)
            {
                Console.WriteLine(item.Imie);
                Console.WriteLine(item.Nazwisko);


            }
            this.gridPolicjanci.ItemsSource = policjas.ToList();

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btnDodaj_Click(object sender, RoutedEventArgs e)
        {

            KomendaPolicjiDBEntities db = new KomendaPolicjiDBEntities();

            Policjanci PolicjaObject = new Policjanci()
            {
                Imie = txtImie.Text,
                Nazwisko = txtNazwisko.Text,
                Rok_urodzenia = txtRok_Urodzenia.Text
            };
            db.Policjancis.Add(PolicjaObject);
            db.SaveChanges();


            
         

        }

        private void btnWczytaj_Click(object sender, RoutedEventArgs e)
        {

            KomendaPolicjiDBEntities db = new KomendaPolicjiDBEntities();
     

            this.gridPolicjanci.ItemsSource = db.Policjancis.ToList();

        }

        private void gridPolicjanci_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Console.WriteLine(this.gridPolicjanci.SelectedItems);


        }

        private void btnZatwierdzZmiane_Click(object sender, RoutedEventArgs e)
        {
            KomendaPolicjiDBEntities db = new KomendaPolicjiDBEntities();

            var r = from p in db.Policjancis
                    where p.Id == 1
                    select p;

            foreach (var item in r)
            {
                MessageBox.Show(item.Imie);
                item.Imie = "Andrzej Zaktualizowany!";

            }
            db.SaveChanges();

        }
    }
}
