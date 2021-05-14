using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace Turnierverwaltung
{
    public class Controller
    {
        #region Eigenschaften 
        private DB _database;
        private List<Teilnehmer> _teilnehmerliste;
        #endregion

        #region Accesssoren

        internal DB Database { get => _database; set => _database = value; }
        public List<Teilnehmer> Teilnehmerliste { get => _teilnehmerliste; set => _teilnehmerliste = value; }

        #endregion
        #region Konstruktoren
        public Controller()
        {

            Database = new DB();
            Teilnehmerliste = new List<Teilnehmer>();

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


        public void Datenspeichern()
        {
            foreach (Teilnehmer objekt in Teilnehmerliste)
            {
                objekt.Insert_into_DB();
            }
        }
        public void Run()
        {

        }

        #endregion
    }
}
