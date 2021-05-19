using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Turnierverwaltung
{
    public class Mannschaft : Teilnehmer
    {
        #region Eigenschaften
        private string _mannschaft_name;
        private List<Teilnehmer> _teilnehmerlist;
        #endregion

        #region Accessoren / Modifer
        public string Mannschaft_name { get => _mannschaft_name; set => _mannschaft_name = value; }
        public List<Teilnehmer> Teilnehmerlist { get => _teilnehmerlist; set => _teilnehmerlist = value; }
        #endregion

        #region Konstruktoren
        public Mannschaft() : base() {

            Mannschaft_name = "";
            Teilnehmerlist = new List<Teilnehmer>(); 
        }

        public Mannschaft(string name, string mannschaft_name) : base(name)
        {

            Mannschaft_name = mannschaft_name;
   
        }
        #endregion

        #region Worker
        public override void Insert_into_DB()
        {
            throw new NotImplementedException();
        }

        public override void Edit_Person(int person_id)
        {
            throw new NotImplementedException();
        }

        public override void Delete_Person(int person_id)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}