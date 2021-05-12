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
        private DB _database;
        #endregion

        #region Accessoren / Modifer 
        public int Handstearke { get => _handstearke; set => _handstearke = value; }
        internal DB Database { get => _database; set => _database = value; }
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
            Random rnd = new Random(DateTime.Now.Ticks.GetHashCode());
            int id = rnd.Next(1, 1000000000);
            long lastID;

            Database.Sqlstring = "insert into Teilnehmer (teilnehmer_id, name) values (@teilnehmerID, @teilnehmerName);";
            SQLiteCommand command = new SQLiteCommand(Database.Sqlstring, Database.Conn);
            command.Parameters.AddWithValue("@teilnehmerID", id);
            command.Parameters.AddWithValue("@teilnehmerName", Name);

            int anzhal = 0;
            try
            {
                anzhal = command.ExecuteNonQuery();
                lastID = Database.Conn.LastInsertRowId;
            }
            catch (Exception)
            {
                return;
            }


            Database.Sqlstring = "insert into fussballspieler (handballspieler_id, teilnehmer_id, hand_stearke) values (@handballspieler_id, @teilnehmer_id, @hand_stearke);";
            command = new SQLiteCommand(Database.Sqlstring, Database.Conn);
            command.Parameters.AddWithValue("@handballspieler_id", id);
            command.Parameters.AddWithValue("@teilnehmer_id", lastID);
            command.Parameters.AddWithValue("@hand_stearke", Handstearke);

            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                return;
            }


            Database.Conn.Close();
        }
        #endregion
    }
}
