using System;
using System.Data;
using System.Data.SqlClient;
using BLOOD_HELP.Models;

namespace BLOOD_HELP.Dal
{
    public class BloodSampleDal
    {
        private dao _dao;
        public BloodSampleDal()
        {
            _dao = new dao();
        }
        public ResultSet CreateBloddSample(BloodSampleModel model)
        {
            ResultSet result = new ResultSet();
            try
            {
                string query =
                @"
                INSERT INTO TBL_HOSPITAL_BLOOD_INFO([HOSPITAL_ID],[BLOOD_GROUP],[AMOUNT] ,[UNIT],[AVAILABLE_LOCATION],[CONTACT_NO],[BLOOD_PROPERTY_ONE],[BLOOD_PROPERTY_TWO],[BLOOD_PROPERTY_THREE],[LATITUDE],[LONGITUDE],[CREATED_DATE],[IS_ACTIVE])
                VALUES (@HOSPITAL_ID,@BLOOD_GROUP,@AMOUNT ,@UNIT,@AVAILABLE_LOCATION,@CONTACT_NO,@BLOOD_PROPERTY_ONE,@BLOOD_PROPERTY_TWO,@BLOOD_PROPERTY_THREE,@LATITUDE,@LONGITUDE,@CREATED_DATE,@IS_ACTIVE)
                "
                ;
                SqlParameter[] sqlParameters ={
                    new SqlParameter("@HOSPITAL_ID",model.HospitalId),
                    new SqlParameter("@BLOOD_GROUP",model.BloodGroup),
                    new SqlParameter("@AMOUNT",model.Amount),
                    new SqlParameter("@UNIT",model.Unit),
                    new SqlParameter("@AVAILABLE_LOCATION",model.Location),
                    new SqlParameter("@CONTACT_NO",model.ContactNo),
                    new SqlParameter("@BLOOD_PROPERTY_ONE",model.BloodPropertyOne),
                    new SqlParameter("@BLOOD_PROPERTY_TWO",model.BloddPropertyTwo),
                    new SqlParameter("@BLOOD_PROPERTY_THREE",model.BloodPropertyThree),
                    new SqlParameter("@LATITUDE",model.Latitude),
                    new SqlParameter("@LONGITUDE",model.Longitude),
                    new SqlParameter("@CREATED_DATE",System.DateTime.Now),
                    new SqlParameter("@IS_ACTIVE",true)
                    };
                _dao.ExecuteQuery(sqlParameters, query, isProc: false);
                result.Success = true;
                result.Message = "BLOOD SAMPLE SAVED SUCCESSFULLY";
            }
            catch (System.Exception ex)
            {
                result.Success = false;
                result.Message = ex.Message;
            }
            return result;
        }
    }
}