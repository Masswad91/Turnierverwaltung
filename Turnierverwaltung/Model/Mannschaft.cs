using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Turnierverwaltung.Model
{
    public class Mannschaft
    {
        #region Eigenschaften
        private string _mannschaftname;
        #endregion

        #region Accessoren 
        public string Mannschaftname { get => _mannschaftname; set => _mannschaftname = value; }
        #endregion

        #region Konstruktor
        public Mannschaft()
        {
            Mannschaftname = "";
        }

        public Mannschaft(string value)
        {
            Mannschaftname = value;
        }
        #endregion

        #region Worker 

        #endregion
    }
}