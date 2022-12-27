using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebEngage.Model;
using WebEngage.Models;

namespace WebEngage.Controllers
{
    public class EventController : ControllerBase
    {
        private IHttpClientFactory factory;
        private WebEngageContext dbContext;
        public EventController(IHttpClientFactory factory, WebEngageContext dbContext)
        {
            this.factory = factory;
            this.dbContext = dbContext;
        }

        [HttpPost(Name = nameof(CreateEvent))]
        public Event CreateEvent(EventRequest data, [FromRoute] string appCode)
        {
            HttpClient client = factory.CreateClient("myClient");
            var stringContent = new StringContent(JsonConvert.SerializeObject(data), System.Text.Encoding.UTF8, "application/json");
            var licenseCode = dbContext.Applications.FirstOrDefault(x => x.AppCode == appCode);
            var response = client.PostAsync($"{licenseCode}/events", stringContent);
            var appEvent = response.Result.Content.ReadFromJsonAsync<Event>().Result;
            dbContext.Events.Add(appEvent);
            dbContext.SaveChanges();
            return appEvent;
        }
    }
}
