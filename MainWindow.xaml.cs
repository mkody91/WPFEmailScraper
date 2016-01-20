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

namespace WpfEmailScraper
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SiteEmailScraper scraper = new SiteEmailScraper();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ScrapeEmailsButton_Click(object sender, RoutedEventArgs e)
        {
            //Get Contents of URLTextBox
            var URL = URLTextBox.Text;

            //Clear the EmailScraper Results
            scraper.Results.Clear();

            //Scrape the input URL
            scraper.Scrape(URL);

            //Put Results in the ResultsListBox
            ResultsListBox.ItemsSource = scraper.Results;

            //Refresh the ListBox
            ResultsListBox.Items.Refresh();
            
        }

        private void URLTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            URLTextBox.Clear();
        }

        private void ClearURLTextBoxButton_Click(object sender, RoutedEventArgs e)
        {
            URLTextBox.Clear();
            URLTextBox.Focus();
        }
    }
}
