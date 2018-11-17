using BLOOD_HELP.Dal;
using BLOOD_HELP.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace BLOOD_HELP.Controllers
{
    public class HospitalController : Controller
    {
        private readonly HospitalDal _hospitalDal;
        private readonly IHttpContextAccessor _httpAccessor;
        public HospitalController(IHttpContextAccessor httpAccessor)
        {
            _httpAccessor = httpAccessor;
            _hospitalDal = new HospitalDal();
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(HospitalLoginModel model)
        {
            if (ModelState.IsValid)
            {
                ResultSet result = _hospitalDal.AuthenticateHospital(model.Username, model.Password);
                if (result.Success)
                {
                    HospitalModel resp = result.Data as HospitalModel;
                    HttpContext.Session.SetString("CLIENT", "HOSPITAL");
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
        public IActionResult Signup(HospitalModel model)
        {
            if (ModelState.IsValid)
            {
                model.IpAddress = _httpAccessor.HttpContext.Connection.RemoteIpAddress.ToString();
                ResultSet result = _hospitalDal.CreateHospital(model);
                ViewBag.result = result;
                if (result.Success)
                {
                    ModelState.Clear();
                    model = new HospitalModel();
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
