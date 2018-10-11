using System;
using System.Data;
using System.Data.SqlClient;
using BLOOD_HELP.Models;

namespace BLOOD_HELP.Dal
{
    public class HospitalDal
    {
        private dao _dao;
        public HospitalDal()
        {
            _dao = new dao();
        }
        public ResultSet CreateHospital(HospitalModel model)
        {
            ResultSet result = new ResultSet();
            try
            {
                SqlParameter[] parameters ={
                    new SqlParameter("@MODE","I"),
                    new SqlParameter("@HOSPITAL_ID",-1),
                    new SqlParameter("@HOSPITAL_NAME",model.Name),
                    new SqlParameter("@HOSPITAL_USERNAME",model.Username),
                    new SqlParameter("@PASSWORD",model.Password),
                    new SqlParameter("@CONTACT_NO",model.ContactNo),
                    new SqlParameter("@WEBSITE",model.Website),
                    new SqlParameter("@EMAIL",model.Email),
                    new SqlParameter("@LOCATION",model.Location),
                    new SqlParameter("@CREATED_IP",model.IpAddress)
                    };
                _dao.ExecuteQuery(parameters, "PROC_CREATE_UPDATE_HOPITAL");
                result.Success = true;
                result.Message = "HOSPITAL ACCOUNT CREATED SUCCESSFULLY";
            }
            catch (System.Exception ex)
            {
                result.Success = false;
                result.Message = ex.Message;
            }
            return result;
        }

        public ResultSet AuthenticateHospital(string username, string password)
        {
            ResultSet result = new ResultSet();
            try
            {
                string query = @"IF NOT EXISTS(SELECT TOP 1 1 FROM TBL_HOSPITAL WHERE HOSPITAL_USERNAME=@USERNAME OR EMAIL=@USERNAME)
                                    BEGIN
                                        RAISERROR('HOSPITAL USER DOES NOT EXISTS',16,1);
                                        RETURN;
                                    END
                                    IF NOT EXISTS(SELECT TOP 1 1 FROM TBL_HOSPITAL WHERE (HOSPITAL_USERNAME=@USERNAME OR EMAIL=@USERNAME) AND [PASSWORD]=@PASSWORD)
                                    BEGIN
                                        RAISERROR('HOSPITAL PASSWORD IS INCORRECT',16,1);
                                        RETURN;
                                    END
                                    IF NOT EXISTS(SELECT TOP 1 1 FROM TBL_HOSPITAL WHERE (HOSPITAL_USERNAME=@USERNAME OR EMAIL=@USERNAME) AND [PASSWORD]=@PASSWORD AND IS_ACTIVE=1)
                                    BEGIN
                                        RAISERROR('HOSPITAL USER IS NOT ACTIVE',16,1);
                                        RETURN;
                                    END
                                    ELSE 
                                    BEGIN
                                        SELECT TOP 1 HOSPITAL_USERNAME,HOSPITAL_ID,HOSPITAL_NAME,EMAIL,CONTACT_NO FROM TBL_HOSPITAL WHERE ([HOSPITAL_USERNAME]=@USERNAME OR EMAIL=@USERNAME)
                                    END ";
                SqlParameter[] parameters ={
                    new SqlParameter("@USERNAME",username??string.Empty),
                    new SqlParameter("@PASSWORD",password??string.Empty)
                    };
                DataRow dataRow = _dao.GetTable(parameters, query, false).Rows[0];
                result.Success = true;
                result.Message = "HOSPITAL ACCOUNT AUTHENITICATED SUCCESSFULLY";
                result.Data = new HospitalModel
                {
                    Id = int.Parse(dataRow["HOSPITAL_ID"].ToString()),
                    Name = dataRow["HOSPITAL_NAME"].ToString(),
                    Username = dataRow["HOSPITAL_USERNAME"].ToString(),

                };

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