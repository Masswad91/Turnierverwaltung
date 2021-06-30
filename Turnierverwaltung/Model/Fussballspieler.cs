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
        public Fussballspieler(string name, int value) : base(name)
        {
            Database = new DB();
            Fussstearke = value;
        }
        #endregion

        #region Worker 
        public override void Insert_into_DB()
        {
            Database.Connect();
            long lastID;

            Database.Sqlstring = "insert into Teilnehmer (name) values (@teilnehmerName);";
            SQLiteCommand command = new SQLiteCommand(Database.Sqlstring, Database.Conn);
            command.Parameters.AddWithValue("@teilnehmerName", Name);

            try
            {
                command.ExecuteNonQuery();
                lastID = Database.Conn.LastInsertRowId;
            }
            catch (Exception err)
            {
                System.Diagnostics.Debug.WriteLine("err: " + err);
                return;
            }

            int last_id_as_int = Convert.ToInt32(lastID);

            Database.Sqlstring = "insert into Fussballspieler (teilnehmer_id, fussstearke) values (@teilnehmer_id, @fussstearke);";
            command = new SQLiteCommand(Database.Sqlstring, Database.Conn);
            command.Parameters.AddWithValue("@teilnehmer_id", last_id_as_int);
            command.Parameters.AddWithValue("@fussstearke", Fussstearke);
           
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

            Database.Sqlstring = "update Fussballspieler set teilnehmer_id = (select tl.teilnehmer_id from Teilnehmer tl where Fussballspieler.teilnehmer_id = tl.teilnehmer_id), fussstearke = @fussstearke where teilnehmer_id = @teilnehmer_id;";
            SQLiteCommand command = new SQLiteCommand(Database.Sqlstring, Database.Conn);
            command.Parameters.AddWithValue("@fussstearke", Fussstearke);
            command.Parameters.AddWithValue("@teilnehmer_id", person_id);
     
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
        public override void Delete_Person(int person_id)
        {
            Database.Connect();
            Database.Sqlstring = "delete from Fussballspieler where teilnehmer_id = @teilnehmer_id";
            SQLiteCommand command = new SQLiteCommand(Database.Sqlstring, Database.Conn);
            command.Parameters.AddWithValue("@teilnehmer_id", person_id);

            try
            {
                command.ExecuteNonQuery();

            }
            catch (Exception err)
            {
                System.Diagnostics.Debug.WriteLine("err: " + err);
                return;
            }
            Database.Sqlstring = "delete from Teilnehmer where teilnehmer_id = @teilnehmer_id";
            command = new SQLiteCommand(Database.Sqlstring, Database.Conn);
            command.Parameters.AddWithValue("@teilnehmer_id", person_id);
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
        #endregion
    }
}
