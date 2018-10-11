using System;
using System.Data;
using System.Data.SqlClient;
using BLOOD_HELP.Models;

namespace BLOOD_HELP.Dal
{
    public class AvailableBloodSampleDal
    {
        private readonly dao _dao;
        public AvailableBloodSampleDal()
        {
            _dao = new dao();
        }
        public DataSet GetBloodGroupList(int hostpitalId, string bloodGroup)
        {
            DataSet dataSet = new DataSet();
            try
            {
                string query = @"
                                SELECT BLOOD_INFO_ID,TH.HOSPITAL_NAME,THBI.BLOOD_GROUP,CONCAT(THBI.AMOUNT,' ',THBI.UNIT) AS UNIT,THBI.LATITUDE,THBI.LONGITUDE
                                FROM TBL_HOSPITAL_BLOOD_INFO THBI INNER JOIN TBL_HOSPITAL TH ON TH.HOSPITAL_ID=THBI.HOSPITAL_ID
                                WHERE THBI.HOSPITAL_ID=(CASE WHEN @HOSPITAL_ID = 0 THEN THBI.HOSPITAL_ID ELSE @HOSPITAL_ID END) AND THBI.BLOOD_GROUP=@BLOOD_GROUP
                
                                SELECT HOSPITAL_ID,HOSPITAL_NAME 
                                FROM TBL_HOSPITAL
                                WHERE IS_ACTIVE=1";

                SqlParameter[] sqlParameters ={
                        new SqlParameter("@HOSPITAL_ID",hostpitalId),
                        new SqlParameter("@BLOOD_GROUP",bloodGroup),
                };
                dataSet = _dao.GetDataSet(sqlParameters, query, isProc: false);

            }
            catch (System.Exception)
            {
                dataSet = null;
            }
            return dataSet;
        }

        public ResultSet RequestBlood(string id, int userId)
        {
            ResultSet result = new ResultSet();
            try
            {

                string query = @"IF NOT EXISTS(SELECT TOP 1 1 FROM TBL_USER WHERE USER_ID=@USER_ID)
                            BEGIN
                                RAISERROR('USER DOES NOT EXISTS',16,1);
                                RETURN;
                            END
                            ELSE IF NOT EXISTS(SELECT TOP 1 1 FROM TBL_HOSPITAL_BLOOD_INFO WHERE BLOOD_INFO_ID=@BLOOD_INFO_ID)
                            BEGIN
                                RAISERROR('BLOOD INFO DOES NOT EXISTS',16,1);
                                RETURN;
                            END
                            ELSE IF NOT EXISTS(SELECT TOP 1 1 FROM TBL_HOSPITAL_BLOOD_INFO WHERE BLOOD_INFO_ID=@BLOOD_INFO_ID AND IS_ACTIVE=1)
                            BEGIN
                                RAISERROR('BLOOD INFO IS NOT VALID',16,1);
                                RETURN;
                            END
                            ELSE IF EXISTS(SELECT TOP 1 1 FROM TBL_REQUEST_BLOOD_HIST WHERE BLOOD_INFO_ID=@BLOOD_INFO_ID AND USER_ID=@USER_ID)
                            BEGIN
                                RAISERROR('CURRENT USER ALREADY REQUESTED THIS BLOOD SAMPLE',16,1);
                                RETURN;
                            END
                            ELSE BEGIN
                                INSERT INTO TBL_REQUEST_BLOOD_HIST(BLOOD_INFO_ID,USER_ID,AMOUNT,CREATED_DATE,IS_ACTIVE)
                                VALUES(@BLOOD_INFO_ID,@USER_ID,(SELECT TOP 1 AMOUNT FROM TBL_HOSPITAL_BLOOD_INFO WHERE BLOOD_INFO_ID=@BLOOD_INFO_ID),GETDATE(),1)
                            END";
                SqlParameter[] sqlParameters ={
                    new SqlParameter("@BLOOD_INFO_ID",id),
                    new SqlParameter("@USER_ID",userId),
                };
                _dao.ExecuteQuery(sqlParameters, query, isProc: false);
                result.Success = true;
                result.Message = "BLOOD SAMPLE REQUESTED SUCCESSFULLY";
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