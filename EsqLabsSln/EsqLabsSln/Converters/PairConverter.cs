using EsqLabsSln.Helpers;
using EsqLabsSln.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EsqLabsSln.Converters
{
    public static class PairConverter
    {
        #region Methods

        //Check if the text is in a valid format and create the appropriate pair
        public static bool TryParse(string text, out Pair pair)
        {
            pair = null;
            var dispatchedText = text.Split('=');
            if (dispatchedText.Length == 2)
            {
                string name = dispatchedText[0].Trim();
                string value = dispatchedText[1].Trim();

                if (PairHelper.ValidFormat(name) && PairHelper.ValidFormat(value))
                {
                    pair = new Pair(name, value);
                    return true;
                }
            }
            return false;
        }

        #endregion

    }
}
