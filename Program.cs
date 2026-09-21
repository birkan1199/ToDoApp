using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ToDoApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("---Welcome to the To-Do List App!---");
            Console.WriteLine("");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.WriteLine("");

            List<Gorev> gorevler = new List<Gorev>();

            LoadFromFile(gorevler);

            while (true)
            {
                Console.WriteLine("1. Add Task");
                Console.WriteLine("2. View Tasks");
                Console.WriteLine("3. Complete Task");
                Console.WriteLine("4. Update Task");
                Console.WriteLine("5. Delete Task");
                Console.WriteLine("6. Save to File");
                Console.WriteLine("7. Exit");

                Console.Write("Choose an option: ");
                string secim = Console.ReadLine();

                switch (secim)
                {
                    case "1":
                        AddTask(gorevler);
                        break;

                    case "2":
                        ViewTasks(gorevler);
                        break;

                    case "3":
                        CompleteTask(gorevler);
                        break;

                    case "4":
                        UpdateTask(gorevler);
                        break;

                    case "5":
                        DeleteTask(gorevler);
                        break;

                    case "6":
                        SaveToFile(gorevler);
                        break;

                    case "7":
                        return;

                    default:
                        Console.WriteLine("Invalid option!");
                        break;
                }
            }
        }

        static void AddTask(List<Gorev> gorevler)
        {
            Console.Write("Enter task title: ");
            string baslik = Console.ReadLine();

            Console.Write("Enter task description: ");
            string aciklama = Console.ReadLine();

            Console.Write("Enter task date (yyyy-MM-dd): ");
            DateTime tarih = DateTime.Parse(Console.ReadLine());

            Console.Write("Enter task priority: ");
            string oncelik = Console.ReadLine();

            Gorev gorev = new Gorev
            {
                Id = gorevler.Count == 0 ? 1 : gorevler.Max(g => g.Id) + 1,
                Baslik = baslik,
                Aciklama = aciklama,
                Tarih = tarih,
                Oncelik = oncelik,
                TamamlandiMi = false
            };

            gorevler.Add(gorev);
        }

        static void ViewTasks(List<Gorev> gorevler)
        {
            if (gorevler.Count == 0)
            {
                Console.WriteLine("No tasks available.");
                return;
            }

            Console.WriteLine("Tasks:");
            foreach (var gorev in gorevler)
            {
                Console.WriteLine($"ID: {gorev.Id}, Title: {gorev.Baslik}, Description: {gorev.Aciklama}, Date: {gorev.Tarih}, Priority: {gorev.Oncelik}, Completed: {gorev.TamamlandiMi}");
            }
        }

        static void CompleteTask(List<Gorev> gorevler)
        {
            Console.Write("Enter task ID to complete: ");
            int id = int.Parse(Console.ReadLine());
            var gorev = gorevler.FirstOrDefault(g => g.Id == id);
            if (gorev != null)
            {
                gorev.TamamlandiMi = true;
                Console.WriteLine("Task completed.");
            }
            else
            {
                Console.WriteLine("Task not found.");
            }
        }

        static void UpdateTask(List<Gorev> gorevler)
        {
            Console.Write("Enter task ID to update: ");
            int id = int.Parse(Console.ReadLine());
            var gorev = gorevler.FirstOrDefault(g => g.Id == id);
            if (gorev != null)
            {
                Console.Write("Enter new task title: ");
                gorev.Baslik = Console.ReadLine();
                Console.Write("Enter new task description: ");
                gorev.Aciklama = Console.ReadLine();
                Console.Write("Enter new task date (yyyy-MM-dd): ");
                gorev.Tarih = DateTime.Parse(Console.ReadLine());
                Console.Write("Enter new task priority: ");
                gorev.Oncelik = Console.ReadLine();
                Console.WriteLine("Task updated.");
            }
            else
            {
                Console.WriteLine("Task not found.");
            }
        }

        static void DeleteTask(List<Gorev> gorevler)
        {
            Console.Write("Enter task ID to delete: ");
            int id = int.Parse(Console.ReadLine());
            var gorev = gorevler.FirstOrDefault(g => g.Id == id);
            if (gorev != null)
            {
                gorevler.Remove(gorev);
                Console.WriteLine("Task deleted.");
            }
            else
            {
                Console.WriteLine("Task not found.");
            }
        }

        static void SaveToFile(List<Gorev> gorevler)
        {
            StreamWriter writer = new StreamWriter("tasks.txt");

            foreach (var gorev in gorevler)
            {
                writer.WriteLine($"{gorev.Id},{gorev.Baslik},{gorev.Aciklama},{gorev.Tarih},{gorev.Oncelik},{gorev.TamamlandiMi}");
            }
            writer.Close();
        }

        static void LoadFromFile(List<Gorev> gorevler)
        {
            if (!File.Exists("tasks.txt"))
            {
                return;
            }

            StreamReader reader = new StreamReader("tasks.txt");

            string satir = reader.ReadLine();
            while (satir != null)
            {
                var parcalar = satir.Split(',');
                Gorev gorev = new Gorev
                {
                    Id = int.Parse(parcalar[0]),
                    Baslik = parcalar[1],
                    Aciklama = parcalar[2],
                    Tarih = DateTime.Parse(parcalar[3]),
                    Oncelik = parcalar[4],
                    TamamlandiMi = bool.Parse(parcalar[5])
                };

                gorevler.Add(gorev);
                satir = reader.ReadLine();
            }
            reader.Close();
        }

    }   
}    
