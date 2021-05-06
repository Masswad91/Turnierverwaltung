using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SQLite;

namespace Turnierverwaltung
{
    public abstract class Teilnehmer
    {
        #region Eigenschaften 
        private int _id;
        private string _name;
        private string _adresse;
        private string _type; 



        #endregion
        #region Accesssoren
        public int Id { get => _id; set => _id = value; }
        public string Name { get => _name; set => _name = value; }
        public string Adresse { get => _adresse; set => _adresse = value; }
        public string Type { get => _type; set => _type = value; }
        #endregion
        #region Konstruktoren

        public Teilnehmer()
        {
            Id = -1;
            Name = "";
            Adresse = "";
            Type = "";
        }

        public Teilnehmer(int value1, string value2, string value3, string value4)
        {
            Id = value1;
            Name = value2;
            Adresse = value3;
            Type = value4;
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
        #endregion

    }
}
