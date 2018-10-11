using System;
using BLOOD_HELP.Dal;
using BLOOD_HELP.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BLOOD_HELP.Controllers
{
    public class BloodSampleController : Controller
    {
        private readonly BloodSampleDal _bloodSampleDal;
        public BloodSampleController()
        {
            _bloodSampleDal = new BloodSampleDal();
        }

        [HttpGet]
        public IActionResult Index()
        {
            if (!IsValidSession())
                return View("~/views/Hospital/Login.cshtml");
            return View();
        }

        [HttpGet]
        public IActionResult Manage()
        {
            if (!IsValidSession())
                return View("~/views/Hospital/Login.cshtml");
            return View();
        }

        [HttpPost]
        public IActionResult Manage(BloodSampleModel model)
        {
            if (!IsValidSession())
                return View("~/views/Hospital/Login.cshtml");
            if (ModelState.IsValid)
            {
                int hospitalId = HttpContext.Session.GetInt32("ID") ?? 0;
                model.HospitalId = hospitalId;
                ResultSet result = _bloodSampleDal.CreateBloddSample(model);
                ViewBag.result = result;
                if (result.Success)
                {
                    model=new BloodSampleModel();
                    ModelState.Clear();
                }
            }
            return View(model);
        }
        [NonAction]
        private bool IsValidSession()
        {
            string client = HttpContext.Session.GetString("CLIENT");

            if (string.IsNullOrEmpty(client))
            {
                ViewBag.result = new ResultSet { Success = false, Message = "YOU MUST BE LOGIN TO CREATE BLOOD SAMPLE" };
                return false;
            }
            else if (client == "RECEIVER")
            {
                ViewBag.result = new ResultSet { Success = false, Message = "YOU ARE LOGIN FROM RECEIVER ACCOUNT, TO CREATE BLOOD YOU MUST BE LOGIN FROM HOSPITAL ACCOUNT" };
                return false;
            }
            else
                return true;
        }

    }
}