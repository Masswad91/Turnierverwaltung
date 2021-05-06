using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SQLite;

namespace Turnierverwaltung
{
    class DB
    {
        #region Eigenschaften
        private string _connectionstring;
        private string _sqlstring;
        private SQLiteConnection _conn;

        #endregion

        #region Accessoren 
        public string Connectionstring { get => _connectionstring; set => _connectionstring = value; }
        public string Sqlstring { get => _sqlstring; set => _sqlstring = value; }
        public SQLiteConnection Conn { get => _conn; set => _conn = value; }
        #endregion

        #region Konstruktor
        public DB()
        {
            Connectionstring = "Data Source=" + "C:/Users/Moham/Desktop/Entwicklung/Turnierverwaltung_db.db3;" + "Version=3;";
            Sqlstring = "";
        }
        public DB(string db_path)
        {
            Connectionstring = db_path;
            Sqlstring = "";
        }
        #endregion

        #region Worker
        public void Connect()
        {
            Conn = new SQLiteConnection(Connectionstring);

            try
            {
                Conn.Open();
            }
            catch (Exception)
            {
                return;
            }
 
        }
        #endregion
    }
}
