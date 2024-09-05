using LeageBillete_api.Model.DTO;
using LeageBillete_api.Model.RequestResp;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace TestProjectLeageBillete
{
    public class BilletAdminControllerTest : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;
        private string _token;

        public  BilletAdminControllerTest(WebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
           
        }

        [Fact]
        public async Task LeagesActiveReturnList()
        {
         
            if (string.IsNullOrEmpty(_token))
            {
                await getTokenLoginAdmin();
                if (string.IsNullOrEmpty(_token))
                    throw new InvalidOperationException("Token not available. Ensure Login test is run first.");
            }

            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);

            // Act
            var response = await _client.GetAsync("/api/BilletAdmin/leagesActives");

            // Assert
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            // Aquí puedes hacer las aserciones necesarias para tu prueba
            Assert.NotEmpty(responseString);
        }

        [Fact]
        public async Task EventDetailListReturnList()
        {

            if (string.IsNullOrEmpty(_token))
            {
                await getTokenLoginAdmin();
                if (string.IsNullOrEmpty(_token))
                    throw new InvalidOperationException("Token not available. Ensure Login test is run first.");
            }

            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);

            // Act
            var response = await _client.GetAsync("/api/BilletAdmin/eventdetaillist");

            // Assert
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            // Aquí puedes hacer las aserciones necesarias para tu prueba
            Assert.NotEmpty(responseString);
        }


        [Fact]
        public async Task CreateEvent()
        {

            if (string.IsNullOrEmpty(_token))
            {
                await getTokenLoginAdmin();
                if (string.IsNullOrEmpty(_token))
                    throw new InvalidOperationException("Token not available. Ensure Login test is run first.");
            }

            var addModel = new Event_leage_DTO
            {
                Name = "test_" + DateTime.Now.Ticks.ToString(),
                Description = "test event",
                Location = "Test Location",
                Event_Days = new List<Event_day_DTO> {
                    new Event_day_DTO { Area = "A", Capacity_ticket = 10, EventDate = DateTime.Now.AddDays(10)},
                    new Event_day_DTO { Area = "B", Capacity_ticket = 11, EventDate = DateTime.Now.AddDays(11)}
                },
                Price_tickets = new List<Price_ticket_DTO>
                {
                    new Price_ticket_DTO { Name = "Prix Normal", Is_all_event = false, Price_unit = 20, Prix_eleve = false,Quantite_ticket_min = 1},
                    new Price_ticket_DTO { Name = "Prix Groupe", Is_all_event = false, Price_unit = 15, Prix_eleve = false,Quantite_ticket_min = 5},
                }
            };

            var json = JsonConvert.SerializeObject(addModel);
            var content = new StringContent(json, Encoding.UTF8, "application/json");


            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);

            // Act
            var response = await _client.PostAsync("/api/BilletAdmin/addEvent", content);

            // Assert
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            // Aquí puedes hacer las aserciones necesarias para tu prueba
            Assert.NotEmpty(responseString);
        }




        public async Task getTokenLoginAdmin()
        {
            // Arrange
            var loginModel = new { Username = "admin", Password = "root123123" };
            var json = JsonConvert.SerializeObject(loginModel);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            // Act
            var response = await _client.PostAsync("/api/Authentification/login", content);

            // Assert
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            var responseObject = JsonConvert.DeserializeObject<AuthentificationResp>(responseString);
            _token = responseObject?.Token;

        }
    }
}
