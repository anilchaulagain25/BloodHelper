using BLOOD_HELP.Dal;
using BLOOD_HELP.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BLOOD_HELP.Controllers
{
    public class ReceiverController : Controller
    {

        private readonly IHttpContextAccessor _httpAccessor;

        private readonly ReceiverDal _receiverDal;

        public ReceiverController(IHttpContextAccessor httpAccessor)
        {
            _httpAccessor = httpAccessor;
            _receiverDal = new ReceiverDal();

        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(ReceiverLoginModel model)
        {
            if (ModelState.IsValid)
            {
                ResultSet result = _receiverDal.AuthenticateReceiver(model.Username, model.Password);
                if (result.Success)
                {
                    ReceiverModel resp = result.Data as ReceiverModel;
                    HttpContext.Session.SetString("CLIENT", "RECEIVER");
                    HttpContext.Session.SetInt32("ID", resp.Id);
                    HttpContext.Session.SetString("USERNAME", resp.Username);
                    HttpContext.Session.SetString("NAME", resp.Name);
                }
                ViewBag.result = result;
                return View();
            }
            else
            {
                return View(model);
            }

        }

        [HttpGet]
        public IActionResult Signup()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Signup(ReceiverModel model)
        {
            if (ModelState.IsValid)
            {
                model.IpAddress = _httpAccessor.HttpContext.Connection.RemoteIpAddress.ToString();
                ResultSet result = _receiverDal.CreateReceiver(model);
                ViewBag.result = result;
                if (result.Success)
                {
                    ModelState.Clear();
                    model = new ReceiverModel();
                }
                return View(model);
            }
            else
            {
                return View(model);
            }
        }


    }

}