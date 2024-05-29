using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaintTestController : ControllerBase
    {



        [HttpPost("new")]
        public IActionResult Create(string name)
        {
            using var conn = new System.Data.SqlClient.SqlConnection("");

            var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM Users WHERE Name = '" + name + "'";

            return Ok(cmd.ExecuteScalar());

        }
    }
}
