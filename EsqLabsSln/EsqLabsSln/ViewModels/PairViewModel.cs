using EsqLabsSln.Converters;
using EsqLabsSln.Helpers;
using EsqLabsSln.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Data;

namespace EsqLabsSln.ViewModels
{
    public class PairViewModel
    {
        #region Member

        private ObservableCollection<Pair> _pairsCollection;
        private ICollectionView _pairsView;
        private string _pairFilter;

        #endregion

        #region Properties

        public ObservableCollection<Pair> PairsCollection
        {
            get
            {
                return _pairsCollection;
            }
            set
            {
                _pairsCollection = value;
            }
        }

        public ICollectionView PairView
        {
            get
            {
                _pairsView = CollectionViewSource.GetDefaultView(_pairsCollection);
                _pairsView.Filter = FilterPairsView;
                return _pairsView;
            }
        }

        public string PairFilter
        {
            get
            {
                return _pairFilter;
            }
            set
            {
                _pairFilter = value;
                _pairsView.Refresh();
            }
        }

        #endregion

        #region Construction

        public PairViewModel()
        {
            _pairsCollection = new ObservableCollection<Pair>();
            _pairFilter = string.Empty;
        }

        public void UpdatePairFilter(string textBoxValue)
        {
            PairFilter = textBoxValue;
        }

        public bool PairFilterValid(string textBoxValue)
        {
            return PairHelper.ValidFilterFormat(textBoxValue);
        }

        #endregion

        #region Methods

        private bool FilterPairsView(object item)
        {
            Pair pair = item as Pair;
            return PairHelper.FilterPair(pair, _pairFilter);
        }

        public bool AddPair(string txtBoxValue)
        {
            if (PairConverter.TryParse(txtBoxValue, out Pair pairToAdd))
            {
                _pairsCollection.Add(pairToAdd);
                return true;
            }
            return false;
        }

        public void RemovePair(Pair pair)
        {
            _pairsCollection.Remove(pair);
        }

        public void RemoveManyPairs(IList<Pair> selectedPairs)
        {
            foreach (var pair in selectedPairs)
            {
                RemovePair(pair);
            }
        }

        public void SortPairsByName()
        {
            _pairsView.SortDescriptions.Clear();
            _pairsView.SortDescriptions.Add(new SortDescription("NamePair", ListSortDirection.Ascending));
        }
        
        public void SortPairsByValue()
        {
            _pairsView.SortDescriptions.Clear();
            _pairsView.SortDescriptions.Add(new SortDescription("ValuePair", ListSortDirection.Ascending));
        }

        #endregion

    }
}
