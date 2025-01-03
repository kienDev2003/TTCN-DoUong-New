﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TTCN_TLQuan.Models;

namespace TTCN_TLQuan.DAL
{
    public class UnitDAL
    {
        private DatabaseConnection _dB;

        public UnitDAL()
        {
            _dB = new DatabaseConnection();
        }

        public int Add(string Name)
        {
            Dictionary<string, object> parameter = new Dictionary<string, object>()
            {
                {"@Name", Name }
            };
            return _dB.ExecuteNonQuery("Unit_Insert", parameter);
        }

        public int Update(Unit unit)
        {
            Dictionary<string, object> parameter = new Dictionary<string, object>()
            {
                {"@UnitID", unit.UnitID },
                {"@Name", unit.UnitName }
            };
            return _dB.ExecuteNonQuery("Unit_Update", parameter);
        }

        public int Delete(int UnitID)
        {
            Dictionary<string, object> parameter = new Dictionary<string, object>()
            {
                {"@UnitID",UnitID }
            };
            return _dB.ExecuteNonQuery("Unit_Delete", parameter);
        }

        public List<Unit> GetAll()
        {
            List<Unit> listUnit = new List<Unit>();
            using (SqlDataReader reader = _dB.ExecuteReader("Unit_Select", null))
            {
                while (reader.Read())
                {
                    Unit unit = new Unit();

                    unit.UnitID = Convert.ToInt32(reader["UnitID"]);
                    unit.UnitName = Convert.ToString(reader["UnitName"]);

                    listUnit.Add(unit);
                }
            }
            return listUnit;
        }
    }
}