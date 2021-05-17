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
        public Arzt(string name, string value) : base(name)
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
            int teilnehmer_id = rnd.Next(1, 1000000);

            long lastID;

            Database.Sqlstring = "insert into Teilnehmer (teilnehmer_id, name) values (@teilnehmerID, @teilnehmerName);";
            SQLiteCommand command = new SQLiteCommand(Database.Sqlstring, Database.Conn);
            command.Parameters.AddWithValue("@teilnehmerID", teilnehmer_id);
            command.Parameters.AddWithValue("@teilnehmerName", Name);


            try
            {
                command.ExecuteNonQuery();
                lastID = Database.Conn.LastInsertRowId;
            }
            catch (Exception)
            {

                return;
            }

            int last_id_as_int = Convert.ToInt32(lastID);
            int arzt_id = rnd.Next(1, 1000000);

            Database.Sqlstring = "insert into Arzt (arzt_id, teilnehmer_id, bezeichnung) values (@arzt_id, @teilnehmer_id, @bezeichnung);";
            command = new SQLiteCommand(Database.Sqlstring, Database.Conn);
            command.Parameters.AddWithValue("@arzt_id", arzt_id);
            command.Parameters.AddWithValue("@teilnehmer_id", last_id_as_int);
            command.Parameters.AddWithValue("@bezeichnung", Bezeichnung);

            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception err)
            {
                System.Diagnostics.Debug.WriteLine("err: " + err);
                return;
            }

            Database.Conn.Close();
        }
        public override void Edit_Person(int person_id)
        {
            Database.Connect();

            Database.Sqlstring = "update Arzt set teilnehmer_id = (select tl.teilnehmer_id from Teilnehmer tl where Arzt.teilnehmer_id = tl.teilnehmer_id), bezeichnung = @bezeichung where arzt_id = @arzt_id;";
            SQLiteCommand command = new SQLiteCommand(Database.Sqlstring, Database.Conn);
            command.Parameters.AddWithValue("@bezeichung", Bezeichnung);
            command.Parameters.AddWithValue("@arzt_id", person_id);

            try
            {
                command.ExecuteNonQuery();
            }
            catch
            {
                return;
            }
            Database.Conn.Close();

        }
        public override void Delete_Person(int person_id)
        {
            throw new NotImplementedException();
        }
        #endregion


    }
}
