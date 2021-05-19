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
            Database = new DB();
            Mitwelcherhand = "linke hand";
        }
        public Tennisspieler(string name, string value) : base(name)
        {
            Database = new DB();
            Mitwelcherhand = value;
        }

        #endregion

        #region Worker 
        public override void Insert_into_DB()
        {
            Database.Connect();
            Random rnd = new Random(DateTime.Now.Ticks.GetHashCode());
            int id = rnd.Next(1, 1000000);
            long lastID;

            Database.Sqlstring = "insert into Teilnehmer (teilnehmer_id, name) values (@teilnehmerID, @teilnehmerName);";
            SQLiteCommand command = new SQLiteCommand(Database.Sqlstring, Database.Conn);
            command.Parameters.AddWithValue("@teilnehmerID", id);
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
            int tennisspieler_id = rnd.Next(1, 1000000);
            Database.Sqlstring = "insert into Tennisspieler (tennisspieler_id, teilnehmer_id, welche_hand) values (@tennisspieler_id, @teilnehmer_id, @welche_hand);";
            command = new SQLiteCommand(Database.Sqlstring, Database.Conn);
            command.Parameters.AddWithValue("@tennisspieler_id", tennisspieler_id);
            command.Parameters.AddWithValue("@teilnehmer_id", last_id_as_int);
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

        public override void Edit_Person(int person_id)
        {
            Database.Connect();

            Database.Sqlstring = "update Tennisspieler set teilnehmer_id = (select tl.teilnehmer_id from Teilnehmer tl where Tennisspieler.teilnehmer_id = tl.teilnehmer_id), welche_hand = @welche_hand where teilnehmer_id = @tennisspieler_id;";
            SQLiteCommand command = new SQLiteCommand(Database.Sqlstring, Database.Conn);
            command.Parameters.AddWithValue("@welche_hand", Mitwelcherhand);
            command.Parameters.AddWithValue("@tennisspieler_id;", person_id);

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
            Database.Connect();


            Database.Sqlstring = "delete from Tennisspieler where teilnehmer_id = @teilnehmer_id";
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
