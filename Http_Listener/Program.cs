using System.Net;

namespace Http_Listener;

public class Program
{
    static async Task Main(string[] args)
    {
        using var listener = new HttpListener();

        listener.Prefixes.Add(@"http://localhost:27001/");
        listener.Prefixes.Add(@"http://localhost:27002/");

        listener.Start();

        Console.WriteLine("Listener started...");

        while (true)
        {
            var context = await listener.GetContextAsync();

            var request = context.Request;
            var response = context.Response;

            // http://localhost:27001/name=kamran

            for (int i = 0; i < request.QueryString.Count; i++)
            {
                var value = request.QueryString[i];
                var key = request.QueryString.Keys[i];

                Console.WriteLine($"{key} - {value}");
            }

            response.ContentType = "application/json";

            response.Headers.Add("Content-Type","text/html");

            response.StatusCode = (int)HttpStatusCode.OK;

            var writer = new StreamWriter(response.OutputStream);

            await writer.WriteAsync("<h1 style='color: blue'> Welcome Baku, Azerbaijan </h1>");


            writer.Close();
 
        }

    }
}
