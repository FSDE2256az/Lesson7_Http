namespace Http_Client;

public class Program
{
    static async Task Main(string[] args)
    {
        using var client = new HttpClient();

        var response = await client.GetAsync("http://localhost:27001/?id=1&name=kamran");
        var context = await response.Content.ReadAsStringAsync();

        Console.WriteLine(context);
    }
}
