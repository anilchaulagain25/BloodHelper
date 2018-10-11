using BLOOD_HELP.Dal;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using BLOOD_HELP.Models;
using Microsoft.AspNetCore.Http;

namespace BLOOD_HELP.Controllers
{
    public class AvailableBloodSampleController : Controller
    {
        private readonly AvailableBloodSampleDal _objBloddSample;
        public AvailableBloodSampleController()
        {
            _objBloddSample = new AvailableBloodSampleDal();
        }
        [HttpGet]
        public IActionResult Index(int hospital = 0, string blood = null)
        {
            DataSet dataSet = _objBloddSample.GetBloodGroupList(hospital, blood);
            AvailableBloodSampleModel model = new AvailableBloodSampleModel();
            if (null != dataSet)
            {
                model.BloodSampleList = dataSet.Tables[0].Select().AsEnumerable().Select(x => new BloodInfo
                {
                    BloodInfoId = x["BLOOD_INFO_ID"].ToString(),
                    Name = x["HOSPITAL_NAME"].ToString(),
                    BloodGroup = x["BLOOD_GROUP"].ToString(),
                    Unit = x["UNIT"].ToString(),
                    Latitude = decimal.Parse(x["LATITUDE"].ToString()),
                    Longitude = decimal.Parse(x["LONGITUDE"].ToString()),
                }).ToList();

                model.HospitalList = dataSet.Tables[1].Select().AsEnumerable().Select(x => new HospitalListDropdown
                {
                    Value = x["HOSPITAL_ID"].ToString(),
                    Text = x["HOSPITAL_NAME"].ToString()
                }).ToList();
            }
            return View(model);
        }
        public IActionResult RequestBlood(string id)
        {
            var client = HttpContext.Session.GetString("CLIENT");
            ResultSet result = new ResultSet();
            if (!string.IsNullOrEmpty(client))
            {
                if (client == "HOSPITAL")
                {
                    result.Success = false;
                    result.Message = "YOU ARE LOGGED IN HOSPITAL ACCOUNT, LOG IN FROM RECEIVER ACCOUNT AND REQUEST BLOOD";
                }
                else
                {
                    int userId = HttpContext.Session.GetInt32("ID") ?? 0;
                    result = _objBloddSample.RequestBlood(id, userId);
                }
            }
            else
            {
                result.Success = false;
                result.Message = "YOR ARE NOT LOGGED IN, LOG IN FIRST AND REQUEST BLOOD";
            }
            ViewBag.result = result;
            return View("~/views/Shared/Message.cshtml");
        }
    }
}