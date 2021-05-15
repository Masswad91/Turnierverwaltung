﻿using System;
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
            catch (Exception err)
            {
                System.Diagnostics.Debug.WriteLine("err: " + err);
                return;
            }

            int last_id_as_int = Convert.ToInt32(lastID);
            int fussballspieler_id = rnd.Next(1, 1000000);

            Database.Sqlstring = "insert into Fussballspieler (fussballspieler_id, teilnehmer_id, fussstearke) values (@fussballspieler_id, @teilnehmer_id, @fussstearke);";
            command = new SQLiteCommand(Database.Sqlstring, Database.Conn);
            command.Parameters.AddWithValue("@fussballspieler_id", fussballspieler_id);
            command.Parameters.AddWithValue("@teilnehmer_id", last_id_as_int);
            command.Parameters.AddWithValue("@fussstearke", Fussstearke);
            System.Diagnostics.Debug.WriteLine("eff: " + Fussstearke);

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

            Database.Sqlstring = "update Fussballspieler set teilnehmer_id = (select tl.teilnehmer_id from Teilnehmer tl where Fussballspieler.teilnehmer_id = tl.teilnehmer_id), fussstearke = @fussstearke where fussballspieler_id = @fussballspieler_id;";
            SQLiteCommand command = new SQLiteCommand(Database.Sqlstring, Database.Conn);
            command.Parameters.AddWithValue("@fussstearke", Fussstearke);
            command.Parameters.AddWithValue("@fussballspieler_id", person_id);

            try
            {
                command.ExecuteNonQuery();
            }
            catch(Exception err)
            {
                System.Diagnostics.Debug.WriteLine("err: " + err);
                return;
            }
            Database.Conn.Close();

        }

        #endregion
    }
}
