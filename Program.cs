List<string> TaskList = new List<string>();

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


int ShowMainMenu()
{
    Console.WriteLine("----------------------------------------");
    Console.WriteLine("Ingrese la opción a realizar: ");
    Console.WriteLine("1. Nueva tarea");
    Console.WriteLine("2. Remover tarea");
    Console.WriteLine("3. Tareas pendientes");
    Console.WriteLine("4. Salir");
    string optionSelected = Console.ReadLine();
    return Convert.ToInt32(optionSelected);
}

void ShowMenuRemove()
{
    try
    {
        Console.WriteLine("Ingrese el número de la tarea a remover: ");

        ShowTaskList();

        string numberTaskToRemove = Console.ReadLine();
        uint indexToRemove = 0;
        if (!uint.TryParse(numberTaskToRemove, out indexToRemove) || ((indexToRemove - 1) > (TaskList.Count - 1)))
        {
            Console.WriteLine("El valor ingresado no es valido");
            return;
        }

        int index = (int)indexToRemove - 1;

        // Remove one position because the array starts in 0
        string taskRemoved = TaskList[index];
        TaskList.RemoveAt(index);
        Console.WriteLine("Tarea " + taskRemoved + " eliminada");
    }
    catch (Exception)
    {
        Console.WriteLine("Ha ocurrido un error al eliminar la tarea");
    }
}

void ShowMenuAdd()
{
    try
    {
        Console.WriteLine("Ingrese el nombre de la tarea: ");
        string newTask = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(newTask))
        {
            Console.WriteLine("Por favor ingresar una tarea con formato valido");
            return;
        }
        TaskList.Add(newTask);
        Console.WriteLine("Tarea registrada");
    }
    catch (Exception)
    {
        Console.WriteLine("Ha ocurrido un error al eliminar la tarea");
    }
}

void ShowMenuTaskList()
{
    if (TaskList?.Count > 0)
    {
        ShowTaskList();
    }
    else
    {
        Console.WriteLine("No hay tareas por realizar");
    }
}

void ShowTaskList()
{
    Console.WriteLine("----------------------------------------");
    for (int indexTask = 0; indexTask < TaskList.Count; indexTask++)
    {
        Console.WriteLine($"{(indexTask + 1)} . {TaskList[indexTask]}");
    }
    Console.WriteLine("----------------------------------------");
}

public enum Menu
{
    Add = 1,
    Remove = 2,
    List = 3,
    Exit = 4
}
