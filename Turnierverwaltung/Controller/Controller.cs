using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace Turnierverwaltung
{
    public class Controller
    {
        #region Eigenschaften 
        private DB _database;
        private List<Teilnehmer> _teilnehmer;
        #endregion

        #region Accesssoren

        internal DB Database { get => _database; set => _database = value; }
        public List<Teilnehmer> Teilnehmer { get => _teilnehmer; set => _teilnehmer = value; }

        #endregion
        #region Konstruktoren
        public Controller()
        {

            Database = new DB();
            Teilnehmer = new List<Teilnehmer>();

        }
        #endregion
        #region Worker

        public SQLiteDataReader HoleAllePersonen()
        {
            //Personendaten aus der DB laden
            Database.Connect();
            Database.Sqlstring = "select * from Teilnehmer";
            SQLiteCommand command = new SQLiteCommand(Database.Sqlstring, Database.Conn);
            SQLiteDataReader reader = null;
            try
            {
                reader = command.ExecuteReader();
            }
            catch
            {

            }

            return reader;
        }

        public void EinenTeilnehmerloeschen(int teilnehmer_id)
        {
            //Personendaten aus der DB laden
            Database.Connect();
            Database.Sqlstring = "delete from Teilnehmer where teilnehmer_id = @id;";
            SQLiteCommand command = new SQLiteCommand(Database.Sqlstring, Database.Conn);
            command.Parameters.AddWithValue("@id", teilnehmer_id);
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
        public void EinenTeilnehmerBearbeiten(int teilnehmer_id, string teilnehmer_name)
        {
            //Personendaten aus der DB laden
            Database.Connect();

            Database.Sqlstring = "update Teilnehmer set name = @teilnehmer_name where teilnehmer_id = @teilnehmer_id";
            SQLiteCommand command = new SQLiteCommand(Database.Sqlstring, Database.Conn);
            command.Parameters.AddWithValue("@teilnehmer_id", teilnehmer_id);
            command.Parameters.AddWithValue("@teilnehmer_name", teilnehmer_name);

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

        /*
        public void Datenspeichern()
        {
            Fussballspieler fussballspieler = new Fussballspieler();
            fussballspieler.DosomeThing();
            Teilnehmer.Add(new Fussballspieler());

            foreach (Teilnehmer objekt in Teilnehmer)
            {
                objekt.Insert_into_DB();
            }
        }
        */

        public void insert_teilnehmer(string teilnehmerName)
        {

            Database.Connect();

            Random rnd = new Random(DateTime.Now.Ticks.GetHashCode());
            int teilnehmerID = rnd.Next(1, 10000);

            Database.Sqlstring = "insert into Teilnehmer (teilnehmer_id, name) values (@teilnehmerID, @teilnehmerName);";
            SQLiteCommand command = new SQLiteCommand(Database.Sqlstring, Database.Conn);
            command.Parameters.AddWithValue("@teilnehmerID", teilnehmerID);
            command.Parameters.AddWithValue("@teilnehmerName", teilnehmerName);

            int anzhal = 0;
            try
            {
                anzhal = command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                return;
            }
            Database.Conn.Close();
        }
        public void Run()
        {

        }

        #endregion
    }
}
