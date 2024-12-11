using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using TTCN_TLQuan.DAL;
using TTCN_TLQuan.Models;

namespace TTCN_TLQuan.BLL
{
    public class ImportBLL
    {
        private ImportDAL _importDAL;

        public ImportBLL()
        {
            _importDAL = new ImportDAL();
        }

        public bool Add(Models.Import import)
        {
            if (_importDAL.Add(import) > 0) return true;
            return false;
        }

        public bool Update(Models.Import import)
        {
            if (_importDAL.Update(import) > 0) return true;
            return false;
        }

        public bool Delete(int ImportID)
        {
            if (_importDAL.Delete(ImportID) > 0) return true;
            return false;
        }

        public List<Models.Import> GetAll()
        {
            List<Models.Import> listImport = new List<Models.Import>();
            using (SqlDataReader reader = _importDAL.GetAll())
            {
                while (reader.Read())
                {
                    Models.Import import = new Models.Import();

                    import.ImportID = Convert.ToInt32(reader["ImportID"]);
                    import.Date = Convert.ToDateTime(reader["Date"]);
                    import.TotalMoney = Convert.ToSingle(reader["TotalMoney"]);
                    import.UserID = Convert.ToInt32(reader["UserID"]);
                    import.UserName = Convert.ToString(reader["FullName"]);

                    listImport.Add(import);
                }
            }
            return listImport;
        }
    }
}