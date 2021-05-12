using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Turnierverwaltung.Model
{
    public class Mannschaft : Teilnehmer
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

        public Mannschaft(int id, string name, string value) : base(id, name)
        {
            Mannschaftname = value;
        }
        #endregion

        #region Worker 
        public override void Insert_into_DB()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}