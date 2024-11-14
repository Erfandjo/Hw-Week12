using Hw_Week12;
using Hw_Week12.Entities;
using Hw_Week12.Enum;
using Hw_Week12.Service;




TaskService taskService = new TaskService();
Authentication authentication = new Authentication();
string userName = string.Empty;
string password = string.Empty;

while (true)
{

    Console.WriteLine("1) Login");
    Console.WriteLine("2) Register");
    Console.Write("Please Select Number : ");
    int option = Convert.ToInt32(Console.ReadLine());
    switch (option)
    {
        case 1:
            Console.Clear();
            Login();
            break;
        case 2:
            Console.Clear();
            Register();
            break;

    }

    while (OnlineUser.CurrentUser != null)
    {
        menu();
        int option2 = Convert.ToInt32(Console.ReadLine());
        switch (option2)
        {
            case 1:
                Add();
                break;
            case 2:
                Get();
                Console.ReadKey();
                break;
            case 3:
                Update();
                break;
            case 4:
                Remove();
                break;
            case 5:
                ChangeState();
                break;
            case 6:
                Search();
                break;
            case 7:
                authentication.LogOut();
                break;
        }
    }




}


void menu()
{
    Console.Clear();
    Console.WriteLine("1) Add Task");
    Console.WriteLine("2) Get Tasks");
    Console.WriteLine("3) Update Task");
    Console.WriteLine("4) Delete Task");
    Console.WriteLine("5) Change State");
    Console.WriteLine("6) Search Task");
    Console.WriteLine("7) Log Out");
    Console.Write("Please Select For Number : ");

}
void Add()
{
    Console.Clear();
    Console.Write("Please Enter Title : ");
    string title = Console.ReadLine();
    Console.Write("Please Enter Date To Done : ");
    DateTime date = Convert.ToDateTime(Console.ReadLine());
    Console.Write("Please Enter Order : ");
    int order = Convert.ToInt32(Console.ReadLine());
    taskService.Add(title, date, order);
}
void Get()
{
    Console.Clear();
    taskService.GetAll();

}
void Update()
{
    Console.Clear();
    Get();
    Console.Write("Please Enter Id : ");
    int id = Convert.ToInt32(Console.ReadLine());
    Console.Clear();
    Console.Write("Please Enter Title : ");
    string title = Console.ReadLine();
    Console.Write("Please Enter Date To Done : ");
    DateTime date = Convert.ToDateTime(Console.ReadLine());
    Console.Write("Please Enter Order : ");
    int order = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine(taskService.Update(id, title, order, date).Message);
    Console.ReadKey();
}
void Remove()
{
    Console.Clear();
    Get();
    Console.Write("Please Enter Id : ");
    int id = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine(taskService.Remove(id).Message);
    Console.ReadKey();
}
void ChangeState()
{
    Console.Clear();
    Get();
    Console.Write("Please Enter Id : ");
    int id = Convert.ToInt32(Console.ReadLine());
    Console.Clear();
    Console.Write($"Please Enter State ({StateEnum.InPending} = {(int)StateEnum.InPending} , {StateEnum.Done} = {(int)StateEnum.Done} , {StateEnum.Cancelled} = {(int)StateEnum.Cancelled} ) : ");
    int state = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine(taskService.UpdateState(id, state).Message);
    Console.ReadKey();
}
void Search()
{
    Console.Clear();
    Console.Write("Please Enter : ");
    string str = Console.ReadLine();
    taskService.Search(str);
    Console.ReadKey();
}
void Login()
{
    Console.Write("Please Enter User Name : ");
    userName = Console.ReadLine();
    Console.Write("Please Enter Password : ");
    password = Console.ReadLine();
    Console.WriteLine(authentication.Login(userName, password).Message);
}
void Register()
{
    Console.Write("Please Enter User Name : ");
    userName = Console.ReadLine();
    Console.Write("Please Enter Password : ");
    password = Console.ReadLine();
    User u = new User()
    {
        UserName = userName,
    };
    Console.WriteLine(authentication.Register(u, password).Message);
}