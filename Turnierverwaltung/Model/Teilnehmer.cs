using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SQLite;

namespace Turnierverwaltung
{
    public abstract class Teilnehmer
    {
        #region Eigenschaften
        private string _name;



        #endregion
        #region Accesssoren
        public string Name { get => _name; set => _name = value; }
        #endregion
        #region Konstruktoren

        public Teilnehmer()
        {
            Name = "";
        }

        public Teilnehmer(string value2)
        {
            Name = value2;

        }
        #endregion

        #region Worker
        // Polymorphie 1. Grades Frühe Bindung 
        public virtual void DosomeThing()
        {
            Console.WriteLine("Teilnehmer 1 ");
        }

        // Polymorphie 2. Grades Späte Bindung 
        public abstract void Insert_into_DB();
        public abstract void Edit_Person(int person_id);
        #endregion

    }
}
