namespace TelegramConsole
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1.Login");
            Console.WriteLine("2.Registration");

            int log = int.Parse(Console.ReadLine());

            switch (log)
            {
                case 1:
                    Console.Write("UserName: ");
                    string userNameLog = Console.ReadLine();
                    bool res = DataContext.CheackUserName(userNameLog);

                    if (res)
                    {
                        WhileTrue(userNameLog);
                    }
                    Console.WriteLine("User Not Found");
                    break;

                case 2:
                    Console.Write("UserName: ");
                    string userName = Console.ReadLine();
                    Console.Write("FirstName: ");
                    string firstName = Console.ReadLine();
                    Console.Write("LastName: ");
                    string lastName = Console.ReadLine();

                    DataContext.CreateUser(userName, firstName, lastName);
                    WhileTrue(userName);
                    break;
            }
        }

        public static void WhileTrue(string userName)
        {
            while (true)
            {
                Console.WriteLine("1. SendMessage");
                Console.WriteLine("2. GetAllMessages");
                int result = int.Parse(Console.ReadLine());

                switch (result)
                {
                    case 1:
                        Console.Write("Text: ");
                        string text = Console.ReadLine();
                        DataContext.SendMessage(text, userName);
                        Console.Write("Jo'natildi");
                        Thread.Sleep(2000);
                        Console.Clear();
                        break;
                    case 2:
                        DataContext.GetAllMessages();
                        break;
                }
            }
        }
    }
}