using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using XAML_podstawy_sb2.Klasy;

//Szablon elementu Pusta strona jest udokumentowany na stronie https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x415

namespace XAML_podstawy_sb2
{
    /// <summary>
    /// Pusta strona, która może być używana samodzielnie lub do której można nawigować wewnątrz ramki.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        List<Osoba> listaOsob = new List<Osoba>();

        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void ZapiszBtn_Click(object sender, RoutedEventArgs e)
        {
            Osoba osoba1 = new Osoba();

            osoba1.Imie = ImieTbx.Text;
            osoba1.Nazwisko = NazwiskoTbx.Text;


            var wiadomosc = new ContentDialog
            {
                Title = osoba1.ToString(),
                Content = "Twoje dane zostały zapisane tymczasowo\nMożesz teraz dodawać kolejne osoby\n\nGdy skończysz kliknij Zapisz do XML",
                CloseButtonText = "OK"
            };

            listaOsob.Add(osoba1);

            

            await wiadomosc.ShowAsync();

            ImieTbx.Text = "";
            NazwiskoTbx.Text = "";

            ImieTbx.Focus(FocusState.Programmatic);
        }

        private void ZapiszDoXmlBtn_Click(object sender, RoutedEventArgs e)
        {
            var sciezka = ApplicationData.Current.LocalFolder.Path;

            XmlManager.SerializujDoXML(listaOsob, sciezka + "\\osoby.xml");
        }
    }
}
