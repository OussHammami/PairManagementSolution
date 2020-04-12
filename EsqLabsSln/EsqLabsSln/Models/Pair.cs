using System;
using System.Collections.Generic;
using System.Text;

namespace EsqLabsSln.Models
{
    public class Pair
    {
        #region Properties

        public string NamePair { get; set; }
        public string ValuePair { get; set; }
        public string FullDisplay
        {
            get { return NamePair + " = " + ValuePair; }
        }

        #endregion

        #region Constructor

        public Pair(string name, string value)
        {
            this.NamePair = name;
            this.ValuePair = value;
        }

        #endregion
    }
}
