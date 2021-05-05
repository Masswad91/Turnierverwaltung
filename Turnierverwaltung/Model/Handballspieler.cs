using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SQLite;
namespace Turnierverwaltung
{
    public class Handballspieler : Teilnehmer
    {
        #region Eigenschaften
        private int _handstearke;
        #endregion

        #region Accessoren / Modifer 
        public int Handstearke { get => _handstearke; set => _handstearke = value; }
        #endregion

        #region Konsturktor
        public Handballspieler() : base()
        {
            Handstearke = 0;
        }

        public Handballspieler(int id, string name, int value) : base(id, name)
        {
            Handstearke = value;
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
