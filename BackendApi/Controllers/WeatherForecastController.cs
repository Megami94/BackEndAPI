using Microsoft.AspNetCore.Mvc;

namespace BackendApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static List<string> Summaries = new()
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public List<string> Get()
        {
            return Summaries;
        }

        [HttpPost]

        public IActionResult Add(string name)
        {
            Summaries.Add(name);
            return Ok();
        }

        [HttpPut]

        public IActionResult Update(int index, string name)
        {
            if (index < 0 || index >= Summaries.Count) {
                return BadRequest("����� ������ ��������!");
            }

            Summaries[index] = name;
            return Ok();
        }

        [HttpDelete]

        public IActionResult Delete(int index)
        {
            if (index < 0 || index >= Summaries.Count)
            {
                return BadRequest("����� ������ ��������!");
            }

            Summaries.RemoveAt(index);
            return Ok();
        }

        [HttpGet("{index}")]

        public string Get(int index) 
        {
            if (index < 0 || index >= Summaries.Count)
            {
                return "����� ������ ��������!";
            }
            return Summaries[index];
        }

        [HttpGet("find-by-name")]

        public int Get(string name)
        {
            int count = 0;
            foreach (var i in Summaries)
            {
                if (name == i)
                {
                    count++;
                }
            }

            return count;
        }

        [HttpGet("Sort-by-strategy")]

        public IActionResult GetAll(int? sortStrategy)
        {
            if (sortStrategy == null)
            {
                //Get();
                return Ok();
            }

            else if (sortStrategy == 1)
            {
                Summaries.Sort();
                return Ok();
            }

            else if (sortStrategy == -1)
            {
                Summaries.Sort();
                Summaries.Reverse();
                return Ok();
            }
            else
            {
                return BadRequest("������������ �������� ��������� sortStrategy");
            }
            
        }
    }
}
