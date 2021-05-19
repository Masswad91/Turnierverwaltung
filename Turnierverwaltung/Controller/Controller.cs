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
            catch(Exception err)
            {
                System.Diagnostics.Debug.WriteLine("err: " + err);
            }
           
            return reader;
        }

        public void EinenTeilnehmerBearbeiten(int teilnehmer_id)
        {
            foreach (Teilnehmer obejekt in Teilnehmerliste)
            {
             
                obejekt.Edit_Person(teilnehmer_id);
            }
        }
        public void EinenTeilnehmerLoechen(int teilnehmer_id)
        {
            foreach (Teilnehmer obejekt in Teilnehmerliste)
            {
                obejekt.Delete_Person(teilnehmer_id);
            }
        }

        public void EinenTeilnehmerHinzufuegen()
        {
            foreach (Teilnehmer objekt in Teilnehmerliste)
            {
                objekt.Insert_into_DB();
            }
        }

        #endregion
    }
}
