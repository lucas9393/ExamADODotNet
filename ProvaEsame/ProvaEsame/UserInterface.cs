using System;
using System.Collections.Generic;
using System.Text;
using ProvaEsame.Model;

namespace ProvaEsame
{
    public class UserInterface
    {
        private DataProcessor processor;
        const string MENU_MESSAGE = "Premi:\n'1' Per stampare la lista dei libri\n" +
            "'2' per stampare la lista degli autori\n" +
            "'3' per inserire un nuovo libro\n" +
            "'4' per calcolare la media del prezzo dei libri\n" +
            "'5' per calcolare la moda del prezzo dei libri\n" +
            "'Q' per chiudere";

        public UserInterface(DataProcessor processor)
        {
            this.processor = processor;
        }
        public void MainMenu()
        {
            Console.WriteLine(MENU_MESSAGE);
            char choose = Console.ReadKey().KeyChar;
            Console.WriteLine();

            switch (choose)
            {
                case '1':
                    ShowBooks();
                    break;
                case '2':
                    ShowAuthors();
                    break;
                case '3':
                    InsertBook();
                    break;
                case '4':
                    GetAveragePrice();
                    break;
                case '5':
                    GetMode();
                    break;
                case 'Q':
                case 'q':
                    return;

                default:
                    Console.WriteLine("Scelta non valida");
                    break;
            }

            MainMenu();
        }

        private void ShowBooks()
        {
            IEnumerable<Book> books = processor.AllBooks();
            foreach (var s in books)
            {
                Console.WriteLine(s);
            }
        }
        private void ShowAuthors()
        {
            IEnumerable<Author> authors = processor.AllAuthors();
            foreach (var s in authors)
            {
                Console.WriteLine(s);
            }
        }

        private void InsertBook()
        {
            Console.Write("Id Autore: ");
            int insIdAuthor = Convert.ToInt32(Console.ReadLine());
            Console.Write("Data di pubblicazione (GG/MM/AAAA): ");
            string insPublication = Console.ReadLine();
            DateTime parsedDate = DateTime.Parse(insPublication);
            Console.Write("Genere: ");
            string insGenre = Console.ReadLine();
            Console.Write("Titolo: ");
            string insTitle = Console.ReadLine();
            Console.Write("Numero Pagine: ");
            int insNumberPages = Convert.ToInt32(Console.ReadLine());
            Console.Write("Casa editrice: ");
            string insEditor = Console.ReadLine();
            Console.Write("Prezzo: ");
            decimal insPrice = Convert.ToDecimal(Console.ReadLine());

            if(processor.GetIdAuthor(insIdAuthor))
            {
                processor.InsertBook(insIdAuthor, parsedDate, insGenre, insTitle, insNumberPages, insEditor, insPrice);
            }
            else
            {
                Console.WriteLine("\nNon è possibile inserire un libro senza aver prima inserito l'autore\n");
            }
        }
        
        private void GetAveragePrice()
        {
            Console.WriteLine(processor.GetAveragePrice());
        }
        private void GetMode()
        {
            Console.WriteLine(processor.GetMode());
        }
    }
}
