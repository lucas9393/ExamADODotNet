using System;
using System.Collections.Generic;
using System.Text;

namespace ProvaEsame.Model
{
    public class Author
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Birthday { get; set; }
        public string Mail { get; set; }
        public Author(string name, string surname, DateTime birthday, string mail)
        {
            Name = name;
            Surname = surname;
            Birthday = birthday;
            Mail = mail;
        }
        public override string ToString()
        {
            return $"\nNOME: {Name}\nCOGNOME: {Surname}\nDATA DI NASCITA: {Birthday.Day}/{Birthday.Month}/{Birthday.Year}\nMAIL: {Mail}\n";
        }
    }
}
