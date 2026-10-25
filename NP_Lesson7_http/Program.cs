using NP_Lesson7_http.Models;
using System.Net;
using System.Net.Http.Json;

namespace NP_Lesson7_http;

public class Program
{
    static async Task Main()
    {
        //////////////////////////////////////////////////////////////////////////////

        // WebClient -> depracate version

        // var client = new WebClient();
        // var response = client.DownloadString("https://www.google.com/");
        // 
        // Console.WriteLine(response);

        //////////////////////////////////////////////////////////////////////////////

        // // HttpWebRequest -> depracate version

        // HttpWebRequest httpRequest = (HttpWebRequest)WebRequest.Create("https://www.google.com/");
        //
        // using HttpWebResponse response = (HttpWebResponse)httpRequest.GetResponse();
        //
        // using Stream responseStream = response.GetResponseStream();
        // using StreamReader reader = new StreamReader(responseStream);
        //
        // string responseText = reader.ReadToEnd();
        // Console.WriteLine(responseText);

        //////////////////////////////////////////////////////////////////////////////

        // HttpClient

        using var client = new HttpClient();

        // var response = await client.GetStringAsync("https://www.google.com/");
        // Console.WriteLine(response);

        // Request & Response


        // await client.PostAsync();
        // await client.GetAsync();
        // await client.PutAsync();
        // await client.DeleteAsync();


        var request = new HttpRequestMessage()
        {
            // RequestUri = new Uri("https://www.google.com/"),
            // RequestUri = new Uri("https://jsonplaceholder.typicode.com/posts/1"),
            RequestUri = new Uri("https://jsonplaceholder.typicode.com/posts"),
            Method = HttpMethod.Get
        };

        // var responseMessage = await client.SendAsync(request);
        // var context = await responseMessage.Content.ReadAsStringAsync();
        // Console.WriteLine(context);

        // // Post/1 endPoint muraciet -> yalniz 1 cavab goturmek ucun idi
        // var responseMessage = await client.SendAsync(request);
        // var context = await responseMessage.Content.ReadFromJsonAsync<Post>();
        // Console.WriteLine(context);



        // Posts -> coxlu postlari goturmek

        var responseMessage = await client.SendAsync(request);

        var posts = await responseMessage.Content.ReadFromJsonAsync<List<Post>>();


        foreach (var post in posts)
        {
            Console.WriteLine(post);
        }

    }
}
