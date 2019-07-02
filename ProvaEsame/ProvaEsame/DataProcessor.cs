using System;
using System.Collections.Generic;
using System.Text;
using ProvaEsame.Model;
using System.Linq;

namespace ProvaEsame
{
    public class DataProcessor
    {
        private IDataSource source;
        public DataProcessor(IDataSource linkSource)
        {
            source = linkSource;
        }
        public IEnumerable<Book> AllBooks()
        {
            return source.AllBooks();
        }
        public IEnumerable<Author> AllAuthors()
        {
            return source.AllAuthors();
        }
        public bool GetIdAuthor(int id)
        {
            return source.AllIdAuthors().Contains(id);
        }

        public void InsertBook(int insIdAuthor, DateTime insPublication, string insGenre, string insTitle, int insPages, string insEditor, decimal insPrice)
        {
            source.Insert(insIdAuthor, insPublication, insGenre, insTitle, insPages, insEditor, insPrice);
        }
        public decimal GetAveragePrice()
        {
            return source.AllBooks().Average(b => b.Price);
        }
        public decimal GetMode()
        {
            return CalculateMode(source.AllBooks().ToList());
        }
        public decimal CalculateMode(IEnumerable<Book> inputList)
        {
            return inputList
                .GroupBy(b => b.Price)
                .OrderByDescending(g => g.Count())
                .First()
                .Key;
        }
    }
}
