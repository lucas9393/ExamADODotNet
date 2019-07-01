using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using ProvaEsame.Model;

namespace ProvaEsame
{
    public class DBDataSource : IDataSource
    {
        public const string connString = @"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog=Exam;Integrated Security=True;";
        public const string queryAllBooks = "SELECT Title, IdAuthor, Genre, Pages, Editor, Price, Publication FROM Books";
        public const string queryAllAuthors = "SELECT Name, Surname, Birthday, Email FROM Authors";
        public IEnumerable<Book> AllBooks()
        {
            using (SqlConnection connection = new SqlConnection(connString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(queryAllBooks, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    var posIdAuthor = reader.GetOrdinal("IdAuthor");
                    var posGenre = reader.GetOrdinal("Genre");
                    var posTitle = reader.GetOrdinal("Title");                  
                    var posPages = reader.GetOrdinal("Pages");
                    var posEditor = reader.GetOrdinal("Editor");
                    var posPrice = reader.GetOrdinal("Price");
                    var posPublication = reader.GetOrdinal("Publication");
                    var books = new List<Book>();

                    while (reader.Read())
                    {
                        var book = new Book(
                              reader.GetInt32(posIdAuthor),
                              reader.GetString(posTitle),
                              reader.GetDateTime(posPublication),
                              (Genre)Enum.Parse(typeof(Genre), reader.GetString(posGenre)),
                              reader.GetInt32(posPages),  
                              reader.GetString(posEditor),
                              reader.GetDecimal(posPrice)     
                            );
                        books.Add(book);
                    }
                    return books;
                }
            }
        }

        public IEnumerable<Author> AllAuthors()
        {
            using (SqlConnection connection = new SqlConnection(connString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(queryAllAuthors, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    var posName = reader.GetOrdinal("Name");
                    var posSurname = reader.GetOrdinal("Surname");
                    var posBirthday = reader.GetOrdinal("Birthday");
                    var posMail = reader.GetOrdinal("Email");
                    var authors = new List<Author>();

                    while (reader.Read())
                    {
                        var author = new Author(
                              reader.GetString(posName),
                              reader.GetString(posSurname),
                              reader.GetDateTime(posBirthday),
                              reader.GetString(posMail)
                            );
                        authors.Add(author);
                    }
                    return authors;
                }
            }
        }

        public void Insert(int insIdAuthor, DateTime insPublication, string insGenre, string insTitle, int insNumberPages, string insEditor, decimal insPrice)
        {
            using (SqlConnection connection = new SqlConnection(connString))
            {
                connection.Open();
                var insertRecord = "INSERT INTO Books (IdAuthor, Genre, Title, Pages, Editor, Price, Publication) " +
                    "VALUES (@IdAuthor,@Genre,@Title,@Pages,@Editor,@Price,@Publication)";

                using (SqlCommand command = new SqlCommand(insertRecord, connection))
                {
                    command.Parameters.AddWithValue("@IdAuthor", insIdAuthor);
                    command.Parameters.AddWithValue("@Genre", insGenre);
                    command.Parameters.AddWithValue("@Title", insTitle);
                    command.Parameters.AddWithValue("@Pages", insNumberPages);
                    command.Parameters.AddWithValue("@Editor", insEditor);
                    command.Parameters.AddWithValue("@Price", insPrice);
                    command.Parameters.AddWithValue("@Publication", insPublication);
                    command.ExecuteNonQuery();
                }
            }
        }

        public decimal GetAveragePrice()
        {
            throw new NotImplementedException();
        }
    }
}
