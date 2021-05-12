using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SQLite;

namespace Turnierverwaltung
{
    public class Tennisspieler : Teilnehmer 
    {
        #region Eigenschaften
        private DB _database;
        private string _mitwelcherhand;

        #endregion

        #region Accessoren 
        public string Mitwelcherhand { get => _mitwelcherhand; set => _mitwelcherhand = value; }
        internal DB Database { get => _database; set => _database = value; }

        #endregion

        #region Konstruktor

        public Tennisspieler() : base()
        {
            Mitwelcherhand = "linke hand";
        }
        public Tennisspieler(int id, string name, string value) : base(id, name)
        {
            Mitwelcherhand = value;
        }

        #endregion

        #region Worker 
        public override void Insert_into_DB()
        {
            Random rnd = new Random(DateTime.Now.Ticks.GetHashCode());
            int id = rnd.Next(1, 1000000);
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


            Database.Sqlstring = "insert into fussballspieler (tennisspieler_id, teilnehmer_id, welche_hand) values (@tennisspieler_id, @teilnehmer_id, @welche_hand);";
            command = new SQLiteCommand(Database.Sqlstring, Database.Conn);
            command.Parameters.AddWithValue("@tennisspieler_id", id);
            command.Parameters.AddWithValue("@teilnehmer_id", lastID);
            command.Parameters.AddWithValue("@welche_hand", Mitwelcherhand);

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
