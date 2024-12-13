using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using Import = TTCN_TLQuan.Models.Import;

namespace TTCN_TLQuan.DAL
{
    public class ImportDAL
    {
        private DatabaseConnection _dB;

        public ImportDAL()
        {
            _dB = new DatabaseConnection();
        }

        public int Add(Import import)
        {
            Dictionary<string, object> parameter = new Dictionary<string, object>()
            {
                {"@Date", import.Date },
                {"@UserID", import.UserID },
                {"@TotalMoney", import.TotalMoney }
            };
            return _dB.ExecuteNonQuery("Import_Insert", parameter);
        }

        public int Update(Import import)
        {
            Dictionary<string, object> parameter = new Dictionary<string, object>()
            {
                {"@ImportID", import.ImportID},
                {"@Date", import.Date },
                {"@UserID", import.UserID },
                {"@TotalMoney", import.TotalMoney }
            };
            return _dB.ExecuteNonQuery("Import_Update", parameter);
        }

        public int Delete(int ImportID)
        {
            Dictionary<string, object> parameter = new Dictionary<string, object>()
            {
                {"@ImportID",ImportID }
            };
            return _dB.ExecuteNonQuery("Import_Delete", parameter);
        }

        public List<Models.Import> GetAll()
        {
            List<Models.Import> listImport = new List<Models.Import>();
            using (SqlDataReader reader = _dB.ExecuteReader("Import_Select", null))
            {
                while (reader.Read())
                {
                    Models.Import import = new Models.Import();

                    import.ImportID = Convert.ToString(reader["ImportID"]);
                    import.Date = Convert.ToString(reader["Date"]);
                    import.TotalMoney = Convert.ToSingle(reader["TotalMoney"]);
                    import.UserID = Convert.ToInt32(reader["UserID"]);
                    import.UserName = Convert.ToString(reader["FullName"]);

                    listImport.Add(import);
                }
            }
            return listImport;
        }

        public Models.Import GetByID(string ImportID)
        {
            Dictionary<string, object> parameter = new Dictionary<string, object>()
            {
                {"@ImportID",ImportID }
            };
            Models.Import import = new Models.Import();
            using(SqlDataReader reader = _dB.ExecuteReader("Import_Select_By_ID", parameter))
            {
                if(reader.Read())
                {
                    import.ImportID = Convert.ToString(reader["ImportID"]);
                    import.Date = Convert.ToString(reader["Date"]);
                    import.TotalMoney = Convert.ToSingle(reader["TotalMoney"]);
                    import.UserID = Convert.ToInt32(reader["UserID"]);
                    import.UserName = Convert.ToString(reader["FullName"]);
                }
            }
            return import;
        }
    }
}