using HttpClientDemo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

namespace HttpClientDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpClientFactory _clientFactory;

        public HomeController(ILogger<HomeController> logger, IHttpClientFactory clientFactory)
        {
            _logger = logger;
            _clientFactory = clientFactory;
        }

        public async Task<IActionResult> Index1([FromServices] IHttpClientFactory factory)        
        {
            Authenticate(factory);
            var user =  Authenticate(factory).Result;
            if (user == null)
                return View();

            string data;
            //var request = new HttpRequestMessage(HttpMethod.Get, "http://localhost:4904/weatherforecast");
            var request = new HttpRequestMessage(HttpMethod.Get, "http://localhost:63225/api/Employee");
            request.Headers.Add("Authorization", "Bearer " + user.Token);
            var client = _clientFactory.CreateClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var responseStream = await response.Content.ReadAsStreamAsync();
                data = await JsonSerializer.DeserializeAsync<string>(responseStream);
                //data = await JsonSerializer.DeserializeAsync<IEnumerable<WeatherForecast>>(responseStream);
            }
            else
            {
                data = String.Empty;
            }
            return null;
        }

        [HttpGet]
        public async Task<User> Authenticate( IHttpClientFactory factory)
        {

            var request = new HttpRequestMessage(HttpMethod.Post, "http://localhost:63225/api/accounts/Login");

            request.Content = new StringContent(JsonSerializer.Serialize(
                new UserInfo() { Email = "asif@example.com", Passowrd = "P@ssw0rd!" }));

            request.Content.Headers.ContentType = new MediaTypeWithQualityHeaderValue("application/json");

            var client = _clientFactory.CreateClient();
            
            //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            //var response = await client.SendAsync(request);
            var response = await client.PostAsync(request.RequestUri, request.Content);

            User user = null;
            if (response.IsSuccessStatusCode)
            {
                var responseStream = await response.Content.ReadAsStringAsync();
                user = Newtonsoft.Json.JsonConvert.DeserializeObject<User>(responseStream);

            }
            return user;
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
