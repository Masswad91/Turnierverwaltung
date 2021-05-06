using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SQLite;

namespace Turnierverwaltung
{
    public class Fussballspieler : Teilnehmer
    {
        #region Eigenschaften 
        private int _fussstearke;
        private DB _database;
        #endregion

        #region Accessoren / Modifer
        public int Fussstearke { get => _fussstearke; set => _fussstearke = value; }
        internal DB Database { get => _database; set => _database = value; }

        #endregion

        #region Konstruktoren 
        public Fussballspieler() : base()
        {
            Fussstearke = 0;
            Database = new DB();
        }
        public Fussballspieler(int id, string name,string adresse, string type,  int value) : base(id, name, adresse, type)
        {
            Fussstearke = value;
        }
        #endregion
        #region Worker 
        public override void Insert_into_DB()
        {

            Database.Sqlstring = "insert into fussballspieler (id, fussstearke) values (1,20);";
            SQLiteCommand command = new SQLiteCommand(Database.Sqlstring, Database.Conn);

            int anzhal = 0;
            try
            {
                anzhal = command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                return;
            }

            if (anzhal > 0)
            {
                Console.WriteLine("Letzte id " + command.Connection.LastInsertRowId);
            }
            Database.Conn.Close();

        }
        #endregion
    }
}
