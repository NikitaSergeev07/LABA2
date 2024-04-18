using System;
using System.Net.Http;
using System.IO;
using System.Net.Http.Json;
using System.Reflection.Metadata;
using System.Diagnostics;

class Program
{
    static HttpClient httpClient = new HttpClient();
    
    static async Task Main()
    {
        
        httpClient.DefaultRequestHeaders.Add("User-Agent", "MyApp");

        try
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            var result = await GetResponse(httpClient, "https://api.hh.ru/vacancies");
            Console.WriteLine(result);
            stopwatch.Stop();
            Console.WriteLine($"Время выполнения: {stopwatch.ElapsedMilliseconds} мс");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        

    }
    static async Task<object> GetResponse(HttpClient httpClient, string url)
    {
        using HttpResponseMessage response = await httpClient.GetAsync(url);
        var content = await response.Content.ReadFromJsonAsync<object>();
        if (response.IsSuccessStatusCode)
        {
            return content;
        }
        else
        {
            throw new ArgumentException("Not valid response");
        }
    }


}