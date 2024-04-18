using System;
using System.Net.Http;
using System.IO;
using System.Net.Http.Json;
using System.Reflection.Metadata;
using System.Diagnostics;

class Program
{
    static HttpClient httpClient = new HttpClient();

    static void Main()
    {
        httpClient.DefaultRequestHeaders.Add("User-Agent", "MyApp1");

        try
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            GetResponse(httpClient, "https://api.hh.ru/vacancies");
            stopwatch.Stop();
            Console.WriteLine($"Время выполнения: {stopwatch.ElapsedMilliseconds} мс");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

    }
    static void GetResponse(HttpClient httpClient, string url)
    {
        HttpResponseMessage response = httpClient.GetAsync(url).Result;
        var content = response.Content.ReadAsStringAsync().Result;
        if (response.IsSuccessStatusCode)
        {
            Console.WriteLine(content);
        }
        else
        {
            throw new ArgumentException("Not valid response");
        }
    }


}