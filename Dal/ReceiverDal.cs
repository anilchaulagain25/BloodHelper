using System;
using System.Data;
using System.Data.SqlClient;
using BLOOD_HELP.Models;

namespace BLOOD_HELP.Dal
{
    public class ReceiverDal
    {
        private dao _dao;
        public ReceiverDal()
        {
            _dao = new dao();
        }
        public ResultSet CreateReceiver(ReceiverModel model)
        {
            ResultSet result = new ResultSet();
            try
            {
                SqlParameter[] parameters ={
                    new SqlParameter("@MODE","I"),
                    new SqlParameter("@USER_ID",-1),
                    new SqlParameter("@FULL_NAME",model.Name),
                    new SqlParameter("@USERNAME",model.Username),
                    new SqlParameter("@PASSWORD",model.Password),
                    new SqlParameter("@CONTACT_NO",model.ContactNo),
                    new SqlParameter("@EMAIL",model.Email),
                    new SqlParameter("@LOCATION",model.Location),
                    new SqlParameter("@CREATED_IP",model.IpAddress)
                    };
                _dao.ExecuteQuery(parameters, "PROC_CREATE_UPDATE_USER");
                result.Success = true;
                result.Message = "USER ACCOUNT CREATED SUCCESSFULLY";
            }
            catch (System.Exception ex)
            {
                result.Success = false;
                result.Message = ex.Message;
            }
            return result;
        }

        public ResultSet AuthenticateReceiver(string username, string password)
        {
            ResultSet result = new ResultSet();
            try
            {
                string query = @"IF NOT EXISTS(SELECT TOP 1 1 FROM TBL_USER WHERE [USERNAME]=@USERNAME OR EMAIL=@USERNAME)
                            BEGIN
                                RAISERROR('RECEIVER USER DOES NOT EXISTS',16,1);
                                RETURN;
                            END
                            IF NOT EXISTS(SELECT TOP 1 1 FROM TBL_USER WHERE ([USERNAME]=@USERNAME OR EMAIL=@USERNAME) AND [PASSWORD]=@PASSWORD)
                            BEGIN
                                RAISERROR('RECEIVER PASSWORD IS INCORRECT',16,1);
                                RETURN;
                            END
                            IF NOT EXISTS(SELECT TOP 1 1 FROM TBL_USER WHERE ([USERNAME]=@USERNAME OR EMAIL=@USERNAME) AND [PASSWORD]=@PASSWORD AND IS_ACTIVE=1)
                            BEGIN
                                RAISERROR('RECEIVER USER IS NOT ACTIVE',16,1);
                                RETURN;
                            END
                            ELSE 
                            BEGIN
                                SELECT TOP 1 USERNAME,[USER_ID],FULL_NAME,EMAIL,CONTACT_NO FROM TBL_USER WHERE ([USERNAME]=@USERNAME OR EMAIL=@USERNAME)
                            END ";
                SqlParameter[] parameters ={
                    new SqlParameter("@USERNAME",username),
                    new SqlParameter("@PASSWORD",password)
                    };
                DataRow dataRow = _dao.GetTable(parameters, query, false).Rows[0];
                result.Success = true;
                result.Message = "USER ACCOUNT AUTHENITICATED SUCCESSFULLY";
                result.Data = new ReceiverModel
                {
                    Username = dataRow["USERNAME"].ToString(),
                    Name = dataRow["FULL_NAME"].ToString(),
                    Id = int.Parse(dataRow["USER_ID"].ToString())
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