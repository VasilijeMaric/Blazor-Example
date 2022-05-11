using Blazor.Example.Core.Models;
using Blazor.Example.Shared.Models;
using Blazor.Example.Shared.Services;
using Microsoft.AspNetCore.Mvc;

namespace Blazor.Example.Core.Controllers
{
    public class TestController : Controller
    {
        private readonly StateContainer _stateContainer;

        public TestController(StateContainer stateContainer)
        {
            _stateContainer = stateContainer;
        } 

        [HttpGet]
        public IActionResult Index()
        {
            return View(new TestViewModel
            {
                SavedState = _stateContainer.ContactUs == null 
                    ? null 
                    : $"{_stateContainer.ContactUs.Name}: {_stateContainer.ContactUs.Comments}"
            });
        }

        [HttpGet("/Test/ContactUs")]
        public IActionResult GetContactUs()
        {
            return Json(_stateContainer.ContactUs);
        }

        [HttpPost("/Test/ContactUs")]
        public IActionResult PostContactUs([FromBody] ContactUsModel formModel)
        {
            _stateContainer.ContactUs = formModel;

            return Ok();
        }
    }
}
