using MySql.Data.MySqlClient;
using SeedFarm.Models;
using System.Configuration;
using Dapper;
using System.Data;

namespace SeedFarm.DataLayer
{
    public class DataAccess
    {
        public int Insert(BillDescriptionViewModel data)
        {
            IDbConnection con = GetConnection();



            

            DynamicParameters pcParam = new DynamicParameters();
            {
                pcParam.Add("p_CustomerName", data.CustomerName, DbType.String);
                pcParam.Add("p_FatherName", data.FatherName, DbType.String);
                pcParam.Add("p_Address", data.Address, DbType.String);
                pcParam.Add("p_City", data.City, DbType.String);
                pcParam.Add("p_State", data.State, DbType.String);
                }

            string sSQL = "Insert into Billing (CustomerName," +
                            "FatherName," +
                            "Address," +
                            "City," +
                            "State," +
                            "Bill_date) " +
                            "values " +
                            "(@p_CustomerName," +
                            "@p_FatherName," +
                            "@p_Address," +
                            "@p_City," +
                            "@p_State," +
                            "now());SELECT LAST_INSERT_ID();";
            int iBillId = SqlMapper.ExecuteScalar<int>(con, sSQL, pcParam, commandType: CommandType.Text);


            if (iBillId > 0)
            {
                var BillDetails = data.BillDescList;
                int i = 0;
                for (i = 0; i < BillDetails.Count; i++)
                {

                    DynamicParameters pcParam2 = new DynamicParameters();
                    {
                        pcParam2.Add("p_Description", BillDetails[i].Description, DbType.String);
                        pcParam2.Add("p_Packing", BillDetails[i].Packing, DbType.String);
                        pcParam2.Add("p_RatePerPacking", BillDetails[i].RatePerPacking, DbType.String);
                        pcParam2.Add("p_NoOfPacking", BillDetails[i].NoOfPacking, DbType.String);
                        pcParam2.Add("p_Amount", BillDetails[i].Amount, DbType.String);
                        pcParam2.Add("p_BillId", iBillId, DbType.Int64);
                    }


                    //BillDetailId, Description, Packing, RatePerPacking, NoOfPacking, Amount, BillId
                    string sSQLDetail = "Insert into billing_details (Description," +
                            "Packing," +
                            "RatePerPacking," +
                            "NoOfPacking," +
                            "Amount," +
                            "BillId) " +
                            "values " +
                            "(@p_Description," +
                            "@p_Packing," +
                            "@p_RatePerPacking," +
                            "@p_NoOfPacking," +
                            "@p_Amount," +
                            "@p_BillId)";
                    SqlMapper.ExecuteScalar<int>(con, sSQLDetail, pcParam2, commandType: CommandType.Text);
                }

            }

            
            //cmd.Connection
            return iBillId;
        }

        public IDbConnection GetConnection()
        {
            string connection = string.Empty;
            connection = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            return new MySqlConnection(connection);
        }

        public IDbConnection GetConnection(ConnectionObj con)
        {
            if (con != null)
            {
                if (con.DBVersion == 1)
                {
                    return new MySqlConnection(con.connectionstring);
                }
                else if (con.DBVersion == 2)
                {
                    return new MySqlConnection(con.connectionstring);
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }

        }

        public class ConnectionObj
        {
            public string connectionstring { get; set; }
            public int DBVersion { get; set; }
            public int Enterpriseid { get; set; }
        }
    }


}
