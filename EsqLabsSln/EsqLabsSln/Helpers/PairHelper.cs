using EsqLabsSln.DataTypes.Enum;
using EsqLabsSln.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace EsqLabsSln.Helpers
{
    public static class PairHelper
    {
        #region Constants

        public const string RegexStr = "^[a-zA-Z0-9]*$";

        #endregion

        #region Methods

        //Check if the pair is hidden or not by the filter
        public static bool FilterPair(Pair pair, string filter)
        {
            if (string.IsNullOrEmpty(filter))
            {
                return true;
            }

            var dispatchedFilter = filter.Split('=');

            if (MatchFilterType(dispatchedFilter, out PairFilterEnum filterType))
            {
                if (filterType == PairFilterEnum.name)
                {
                    return pair.NamePair.ToLower() == dispatchedFilter[1].ToLower().Trim();
                }

                return pair.ValuePair.ToLower() == dispatchedFilter[1].ToLower().Trim();
            }

            return false;
        }

        public static bool ValidFormat(string txtValue)
        {
            Regex re = new Regex(RegexStr);

            if (!string.IsNullOrEmpty(txtValue) && re.IsMatch(txtValue))
            {
                return true;
            }

            return false;
        }

        //Check if the filter in a valid Format
        public static bool ValidFilterFormat(string filter)
        {
            var dispatchedFilter = filter.Split('=');

            if (MatchFilterType(dispatchedFilter, out _))
            {
                return true;
            }

            return false;
        }

        private static bool MatchFilterType(string[] dispatchedFilter, out PairFilterEnum filterType)
        {
            filterType = 0;
            return dispatchedFilter.Length == 2 && 
                Enum.TryParse(dispatchedFilter[0].ToLower().Trim(), out filterType) &&
                !string.IsNullOrEmpty(dispatchedFilter[1].ToLower().Trim());
        }

        #endregion
    }
}
