using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SQLite;

namespace Turnierverwaltung
{
    public class Organisator : Teilnehmer
    {
        #region Eigenschaften
        private string _role;
        #endregion

        #region Accessoren 
        public string Role { get => _role; set => _role = value; }
        #endregion

        #region Konstruktor
        public Organisator() : base()
        {
            Role = "";
        }
        public Organisator(int id, string name, string value ) : base(id, name)
        {
            Role = value;
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
