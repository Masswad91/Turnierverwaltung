using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SQLite;

namespace Turnierverwaltung
{
    public class Arzt : Teilnehmer
    {
        #region Eigenschaften
        private string _bezeichnung;
        #endregion

        #region Accessoren 
        public string Bezeichnung { get => _bezeichnung; set => _bezeichnung = value; }
        #endregion

        #region Konstruktoren
        public Arzt() : base()
        {
            Bezeichnung = "";
        }
        public Arzt(int id, string name, string adresse, string type,  string value) : base(id, name, adresse, type)
        {

            Bezeichnung = value;
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
