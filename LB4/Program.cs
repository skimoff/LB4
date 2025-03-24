using System.Text.RegularExpressions;
using System.Threading.Channels;

namespace LB4;

class Program
{
    static void task1()
    {
        string s = "abcdefghijklmnopqrstuv18340";
        string[] s_ =
        {
            "abcdefghijklmnoasdfasdpqrstuv18340",
            "abcdefghijklmnopqrstuv18340",
            "abcdefghijklmnopqdrstuv18340",
            "abcdefghijklmnsaopqrstuv18340"
        };

        foreach (string str in s_)
        {
            bool x = Regex.IsMatch(str, s);
            Console.WriteLine(x);
        }

        Console.WriteLine();
        string guid = @"^\{?[0-9a-fA-F]{8}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{12}\}?$";
        string[] testGuid =
        {
            "e02fd0e4-00fd-090A-ca30-0d00a0038ba0",
            "{e02fd0e4-00fd-090A-ca30-0d00a0038ba0}",
            "E02FD0E4-00FD-090A-CA30-0D00A0038BA0",
            "e02fd0e400fd090Aca300d00a0038ba0"
        };
        foreach (string str in testGuid)
        {
            bool y = Regex.IsMatch(str, guid);
            Console.WriteLine(y.ToString());
        }
    }

    static void fillArray(string[] arr, int n)
    {
        Console.WriteLine("enter number 0/1");
        string pattern = "^[01]+$";
        bool check;
        for (int i = 0; i < n; i++)
        {
            do
            {
                arr[i] = Console.ReadLine();
                check = Regex.IsMatch(arr[i], pattern);
                if (!check)
                    Console.WriteLine("enter number only 0/1");
            } while (!check);
        }
    }

    static void task2()
    {
        StreamReader input = new StreamReader("in.txt");
        StreamWriter output = new StreamWriter("out.txt");

        Console.WriteLine("enter how str(<=10)");
        int n = Convert.ToInt32(Console.ReadLine());
        if (n > 10) n = 10;

        string[] numbers = new String[n];

        Console.WriteLine("text in keyboard(1) or file(2)");
        int pr = Convert.ToInt32(Console.ReadLine());
        if (pr == 1)
        {
            fillArray(numbers, n);
        }
        else
        {
            for (int i = 0; i < n; i++)
                numbers[i] = input.ReadLine();
        }

        foreach (string s in numbers)
        {
            Console.WriteLine(s + ' ' + Convert.ToInt32(s, 2));
            output.WriteLine(Convert.ToInt32(s, 2));
        }

        input.Close();
        output.Close();
    }

    static void Main(string[] args)
    {
        task1();
        task2();
        Console.ReadKey();
    }
}