using EsqLabsSln.Models;
using EsqLabsSln.ViewModels;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace EsqLabsTests
{
    public class PairViewModelTests
    {
        private PairViewModel _viewModel;

        [SetUp]
        public void Setup()
        {
            _viewModel = new PairViewModel();
            _viewModel.PairsCollection = new ObservableCollection<Pair>()
            {
                new Pair("Plane", "Airbus"),
                new Pair("Plane", "Jet120"),
                new Pair("Plane", "G598"),
                new Pair("Plane", "CTSF"),
                new Pair("Moto", "Harlley"),
                new Pair("Moto", "R1"),
                new Pair("Moto", "Cross"),
                new Pair("Moto", "Quad")
            };
        }


        [TestCase("plane", false, 8)]
        [TestCase("plane123", false, 8)]
        [TestCase("123=", false, 8)]
        [TestCase("plane,", false, 8)]
        [TestCase("Boat = Yocht", true, 9)]
        [Test]
        public void TestAddPair(string text, bool expAddition, int pairsCount)
        {
            bool additionResult = _viewModel.AddPair(text);
            Assert.AreEqual(expAddition, additionResult);
            Assert.AreEqual(_viewModel.PairsCollection.Count, pairsCount);
        }

        [TestCase(2, 6)]
        [TestCase(3, 5)]
        [TestCase(1, 7)]
        [TestCase(8, 0)]
        [Test]
        public void TestRemovePair(int pairNumbers, int pairsCount)
        {
            for (int i = 0; i < pairNumbers; i++)
            {
                Pair p = _viewModel.PairsCollection[0];
                _viewModel.RemovePair(p);

            }
            Assert.AreEqual(_viewModel.PairsCollection.Count, pairsCount);
        }

        [TestCase(new int[] { 1, 3 }, 6)]
        [TestCase(new int[] { 1, 2, 3 }, 5)]
        [TestCase(new int[] { 3 }, 7)]
        [TestCase(new int[] { 0, 1, 2, 3, 4, 5, 6, 7 }, 0)]
        [Test]
        public void TestRemoveManyPairs(int[] pairIndexs, int pairsCount)
        {
            IList<Pair> lstPairs = new List<Pair>();
            
            for (int i = 0; i < pairIndexs.Length; i++)
            {
                Pair p = _viewModel.PairsCollection[i];
                lstPairs.Add(p);

            }

            _viewModel.RemoveManyPairs(lstPairs);
            Assert.AreEqual(_viewModel.PairsCollection.Count, pairsCount);
        }
    }
}
