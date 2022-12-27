using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebEngage.Model;
using WebEngage.Models;

namespace WebEngage.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IHttpClientFactory factory;
        private WebEngageContext dbContext;
        public UserController(IHttpClientFactory factory, WebEngageContext dbContext)
        {
            this.factory = factory;
            this.dbContext = dbContext;
        }

        [HttpPost(Name = nameof(CreateUser))]
        public User CreateUser(UserRequest data, [FromRoute] string appCode)
        {
            HttpClient client = factory.CreateClient("myClient");
            var stringContent = new StringContent(JsonConvert.SerializeObject(data), System.Text.Encoding.UTF8, "application/json");
            var licenseCode = dbContext.Applications.FirstOrDefault(x=>x.AppCode==appCode);
            var response = client.PostAsync($"{licenseCode}/users",stringContent);
            var user = response.Result.Content.ReadFromJsonAsync<User>().Result;
            dbContext.Users.Add(user);
            dbContext.SaveChanges();
            return user;
        }

        [HttpPut(Name = nameof(UpdateUser))]
        public UserRequest UpdateUser(UserRequest data, [FromRoute] string appCode)
        {
            HttpClient client = factory.CreateClient("myClient");
            var stringContent = new StringContent(JsonConvert.SerializeObject(data), System.Text.Encoding.UTF8, "application/json");
            var licenseCode = dbContext.Applications.FirstOrDefault(x => x.AppCode == appCode);
            var user = dbContext.Users.FirstOrDefault(x=>x.UserId == data.UserId);
            var response = client.PutAsync($"{licenseCode}/users", stringContent);
            var result = response.Result.Content.ReadFromJsonAsync<UserRequest>().Result;
            if (user != null)
            {
                user.Email = data.Email;
                user.FirstName = data.FirstName;
                user.LastName = data.LastName;
            }
            dbContext.SaveChanges();
            return result;
        }
    }
}
