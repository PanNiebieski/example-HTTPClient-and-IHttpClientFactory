using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;

namespace ASPNETHttpClientTester.Controlers
{
    public class HomeController : Controller
    {
        private IHttpClientFactory _fac;

        public HomeController(IHttpClientFactory fac, TodoTypedClient cl)
        {
            _fac = fac;
            _cl = cl;
        }

        private TodoTypedClient _cl;

        public async Task<string> Index2Async()
        {
            var todo = await _cl.GetToDo();

            return todo.Title + " " + todo.Completed;
        }

        public async Task<string> IndexAsync()
        {
            MyBetterServiceClient myBetterServiceClient
                = new MyBetterServiceClient(_fac);

            var todo = await myBetterServiceClient.GetToDo();

            return todo.Title + " " + todo.Completed;
        }

    }
}
