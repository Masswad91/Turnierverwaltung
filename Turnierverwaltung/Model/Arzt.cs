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
        private DB _database;
        #endregion

        #region Accessoren 
        public string Bezeichnung { get => _bezeichnung; set => _bezeichnung = value; }
        internal DB Database { get => _database; set => _database = value; }
        #endregion

        #region Konstruktoren
        public Arzt() : base()
        {

            Database = new DB();
            Bezeichnung = "";
        }
        public Arzt(string name,  string value) : base(name)
        {
            Database = new DB();
            Bezeichnung = value;
        }
        #endregion

        #region Worker 
        public override void Insert_into_DB()
        {
            Database.Connect();
            Random rnd = new Random(DateTime.Now.Ticks.GetHashCode());
            int teilnehmer_id= rnd.Next(1, 1000000);

            long lastID;

            Database.Sqlstring = "insert into Teilnehmer (teilnehmer_id, name) values (@teilnehmerID, @teilnehmerName);";
            SQLiteCommand command = new SQLiteCommand(Database.Sqlstring, Database.Conn);
            command.Parameters.AddWithValue("@teilnehmerID", teilnehmer_id);
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

            Console.WriteLine(lastID);
            int last_id_as_int = Convert.ToInt32(lastID);

            int arzt_id = rnd.Next(1, 1000000);
            Database.Sqlstring = "insert into Arzt (arzt_id, teilnehmer_id, bezeichnung) values (@arzt_id, @teilnehmer_id, @bezeichnung);";
            command = new SQLiteCommand(Database.Sqlstring, Database.Conn);
            command.Parameters.AddWithValue("@arzt_id,", arzt_id);
            command.Parameters.AddWithValue("@teilnehmer_id", last_id_as_int);
            command.Parameters.AddWithValue("@bezeichnung", Bezeichnung);

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
