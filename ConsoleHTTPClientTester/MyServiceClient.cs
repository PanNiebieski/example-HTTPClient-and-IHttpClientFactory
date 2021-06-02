
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace ConsoleHTTPClientTester
{
    public class MyServiceClient
    {
        private static HttpClient _httpClient = new HttpClient();

        public MyServiceClient()
        {
            _httpClient.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/");
            _httpClient.Timeout = new TimeSpan(0, 0, 30);
        }

        public async Task<ToDo> GetToDo()
        {
            // Wywołanie API
            var response = await _httpClient.GetAsync("/todos/1");

            // Sprawdzenie czy mamy HTTP 200 OK
            response.EnsureSuccessStatusCode();

            // Odczytanie JSON z odpowiedzi
            var content = await response.Content.ReadAsStringAsync();

            // Deserializacja TODO
            var todo = JsonConvert.DeserializeObject<ToDo>(content);

            return todo;
        }
    }
}
