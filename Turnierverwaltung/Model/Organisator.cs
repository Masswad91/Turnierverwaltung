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
        private DB _database;
        #endregion

        #region Accessoren 
        public string Role { get => _role; set => _role = value; }
        internal DB Database { get => _database; set => _database = value; }
        #endregion

        #region Konstruktor
        public Organisator() : base()
        {
            Database = new DB();
            Role = "";
        }
        public Organisator(string name, string value ) : base(name)
        {
            Role = value;
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

           
            int last_id_as_int = Convert.ToInt32(lastID);
            int organisator_id = rnd.Next(1, 1000000);
            Database.Sqlstring = "insert into Organisator (organisator_id, teilnehmer_id) values (@organisator_id, @teilnehmer_id);";
            command = new SQLiteCommand(Database.Sqlstring, Database.Conn);
            command.Parameters.AddWithValue("@organisator_id", organisator_id);
            command.Parameters.AddWithValue("@teilnehmer_id", last_id_as_int);

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
