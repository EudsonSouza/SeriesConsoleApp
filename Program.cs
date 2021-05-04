using System;
using System.Linq;

namespace Series
{
    class Program
    {
        static SeriesRepository rep = new SeriesRepository();
        static void Main(string[] args)
        {
            rep.Insert(new Serie(rep.NextId(), 0, "teste title", "teste descp", 20220));
            string userOption = "";

            while (userOption != "X")
            {
                userOption = GetUserOption();

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
                        ShowSerieDetails();
                        break;
                    case "X":
                        Exit();
                        return;
                    default:
                        Console.WriteLine("Invalid option, please type a menu option");
                        break;

                }
                Console.WriteLine();
                TypeToContinue();
                Console.Clear();
            }
        }

        private static void ListSeries()
        {
            Console.WriteLine();
            Console.WriteLine("List series");
            var list = rep.List();

            if (list.Count == 0)
            {
                Console.WriteLine("There is no series registred");
                return;
            }
            foreach (var serie in list.Where(s => !s.isDeleted()))
            {
                Console.WriteLine("#ID {0}: - {1}", serie.GetId(), serie.GetTitle());
            }
        }

        private static void TypeToContinue()
        {
            Console.Write("Type anything to continue");
            Console.ReadLine();
        }

        private static void InsertSerie()
        {
            Serie serie = GetSerieDataFromUser();
            rep.Insert(serie);
        }

        private static Serie GetSerieDataFromUser()
        {
            return GetSerieDataFromUser(rep.NextId());
        }
        private static Serie GetSerieDataFromUser(int id)
        {
            Console.WriteLine();
            foreach (int i in Enum.GetValues(typeof(Genre)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genre), i));
            }

            int genre = GetValidEnumFromUser();

            Console.Write("Type the serie title: ");
            string title = Console.ReadLine();

            int year = GetValidYearFromUser();

            Console.Write("Type the serie description: ");
            string description = Console.ReadLine();

            Serie serie = new Serie(id, (Genre)genre, title, description, year);

            return serie;
        }

        private static int GetValidYearFromUser()
        {
            while (true)
            {
                Console.Write("Type the serie realease year: ");
                if (int.TryParse(Console.ReadLine(), out int year))
                {
                    return year;
                }

            }

        }

        private static int GetValidEnumFromUser()
        {
            Console.WriteLine("Type the code of genre: ");

            int enumCount = Enum.GetValues(typeof(Genre)).Length;
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int genre))
                {
                    if (0 <= genre && genre < enumCount)
                    {
                        return genre;
                    }
                }

                Console.Write("Type a value between 0 and {0}: ", enumCount - 1);
            }
        }

        private static void UpdateSerie()
        {

            int id = GetSerieIdFromUser();

            Serie serie = GetSerieDataFromUser(id);

            rep.Update(id, serie);

            Console.WriteLine("Serie updated successfully");
        }

        private static int GetSerieIdFromUser()
        {
            Console.WriteLine();
            while (true)
            {
                Console.Write("Type the serie index: ");
                if (int.TryParse(Console.ReadLine(), out int id))
                {
                    if (0 <= id && id < rep.NextId() && !rep.GetById(id).isDeleted())
                    {
                        return id;
                    }

                }
                ListSeries();
            }
        }

        private static void DeleteSerie()
        {
            int id = GetSerieIdFromUser();

            rep.Delete(id);

            Console.WriteLine("Serie deleted sucessfully");
        }

        private static void ShowSerieDetails()
        {
            int id = GetSerieIdFromUser();
            Serie serie = rep.GetById(id);
            Console.WriteLine(serie);
        }

        private static void Exit()
        {
            Console.WriteLine("Thanks for using our services");
            Console.ReadLine();
        }

        private static string GetUserOption()
        {
            Console.WriteLine("Welcome to Series Base");
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1 - List series");
            Console.WriteLine("2 - Insert serie");
            Console.WriteLine("3 - Update serie");
            Console.WriteLine("4 - Delete serie");
            Console.WriteLine("5 - Show serie details");
            Console.WriteLine("X - Exit");

            return Console.ReadLine()?.ToUpper();

        }
    }
}
