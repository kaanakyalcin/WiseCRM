using Microsoft.AspNetCore.Mvc;
using StackExchange.Redis;

namespace WiseCRM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CacheController : ControllerBase
    {
        private readonly IDatabase _database;

        public CacheController(/*IDatabase database*/)
        {
            //_database = database;
            ConfigurationOptions option = new ConfigurationOptions
            {
                AbortOnConnectFail = false,
                EndPoints = { "rediscache" }
            };
            var redis = ConnectionMultiplexer.Connect("rediscache");
            _database = redis.GetDatabase();
        }

        [HttpGet]
        public ActionResult<string> Get(string key)
        {
            var value = _database.StringGet(key);
            return value.ToString();
        }

        [HttpPost]
        public void Post(string key, string value)
        {
            _database.StringSet(key, value);
        }
    }
}
