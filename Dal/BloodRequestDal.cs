using System.Data;
using System.Data.SqlClient;

namespace BLOOD_HELP.Dal
{
    public class BloodRequestDal
    {
        private readonly dao _dao;
        public BloodRequestDal()
        {
            _dao = new dao();
        }
        public DataTable GetRequestList(int hospitalId)
        {
            DataTable dataTable = new DataTable();
            try
            {
                string query = @" SELECT TU.FULL_NAME, THBF.BLOOD_GROUP,CONVERT(VARCHAR,THBF.CREATED_DATE,111) AS [RELEASED_DATE],CONVERT(VARCHAR,TRBH.CREATED_DATE,111) AS [REQUESTED_DATE]
                                FROM TBL_REQUEST_BLOOD_HIST TRBH
                                        INNER JOIN TBL_HOSPITAL_BLOOD_INFO THBF ON TRBH.BLOOD_INFO_ID=THBF.BLOOD_INFO_ID
                                        INNER JOIN TBL_USER TU ON TU.USER_ID=TRBH.USER_ID
                                WHERE THBF.HOSPITAL_ID=@HOSPITAL_ID
                                ORDER BY TRBH.CREATED_DATE DESC, THBF.CREATED_DATE DESC,THBF.BLOOD_GROUP ASC";
                SqlParameter[] sqlParameters ={
                    new SqlParameter("@HOSPITAL_ID",hospitalId)
                };
                dataTable = _dao.GetTable(sqlParameters, query, isProc: false);
            }
            catch (System.Exception)
            {

            }
            return dataTable;
        }
    }
}