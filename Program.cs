using System;
using System.Collections.Generic;

namespace ToDo
{
    internal class Program
    {

        public static List<string> TaskList { get; set; }

        static void Main(string[] args)
        {
            TaskList = new List<string>();
            int menuSelected = 0;
            do
            {
                menuSelected = ShowMainMenu();
                if (menuSelected == (int)Menu.Add)
                {
                    ShowMenuAdd();
                }
                else if (menuSelected == (int)Menu.Remove)
                {
                    ShowMenuRemove();
                }
                else if (menuSelected == (int)Menu.List)
                {
                    ShowMenuTaskList();
                }
            } while (menuSelected != (int)Menu.Exit);
        }
        /// <summary>
        /// Show the main menu 
        /// </summary>
        /// <returns>Returns option indicated by user</returns>
        public static int ShowMainMenu()
        {
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("Ingrese la opción a realizar: ");
            Console.WriteLine("1. Nueva tarea");
            Console.WriteLine("2. Remover tarea");
            Console.WriteLine("3. Tareas pendientes");
            Console.WriteLine("4. Salir");

            // Read line
            string optionSelected = Console.ReadLine();
            return Convert.ToInt32(optionSelected);
        }

        public static void ShowMenuRemove()
        {
            try
            {
                Console.WriteLine("Ingrese el número de la tarea a remover: ");
                // Show current taks
                for (int indexTask = 0; indexTask < TaskList.Count; indexTask++)
                {
                    Console.WriteLine((indexTask + 1) + ". " + TaskList[indexTask]);
                }
                Console.WriteLine("----------------------------------------");

                string numberTaskToRemove = Console.ReadLine();
                // Remove one position
                int indexToRemove = Convert.ToInt32(numberTaskToRemove) - 1;
                if (indexToRemove > -1)
                {
                    if (TaskList.Count > 0)
                    {
                        string taskRemoved = TaskList[indexToRemove];
                        TaskList.RemoveAt(indexToRemove);
                        Console.WriteLine("Tarea " + taskRemoved + " eliminada");
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        public static void ShowMenuAdd()
        {
            try
            {
                Console.WriteLine("Ingrese el nombre de la tarea: ");
                string newTask = Console.ReadLine();
                TaskList.Add(newTask);
                Console.WriteLine("Tarea registrada");
            }
            catch (Exception)
            {
            }
        }

        public static void ShowMenuTaskList()
        {
            if (TaskList == null || TaskList.Count == 0)
            {
                Console.WriteLine("No hay tareas por realizar");
            } 
            else
            {
                Console.WriteLine("----------------------------------------");
                for (int indexTask = 0; indexTask < TaskList.Count; indexTask++)
                {
                    Console.WriteLine((indexTask + 1) + ". " + TaskList[indexTask]);
                }
                Console.WriteLine("----------------------------------------");
            }
        }
    }

    public enum Menu
    {
        Add = 1,
        Remove = 2,
        List = 3,
        Exit = 4
    }
}
