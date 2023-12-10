using System.Threading.Tasks;
namespace Async;
class Program
{
    static async Task Main(string[] args)
    {
        /*await DoSomethingAsync();
        await Task.Run(() => Console.WriteLine("Hello, world!"));
        await Bericht1();
        SyncFunction();
        await Bericht2();
        SyncFunction();*/
        await Mijn.Hoofd();
    }
    public static async Task Bericht1()
    {
        Console.WriteLine("In bericht 1");
        await Task.Delay(2000);
        Console.WriteLine("In bericht 1 klaar");
    }
    public static void SyncFunction()
    {
        Console.WriteLine("SyncFunction");
    }

    public static async Task Bericht2()
    {
        Console.WriteLine("In bericht 2");
        await Task.Delay(2000);
        Console.WriteLine("In bericht 2 klaar");
    }
    static async Task DoSomethingAsync()
    {
        Console.WriteLine("Start");
        await Task.Delay(1000);
        Console.WriteLine("End");
    }
}