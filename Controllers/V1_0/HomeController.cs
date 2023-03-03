using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Portfolio.BackEnd.Api.Models;
using Serilog;
using Swashbuckle.AspNetCore.Annotations;

namespace Portfolio.BackEnd.Api.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [Produces("application/json")]
    [Consumes("application/json")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        #region PRIVATE PROPERTIES
        private readonly Serilog.ILogger _logger;
        #endregion

        #region CONSTRUCTOR
        public HomeController()
        {
            _logger = Log.ForContext<HomeController>();
        }
        #endregion

        #region PUBLIC

        [SwaggerOperation("Login to application")]
        [SwaggerResponse(200, "JwTokenRequest", typeof(string))]
        [ProducesResponseType(200)]
        [HttpPost]
        public async Task<IActionResult> LogIn([FromBody] LoginRequest request)
        {
            try
            {
                _logger.ForContext("LogInRequest", request);
                var response = new
                {
                    Name = "Maxime",
                    LastName = "Thifagne"
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"LogIn > Error {ex.Message}");
                return BadRequest(ex);
            }
        }

        #endregion
    }
}
