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
            Bezeichnung = "";
        }
        public Arzt(int id, string name,  string value) : base(id, name)
        {

            Bezeichnung = value;
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


            Database.Sqlstring = "insert into fussballspieler (arzt_id, teilnehmer_id, bezeichnung) values (@arzt_id,, @teilnehmer_id, @bezeichnung);";
            command = new SQLiteCommand(Database.Sqlstring, Database.Conn);
            command.Parameters.AddWithValue("@arzt_id,", id);
            command.Parameters.AddWithValue("@teilnehmer_id", lastID);
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
