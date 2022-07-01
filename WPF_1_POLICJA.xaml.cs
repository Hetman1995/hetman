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
                           select p;
            foreach (var item in policjas)
            {
                Console.WriteLine(item.Imie);
                Console.WriteLine(item.Nazwisko);
                Console.WriteLine(item.Rok_urodzenia);

            }
        }
    }
}
