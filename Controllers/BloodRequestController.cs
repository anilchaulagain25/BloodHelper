using System.Collections.Generic;
using System.Data;
using System.Linq;
using BLOOD_HELP.Dal;
using BLOOD_HELP.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BLOOD_HELP.Controllers
{
    public class BloodRequestController : Controller
    {
        private readonly BloodRequestDal _bloodRequestDao;
        public BloodRequestController()
        {
            _bloodRequestDao = new BloodRequestDal();
        }
        [HttpGet]
        public IActionResult Index()
        {
            if (!IsValidSession())
                return View("~/views/Hospital/Login.cshtml");
            IList<BloodRequest> list = new List<BloodRequest>();
            int hospitalId = HttpContext.Session.GetInt32("ID") ?? 0;
            DataTable dataTable = _bloodRequestDao.GetRequestList(hospitalId);

            list = dataTable.Select().AsEnumerable().Select(x => new BloodRequest
            {
                User = x["FULL_NAME"].ToString(),
                BloodGroup = x["BLOOD_GROUP"].ToString(),
                ReleaseDate = x["RELEASED_DATE"].ToString(),
                RequestDate = x["REQUESTED_DATE"].ToString()
            }).ToList();

            return View(list);
        }
        [NonAction]
        private bool IsValidSession()
        {
            string client = HttpContext.Session.GetString("CLIENT");

            if (string.IsNullOrEmpty(client))
            {
                ViewBag.result = new ResultSet { Success = false, Message = "YOU MUST BE LOGIN TO VIEW REQUEST LIST" };
                return false;
            }
            else if (client == "RECEIVER")
            {
                ViewBag.result = new ResultSet { Success = false, Message = "YOU ARE LOGIN FROM RECEIVER ACCOUNT, TO VIEW REQUEST LIST YOU MUST BE LOGIN FROM HOSPITAL ACCOUNT" };
                return false;
            }
            else
                return true;
        }
    }
}