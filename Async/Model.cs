namespace Async;
public class DownloadSource
{
    private const int TOTAL = 50;
    public async Task DownloadAsync()
    {
        //Hier komt de code voor het downloaden
        Console.WriteLine("Awaiting downloads...");
        //Wacht 3 seconden
        await Task.Delay(3000);
        //Maak een lijst van strings met een string alvast erin.
        var source = new List<string> { "Downloading from Source" };
        //Maak een lijst van integers van 0 tot 50
        var download = Enumerable.Range(0, TOTAL);
        Console.WriteLine(download);

        foreach (var downloads in download)
        {
            var result = await Task.Run(() => source
              .Select((value, number) => new { Value = value, Number = number })
              .OrderBy(d => d.Number)
              .ToList());

            result.ForEach(d =>
            {
                Console.WriteLine($"Task: {source[d.Number]} {downloads + 1}...");
            });
        }
    }


    public async Task SourceAsync()
    {
        await Task.Delay(1500);
        var process = new List<string> { "Processing data from Source" };
        Console.WriteLine(process.ToString());
        var download = Enumerable.Range(0, TOTAL);

        foreach (var processes in download)
        {
            var result = await Task.Run(() => process
              .Select((value, number) => new { Value = value, Number = number })
              .OrderBy(p => p.Number)
              .ToList());

            result.ForEach(p =>
            {
                var random = new Random().Next(1, TOTAL);
                Console.WriteLine($"Process: {process[p.Number]} {processes + 1} {random}MB / {random}MB...");
                Task.Delay(75).Wait();
            });
        }

        Console.WriteLine("All downloads and processes completed!!!");
        await Task.CompletedTask;
    }
}