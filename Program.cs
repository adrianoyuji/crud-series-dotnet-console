using System;

namespace Series
{
    class Program
    {

        static TvSerieRepository repository = new TvSerieRepository();
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Tv Series Database!");
            string userOption = GetUserOption();
            while (userOption != "X")
            {
                switch (userOption)
                {
                    case "1":
                        ListSeries();
                        break;
                    case "2":
                        InsertSerie();
                        break;
                    case "3":
                        UpdateSerie();
                        break;
                    case "4":
                        DeleteSerie();
                        break;
                    case "5":
                        PrintSerie();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                userOption = GetUserOption();
            }
            Console.WriteLine("Bye have a great one!");
        }

        private static void ListSeries()
        {
            Console.WriteLine("Listing all series...");
            var list = repository.List();
            if (list.Count == 0)
            {
                Console.WriteLine("There are no series registered...");
                return;
            }
            else
            {
                foreach (var serie in list)
                {


                    Console.WriteLine($"#ID {serie.getId()}: {serie.getTitle()} {(serie.isDeleted() ? " - Deleted" : "")}");
                }
            }

        }


        private static void InsertSerie()
        {
            Console.WriteLine("Insert the serie's title");
            string title = Console.ReadLine();
            Console.WriteLine("Insert the serie's genre");
            foreach (int i in Enum.GetValues(typeof(Genre)))
            {
                Console.WriteLine($"{i} - {Enum.GetName(typeof(Genre), i)}");
            }
            int genreId = int.Parse(Console.ReadLine());
            Console.WriteLine("Insert the serie's description");
            string description = Console.ReadLine();
            Console.WriteLine("Insert the serie's year");
            int year = int.Parse(Console.ReadLine());
            TvSerie newTvSerie = new TvSerie(id: repository.NextId(), title: title, description: description, year: year, genre: (Genre)genreId);
            repository.Insert(newTvSerie);

        }
        private static void UpdateSerie()
        {
            Console.WriteLine("Insert the serie's Id");
            int Id = int.Parse(Console.ReadLine());
            Console.WriteLine("Insert the serie's title");
            string title = Console.ReadLine();
            Console.WriteLine("Insert the serie's genre");
            foreach (int i in Enum.GetValues(typeof(Genre)))
            {
                Console.WriteLine($"{i} - {Enum.GetName(typeof(Genre), i)}");
            }
            int genreId = int.Parse(Console.ReadLine());
            Console.WriteLine("Insert the serie's description");
            string description = Console.ReadLine();
            Console.WriteLine("Insert the serie's year");
            int year = int.Parse(Console.ReadLine());
            TvSerie updatedSerie = new TvSerie(id: Id, title: title, description: description, year: year, genre: (Genre)genreId);
            repository.Update(Id, updatedSerie);
        }
        private static void DeleteSerie()
        {
            Console.WriteLine("Insert the serie's Id");
            int Id = int.Parse(Console.ReadLine());
            repository.Delete(Id);
            Console.WriteLine("Deleted!");
        }
        private static void PrintSerie()
        {
            Console.WriteLine("Insert the serie's Id");
            int Id = int.Parse(Console.ReadLine());
            var serie = repository.ReturnsById(Id);
            Console.WriteLine(serie.ToString());
        }


        private static string GetUserOption()
        {
            Console.WriteLine();
            Console.WriteLine("Input the desired option!");
            Console.WriteLine();
            Console.WriteLine("1 - List all series");
            Console.WriteLine("2 - Insert new Serie");
            Console.WriteLine("3 - Update a serie");
            Console.WriteLine("4 - Delete a serie");
            Console.WriteLine("5 - View a serie");
            Console.WriteLine("C - Clear terminal");
            Console.WriteLine("X - Exit");
            Console.WriteLine();
            string userOption = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return userOption;

        }
    }
}
