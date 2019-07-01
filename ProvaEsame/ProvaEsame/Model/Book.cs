using System;
using System.Collections.Generic;
using System.Text;

namespace ProvaEsame.Model
{
    public enum Genre { Fantasy, ScienceFiction, Horror, Narrative }

    public class Book
    {
        public int IdAuthor { get; set; }
        public Genre Type { get; set; }
        public string Title { get; set; }
        public DateTime Publication { get; set; }
        public int Pages { get; set; }
        public string Editor { get; set; }
        public decimal Price { get; set; }

        public Book(int idAuthor, string title, DateTime publication, Genre type, int pages, string editor, decimal price)
        {
            IdAuthor = idAuthor;
            Title = title;
            Publication = publication;
            Type = type;
            Pages = pages;
            Editor = editor;
            Price = price;
        }

        public override string ToString()
        {
            return $"\nTITOLO: {Title}\nPUBBLICAZIONE: {Publication.Year}\nGENERE: {Type}\nPAGINE: {Pages}\nCASA EDITRICE: {Editor}\nPREZZO: {Price}\n";
        }
    }


}
