using EsqLabsSln.Models;
using EsqLabsSln.ViewModels;
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

namespace EsqLabsSln
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private readonly PairViewModel _viewModel;

        public MainWindow()
        {
            InitializeComponent();
            _viewModel = new PairViewModel();
            DataContext = _viewModel;
        }

        private void btnAddPair_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtPairCriteria.Text))
            {
                MessageBox.Show("Please fill the field !");
            }
            else if (!_viewModel.AddPair(txtPairCriteria.Text))
            {
                MessageBox.Show("Pair should be alpha-numeric in this Format 'Name' = 'Value' !");
            }
        }

        private void btnFilterPairs_Click(object sender, RoutedEventArgs e)
        {
            if (!_viewModel.PairFilterValid(txtPairCriteria.Text))
            {
                MessageBox.Show("Filter Format should be <Name/Value> = 'Filter Value' !");
            }
            else
            {
                _viewModel.UpdatePairFilter(txtPairCriteria.Text);
            }
        }

        private void btnClearFilterPair_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.UpdatePairFilter(string.Empty);
            txtPairCriteria.Text = string.Empty;
        }

        private void btnSortByName_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.SortPairsByName();
        }

        private void btnSortByValue_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.SortPairsByValue();
        }

        private void btnDeletePair_Click(object sender, RoutedEventArgs e)
        {
            var selectedPairs = lstPairs.SelectedItems.Cast<Pair>().ToList();
            _viewModel.RemoveManyPairs(selectedPairs);
        }
    }
}
