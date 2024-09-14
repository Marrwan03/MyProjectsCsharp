using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clsDataAccessTier
{
    public class clsDataAccessTestTypes
    {
        public static DataTable GetAllTestTypes()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessTierStringSetting.ConnectString);
            string Query = "select * from TestTypes";
            SqlCommand command = new SqlCommand(Query, connection);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if(reader.HasRows)
                {
                    dt.Load(reader);
                }

            }
            catch (Exception ex) { }
            finally { connection.Close(); } 
            return dt;
        }

        public static bool Find(int ID,ref string Title,ref string Description,ref decimal Fees)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessTierStringSetting.ConnectString);
            string Query = "select * from TestTypes where TestTypeID=@ID";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@ID", ID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if(reader.Read())
                {
                    Title = (string)reader["TestTypeTitle"];
                    Description = (string)reader["TestTypeDescription"];
                    Fees = (decimal)reader["TestTypeFees"];
                    IsFound = true;
                }

            }
            catch (Exception ex) { }
            finally { connection.Close(); }
            return IsFound;


        }

        public static bool UpdateTestType(int ID, string Title, string Description, decimal Fees)
        {
            int RecordEffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessTierStringSetting.ConnectString);
            string Query = @"Update TestTypes
                            set TestTypeTitle=@Title,
                                TestTypeDescription=@Description,
                                      TestTypeFees=@Fees
                                         where TestTypeID=@ID";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@Title", Title);
            command.Parameters.AddWithValue("@Description", Description);
            command.Parameters.AddWithValue("@Fees", Fees);
            command.Parameters.AddWithValue("@ID", ID);
            try
            {
                connection.Open();

                RecordEffected = command.ExecuteNonQuery();

            }
            catch (Exception ex) { }
            finally { connection.Close(); }
            return RecordEffected > 0;


        }

        public static decimal GetMinimumFees()
        {
            decimal MinFees = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessTierStringSetting.ConnectString);
            string Query = "select min(TestTypeFees) from TestTypes";
            SqlCommand command = new SqlCommand(Query, connection);
            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && decimal.TryParse(result.ToString(), out decimal Min))
                {
                    MinFees = Min;
                }
            }
            catch (Exception ex) { }
            finally { connection.Close(); }
            return MinFees;


        }

        public static decimal GetMaximumFees()
        {
            decimal MaxFees = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessTierStringSetting.ConnectString);
            string Query = "select Max(TestTypeFees) from TestTypes";
            SqlCommand command = new SqlCommand(Query, connection);
            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && decimal.TryParse(result.ToString(), out decimal Max))
                {
                    MaxFees = Max;
                }
            }
            catch (Exception ex) { }
            finally { connection.Close(); }
            return MaxFees;


        }


    }
}
