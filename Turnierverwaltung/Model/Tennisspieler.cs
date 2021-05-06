using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Turnierverwaltung
{
    public class Tennisspieler : Teilnehmer 
    {
        #region Eigenschaften
        private string _mitwelcherhand;

        #endregion

        #region Accessoren 
        public string Mitwelcherhand { get => _mitwelcherhand; set => _mitwelcherhand = value; }

        #endregion

        #region Konstruktor

        public Tennisspieler() : base()
        {
            Mitwelcherhand = "linke hand";
        }
        public Tennisspieler(int id, string name, string adresse, string type, string value) : base(id, name, adresse, type)
        {
            Mitwelcherhand = value;
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
