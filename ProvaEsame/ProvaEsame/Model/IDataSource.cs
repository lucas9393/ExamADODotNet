using System;
using System.Collections.Generic;
using System.Text;

namespace ProvaEsame.Model
{
    public interface IDataSource
    {
        IEnumerable<Book> AllBooks();
        IEnumerable<Author> AllAuthors();
        IEnumerable<int> AllIdAuthors();
        void Insert(int insIdAuthor, DateTime insDate, string insGenre, string insTitle, int insNumberPages, string insEditor, decimal insPrice);
       
    }
}
