using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace ASPNETHttpClientTester
{
    public class MyBetterServiceClient
    {
        private readonly IHttpClientFactory _httpClientFactory;

        // Constructor
        public MyBetterServiceClient(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<ToDo> GetToDo()
        {
            var httpClient = _httpClientFactory.CreateClient("ToDoClient");

            // Wywołanie API
            var response = await httpClient.GetAsync("/todos/1");

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
