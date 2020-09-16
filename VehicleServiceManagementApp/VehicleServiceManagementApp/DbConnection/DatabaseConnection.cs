using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using VehicleServiceManagementApp.Models;

namespace VehicleServiceManagementApp.DbConnection
{
    class DatabaseConnection
    {
        public string sql;
        public int count;


        private SqlConnection GetDBConnection()
        {
            //sql = @"Data Source=mitproject.databC:\Users\DIVYANI\source\repos\VehicleServiceManagementApp\VehicleServiceManagementApp\DbConnection\DatabaseConnection.csase.windows.net; Initial Catalog =mit1;User ID = adminmit; Password =im/2017/058;";
            //sql = "Server=tcp:mitproject.database.windows.net,1433;Initial Catalog=mit1;Persist Security Info=False;User ID=adminmit;Password=im/2017/058;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            sql = "Data Source=LAPTOP-FQL3B800\\SQLEXPRESS;Initial Catalog=VSMS;Integrated Security=True";
            SqlConnection con = new SqlConnection(sql);

            return con;

        }
        public bool addUser(User user)
        {
            try
            {


                string query = "IF OBJECT_ID('dbo.Employee', 'U') IS NULL ";
                query += "BEGIN ";
                query += "CREATE TABLE [dbo].[Employee](";
                query += "[EmployeeId] INT  IDENTITY(1,1) NOT NULL CONSTRAINT pkemployeeId PRIMARY KEY,";
                query += "[userId] VARCHAR(100) NOT NULL,";
                query += "[firstName] VARCHAR(100) NOT NULL,";
                query += "[lastName] VARCHAR(100) NOT NULL,";
                query += "[email] VARCHAR(200) NOT NULL,";
                query += "[password] VARCHAR(100) NOT NULL,";
                query += "[designation] VARCHAR(50) NOT NULL";
                query += ")";
                query += " END";

               
                Console.WriteLine(user.Designation);
                String sqlQuery = "INSERT INTO dbo.Employee(userId, firstName,lastName, email,password,designation) " +
                                     "VALUES ('" + user.UserId + "','" + user.FirstName + "','" + user.LastName + "','" + user.Email + "','" + user.Password + "','" + user.Designation + "')";
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = GetDBConnection();
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                    cmd.Connection.Close();
                    using (SqlCommand cmd1 = new SqlCommand(sqlQuery))
                    {
                        cmd1.Connection = GetDBConnection();
                        cmd1.Connection.Open();
                         count=cmd1.ExecuteNonQuery();
                        cmd1.Connection.Close();
                    }

                }

            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex);
            }
            if (count >= 1)
            {
                return true;
            }
            return false;
        }
        public Boolean loginUser(String email, String password)
        {
            String query = " SELECT password from dbo.Employee where email LIKE '" + email + "'";
            using (SqlCommand cmd1 = new SqlCommand(query))
            {
                cmd1.Connection = GetDBConnection();
                cmd1.Connection.Open();
                SqlDataReader reader = cmd1.ExecuteReader();

                if (reader.Read())
                {
                    string password1 = (string)reader["password"];
                    if (password == password1)
                    {
                        Console.WriteLine(password1);
                        cmd1.Connection.Close();
                        return true;
                    }

                }
                cmd1.Connection.Close();
                return false;
            }


        }
        public User Getuser(String email)
        {
            String query = " SELECT * from dbo.Employee where email LIKE '" + email + "'";
            using (SqlCommand cmd1 = new SqlCommand(query))
            {
                cmd1.Connection = GetDBConnection();
                cmd1.Connection.Open();
                SqlDataReader reader = cmd1.ExecuteReader();
                if (reader.Read())
                {
                    string firstName1 = (string)reader["firstName"];
                    string lastName1 = (string)reader["lastName"];
                    string email1 = (string)reader["email"];
                    string password1 = (string)reader["password"];
                    string designation1 = (string)reader["designation"];

                    User user = new User(firstName1, lastName1, email1, password1, designation1);
                    return user;


                }

            }


            return null;

        }
        public void addAppoinment(Appoinment appoinment)
        {
            try
            {


                string query = "IF OBJECT_ID('dbo.Customer', 'U') IS NULL ";
                query += "BEGIN ";
                query += "CREATE TABLE [dbo].[Customer](";
                query += "[cusId]  VARCHAR(100)  NOT NULL CONSTRAINT pkcustomerId PRIMARY KEY,";
                query += "[cusName] VARCHAR(100) NOT NULL,";
                query += "[cusPhone] INT NOT NULL,";
                query += "[email] VARCHAR(200) NOT NULL,";
                query += "[vehicle] VARCHAR(100) NOT NULL";
                query += ")";
                query += " END";


                String sqlQuery = "IF NOT EXISTS(SELECT  * FROM dbo.Customer WHERE email ='" + appoinment.Email + "' AND vehicle = '" + appoinment.Vehicle + "')";
                sqlQuery += "BEGIN ";
                sqlQuery += "INSERT INTO dbo.Customer(cusId,cusName, cusPhone,email,vehicle) " +
                                     "VALUES ('" + appoinment.AppId + "','" + appoinment.CusName + "','" + appoinment.Cusphn + "','" + appoinment.Email + "','" + appoinment.Vehicle + "')";
                sqlQuery += "END";



                Console.WriteLine(appoinment.CusName);
                //String sqlQuery = "INSERT INTO dbo.Customer(cusId,cusName, cusPhone,email,vehicle) " +
                //                     "VALUES ('" + appoinment.AppId + "','" + appoinment.CusName + "','" + appoinment.Cusphn + "','" + appoinment.Email + "','" + appoinment.Vehicle + "')";
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = GetDBConnection();
                    cmd.Connection.Open();

                    cmd.Connection.Close();
                    using (SqlCommand cmd1 = new SqlCommand(sqlQuery))
                    {
                        cmd1.Connection = GetDBConnection();
                        cmd1.Connection.Open();
                        cmd1.ExecuteNonQuery();
                        cmd1.Connection.Close();
                    }

                }
                String sqlQuery1 = "SELECT  * FROM dbo.Customer WHERE email ='" + appoinment.Email + "' AND vehicle = '" + appoinment.Vehicle + "'";
                using (SqlCommand cmd = new SqlCommand(sqlQuery1))
                {
                    cmd.Connection = GetDBConnection();
                    cmd.Connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    Console.WriteLine("out");
                    if (reader.Read())
                    {
                        Console.WriteLine("in");
                        string custId = (string)reader["cusId"];
                        appoinment.AppId = custId;
                        Console.WriteLine(appoinment.AppId);
                        Console.WriteLine(custId);
                    }

                    cmd.Connection.Close();


                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex);
            }
            try
            {

                string query = "IF OBJECT_ID('dbo.Appoinment', 'U') IS NULL ";
                query += "BEGIN ";
                query += "CREATE TABLE [dbo].[Appoinment](";
                query += "[AppoinmentId]  INT  IDENTITY(1,1)  NOT NULL CONSTRAINT pkappoinmentId PRIMARY KEY,";
                query += "[cusId] VARCHAR(100) NOT NULL CONSTRAINT fkappoinmentId FOREIGN KEY (cusId) REFERENCES dbo.Customer(cusId),";
                query += "[emailStatus] VARCHAR(100),";
                query += "[dateApp] DATETIME NOT NULL";
                query += ")";
                query += " END";

                String emailStatus = "Not Sent";

                String sqlQuery = "INSERT INTO dbo.Appoinment(cusId,emailStatus,dateApp) " +
                                   "VALUES ('" + appoinment.AppId + "','" + emailStatus + "','" + appoinment.DateTime + "')";
                Console.WriteLine(appoinment.DateTime);
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = GetDBConnection();
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                    cmd.Connection.Close();
                    using (SqlCommand cmd1 = new SqlCommand(sqlQuery))
                    {
                        cmd1.Connection = GetDBConnection();
                        cmd1.Connection.Open();
                        count = 0;
                        count=cmd1.ExecuteNonQuery();
                        cmd1.Connection.Close();
                    }

                }
                if (count >= 1)
                {
                    fmAlert fm = new fmAlert();
                    fm.Show();
                }
                else
                {
                    err er = new err();
                    er.Show();
                }
               // MessageBox.Show("Successfully Saved Appoinment!! ", " Appoinment Record", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex);
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public SqlDataAdapter GetAppoinments()
        {
            String query = " SELECT * from dbo.Appoinment ap,dbo.Customer cu  where ap.cusId LIKE cu.cusId";
            using (SqlCommand cmd2 = new SqlCommand(query))
            {
                cmd2.Connection = GetDBConnection();
                cmd2.Connection.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd2);

                return da;
            }




        }
        public SqlDataAdapter GetSelectedAppoinments(String name)
        {
            String query = " SELECT * from dbo.Appoinment ap,dbo.Customer cu  where ap.cusId LIKE cu.cusId AND cu.cusName LIKE'"+name+"'";
            using (SqlCommand cmd2 = new SqlCommand(query))
            {
                cmd2.Connection = GetDBConnection();
                cmd2.Connection.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd2);

                return da;
            }




        }
        public void addService(ServiceFinal serviceFinal)
        {
            try
            {


                string query = "IF OBJECT_ID('dbo.Service', 'U') IS NULL ";
                query += "BEGIN ";
                query += "CREATE TABLE [dbo].[Service](";
                query += "[ServiceId] VARCHAR(100) NOT NULL CONSTRAINT pkserviceId PRIMARY KEY,";
                query += "[totprice] FLOAT  NOT NULL ,";
                query += "[date] DATETIME NOT NULL,";
                query += "[discount] FLOAT ,";
                query += "[cusphone] INT NOT NULL ";
                query += ")";
                query += " END";


                Console.WriteLine(serviceFinal.Date);
                String sqlQuery = "INSERT INTO dbo.Service(ServiceId, totprice,date,discount,cusphone) " +
                                     "VALUES ('" + serviceFinal.ServiceId + "','" + serviceFinal.Totprice + "','" + serviceFinal.Date + "','" + serviceFinal.Discount + "','" + serviceFinal.Cusphone + "')";
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = GetDBConnection();
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                    cmd.Connection.Close();
                    using (SqlCommand cmd1 = new SqlCommand(sqlQuery))
                    {
                        cmd1.Connection = GetDBConnection();
                        cmd1.Connection.Open();
                        cmd1.ExecuteNonQuery();
                        cmd1.Connection.Close();
                    }

                }

            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex);
            }
        }
        public SqlDataAdapter GetServicess()
        {
            String query = " SELECT * from dbo.Service";
            using (SqlCommand cmd2 = new SqlCommand(query))
            {
                cmd2.Connection = GetDBConnection();
                cmd2.Connection.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd2);
                Console.WriteLine(da);
                return da;
            }




        }

        public SqlDataReader GetAppoinmnetMails(String tommorrow, String after)
        {
            String emailStatus = "Not Sent";
            Console.WriteLine(tommorrow);
            String query = "SELECT * from dbo.Appoinment ap , dbo.Customer cu where ap.cusId LIKE cu.cusId AND ap.dateApp >= '"+tommorrow+"' OR ap.dateApp <= '"+after+"' AND ap.emailStatus = 'Not sent'";
            //"SELECT * from dbo.Appoinment ap , dbo.Customer cu where ap.cusId LIKE cu.cusId AND ap.dateApp >= '"+tommorrow+"' AND ap.dateApp <= '"+after+"' AND ap.emailStatus = 'Not sent'";
            using (SqlCommand cmd2 = new SqlCommand(query))
            {
                cmd2.Connection = GetDBConnection();
                cmd2.Connection.Open();
                SqlDataReader reader = cmd2.ExecuteReader();
                Console.WriteLine("Hi");
                if (reader.Read())
                {
                   
                    Console.WriteLine("Mail In DB");
                    Console.WriteLine((string)reader["email"]);
                }


                return reader;
            }
        }

        public void updateStatus(int appoinmnentId1)
        {
            try
            {
                String query = "UPDATE dbo.Appoinment SET emailStatus = 'sent' WHERE AppoinmentId='" + appoinmnentId1 + "'";
                using (SqlCommand cmd1 = new SqlCommand(query))
                {
                    cmd1.Connection = GetDBConnection();
                    cmd1.Connection.Open();
                    cmd1.ExecuteNonQuery();
                    cmd1.Connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public int getTotalCustomers()
        {

            String query = "SELECT COUNT(*) from  dbo.Customer";
            using (SqlCommand cmd2 = new SqlCommand(query))
            {
                cmd2.Connection = GetDBConnection();
                cmd2.Connection.Open();
                Int32 count = (Int32)cmd2.ExecuteScalar();
                cmd2.Connection.Close();
                 return count;
            }
        }
        public int getTotalEmplyees()
        {

            String query = "SELECT COUNT(*) from  dbo.Employee";
            using (SqlCommand cmd2 = new SqlCommand(query))
            {
                cmd2.Connection = GetDBConnection();
                cmd2.Connection.Open();
                Int32 count = (Int32)cmd2.ExecuteScalar();
                cmd2.Connection.Close();
                return count;
            }
        }

        public int getTotalAppoinmnets()
        {

            String query = "SELECT COUNT(*) from  dbo.Appoinment";
            using (SqlCommand cmd2 = new SqlCommand(query))
            {
                cmd2.Connection = GetDBConnection();
                cmd2.Connection.Open();
                Int32 count = (Int32)cmd2.ExecuteScalar();
                cmd2.Connection.Close();
                return count;
            }
        }

        public bool addFeedbacks(String state,String descp)
        {
            try
            {


                string query = "IF OBJECT_ID('dbo.Feedback', 'U') IS NULL ";
                query += "BEGIN ";
                query += "CREATE TABLE [dbo].[Feedback](";
                query += "[FeedbackId]  INT  IDENTITY(1,1)  NOT NULL CONSTRAINT pkfeedbackId PRIMARY KEY,";
                query += "[state] varchar(20)  NOT NULL ,";
                query += "[descp]  varchar(30)";
                query += ")";
                query += " END";


               
                String sqlQuery = "INSERT INTO dbo.Feedback(state, descp) " +
                                     "VALUES ('" + state+ "','"  + descp + "')";
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = GetDBConnection();
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                    cmd.Connection.Close();
                    using (SqlCommand cmd1 = new SqlCommand(sqlQuery))
                    {
                        cmd1.Connection = GetDBConnection();
                        cmd1.Connection.Open();
                        count = 0;
                        count = cmd1.ExecuteNonQuery();
                        cmd1.Connection.Close();
                    }

                }

            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex);
            }
            if (count >= 1)
            {
                return true;
            }
            return false;
        }
        public SqlDataAdapter GetFeedbacks()
        {
            String query = " SELECT * from dbo.Feedback";
            using (SqlCommand cmd2 = new SqlCommand(query))
            {
                cmd2.Connection = GetDBConnection();
                cmd2.Connection.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd2);
                Console.WriteLine("Feed");
                return da;
            }

        }
    }
    
}

