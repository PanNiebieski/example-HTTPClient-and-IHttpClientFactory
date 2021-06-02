using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace ASPNETHttpClientTester
{
    public class TodoTypedClient
    {
        private readonly HttpClient _client;

        // Constructor
        public TodoTypedClient(HttpClient client)
        {
            _client = client;
            _client.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/");
            _client.Timeout = new TimeSpan(0, 0, 30);
            _client.DefaultRequestHeaders.Clear();
        }

        public async Task<ToDo> GetToDo()
        {
            // Wywołanie API
            var response = await _client.GetAsync("/todos/1");

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
