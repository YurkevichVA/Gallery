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

namespace GalleryWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new PhotoVM(@"..\..\..\Gallery");
        }

        private void toStartBtn_Click(object sender, RoutedEventArgs e)
        {
            PhotoVM viewModel = (PhotoVM)DataContext;
            viewModel.SelectedPhoto = viewModel.Photos[0];
            selectRate(viewModel);
        }

        private void toEndBtn_Click(object sender, RoutedEventArgs e)
        {
            PhotoVM viewModel = (PhotoVM)DataContext;
            viewModel.SelectedPhoto = viewModel.Photos[viewModel.Photos.Count - 1];
            selectRate(viewModel);
        }

        private void nextBtn_Click(object sender, RoutedEventArgs e)
        {
            PhotoVM viewModel = (PhotoVM)DataContext;
            if(viewModel.Photos.IndexOf(viewModel.SelectedPhoto) < viewModel.Photos.Count - 1)
                viewModel.SelectedPhoto = viewModel.Photos[viewModel.Photos.IndexOf(viewModel.SelectedPhoto) + 1];
            selectRate(viewModel);
        }

        private void prevBtn_Click(object sender, RoutedEventArgs e)
        {
            PhotoVM viewModel = (PhotoVM)DataContext;
            if (viewModel.Photos.IndexOf(viewModel.SelectedPhoto) > 0)
                viewModel.SelectedPhoto = viewModel.Photos[viewModel.Photos.IndexOf(viewModel.SelectedPhoto) - 1];
            selectRate(viewModel);
        }
        private void selectRate(PhotoVM viewModel)
        {
            switch (viewModel.Rate)
            {
                case 1: oneRB.IsChecked = true; break;
                case 2: twoRB.IsChecked = true; break;
                case 3: threeRB.IsChecked = true; break;
                case 4: fourRB.IsChecked = true; break;
                case 5: fiveRB.IsChecked = true; break;
                default:
                    oneRB.IsChecked = false;
                    twoRB.IsChecked = false;
                    threeRB.IsChecked = false;
                    fourRB.IsChecked = false;
                    fiveRB.IsChecked = false;
                    break;
            }
        }

        private void changeRate_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton radio = (RadioButton)sender;
            PhotoVM viewModel = (PhotoVM)DataContext;
            int? rate = null;
            switch (radio.Name)
            {
                case "oneRB": rate = 1; break;
                case "twoRB": rate = 2; break;
                case "threeRB": rate = 3; break;
                case "fourRB": rate = 4; break;
                case "fiveRB": rate = 5; break;
            }
            if (rate != null)
                viewModel.Rate = rate;
        }
    }
}
