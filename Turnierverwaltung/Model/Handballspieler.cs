using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SQLite;
namespace Turnierverwaltung
{
    public class Handballspieler : Teilnehmer
    {
        #region Eigenschaften
        private int _handstearke;
        private DB _database;
        #endregion

        #region Accessoren / Modifer 
        public int Handstearke { get => _handstearke; set => _handstearke = value; }
        internal DB Database { get => _database; set => _database = value; }
        #endregion

        #region Konsturktor
        public Handballspieler() : base()
        {
            Database = new DB();
            Handstearke = 0;
        }

        public Handballspieler(string name, int value) : base(name)
        {
            Database = new DB();
            Handstearke = value;
        }
        #endregion

        #region Worker 
        public override void Insert_into_DB()
        {
            Database.Connect();
            Random rnd = new Random(DateTime.Now.Ticks.GetHashCode());
            int id = rnd.Next(1, 1000000000);
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

            int handballspieler_id = rnd.Next(1, 1000000);

            Database.Sqlstring = "insert into Handballspieler (handballspieler_id, teilnehmer_id, handstearke) values (@handballspieler_id, @teilnehmer_id, @hand_stearke);";
            command = new SQLiteCommand(Database.Sqlstring, Database.Conn);
            command.Parameters.AddWithValue("@handballspieler_id", handballspieler_id);
            command.Parameters.AddWithValue("@teilnehmer_id", last_id_as_int);
            command.Parameters.AddWithValue("@hand_stearke", Handstearke);

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

            Database.Sqlstring = "update Handballspieler set teilnehmer_id = (select tl.teilnehmer_id from Teilnehmer tl where Handballspieler.teilnehmer_id = tl.teilnehmer_id), handstearke = @handstearke join Teilnhemer using (teilnehmer_id) where teilnehmer_id = @hteilnehmer_id;";
            SQLiteCommand command = new SQLiteCommand(Database.Sqlstring, Database.Conn);
            command.Parameters.AddWithValue("@handstearke", Handstearke);
            command.Parameters.AddWithValue("@teilnehmer_id", person_id);

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


            Database.Sqlstring = "delete from Handballspieler where teilnehmer_id = @teilnehmer_id";
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
    }
    #endregion

}
