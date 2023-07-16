using Microsoft.Data.SqlClient;
using System.Data;

namespace LabModuleEndQues2
{
    public class Employee
    {
        public int EmpId { get; set; }
        public string Name { get; set; }
        public decimal Salary { get; set; }
        public string Designation { get; set; }
        public string Department { get; set; }
        public static Employee GetSingleEmployee(int EmpId)
        {
            Employee? emp = new Employee();
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSqlLocalDb;Initial Catalog=Employee;Integrated Security=true";
            cn.Open();

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from Employees where EmpId=@EmpId";

                cmd.Parameters.Add("@EmpId", SqlDbType.Int).Value = EmpId;

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    emp.EmpId = dr.GetInt32("EmpId");
                    emp.Name = dr.GetString("Name");
                    emp.Salary = dr.GetDecimal("Salary");
                    emp.Designation = dr.GetString("Designation");
                    emp.Department = dr.GetString("Department");

                }
                else
                {
                    emp = null;

                }
                dr.Close();

            }
            catch (Exception ex)
            {

                throw;
            }
            finally
            {
                cn.Close();
            }

            return emp;
        }

        public static List<Employee> GetAllEmployees()
        {
            List<Employee> lstEmps = new List<Employee>();
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSqlLocalDb;Initial Catalog=Employee;Integrated Security=true";
            cn.Open();

            try
            {
                //SqlCommand cmd = cn.CreateCommand();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from Employees";


                SqlDataReader dr = cmd.ExecuteReader();
                Employee obj;

                while (dr.Read())
                {
                    obj = new Employee();
                    obj.EmpId = dr.GetInt32("EmpId"); ;
                    obj.Name = dr.GetString("Name");
                    obj.Salary = dr.GetDecimal("Salary");
                    obj.Designation = dr.GetString("Designation");
                    obj.Department = dr.GetString("Department");
                    lstEmps.Add(obj);
                }

                dr.Close();

            }
            catch (Exception ex)
            {

                throw;
            }
            finally
            {
                cn.Close();
            }

            return lstEmps;
        }

        public static void InsertEmployee(Employee obj)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSqlLocalDb;Initial Catalog=Employee;Integrated Security=true";
            cn.Open();

            try
            {
                //SqlCommand cmd = cn.CreateCommand();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Insert into Employees values(@EmpId,@Name,@Salary,@Designation,@Department)";

                cmd.Parameters.AddWithValue("@EmpId", obj.EmpId);
                cmd.Parameters.AddWithValue("@Name", obj.Name);
                cmd.Parameters.AddWithValue("@Salary", obj.Salary);
                cmd.Parameters.AddWithValue("@Designation", obj.Designation);
                cmd.Parameters.AddWithValue("@Department", obj.Department);


                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

                throw;
            }
            finally
            {
                cn.Close();
            }
        }

        public static void UpdateEmployee(Employee obj)
        {

            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSqlLocalDb;Initial Catalog=Employee;Integrated Security=true";

            cn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Update Employees set Name=@Name, Salary=@Salary , Designation=@Designation , Department=@Department where EmpId=@EmpId";


                cmd.Parameters.AddWithValue("@EmpId", obj.EmpId);
                cmd.Parameters.AddWithValue("@Name", obj.Name);
                cmd.Parameters.AddWithValue("@Salary", obj.Salary);
                cmd.Parameters.AddWithValue("@Designation", obj.Designation);
                cmd.Parameters.AddWithValue("@Department", obj.Department);


                int rowsAffected = cmd.ExecuteNonQuery();

            }
            catch (Exception ex)

            {
                throw;
            }

            finally { cn.Close(); }
        }

        public static void DeleteEmployee(int EmpId)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Employee;Integrated Security=True";
            try
            {
                cn.Open();
                SqlCommand cmdInsert = new SqlCommand();
                cmdInsert.Connection = cn;
                cmdInsert.CommandType = System.Data.CommandType.Text;
                cmdInsert.CommandText = "delete from employees where EmpId =@EmpId";
                cmdInsert.Parameters.AddWithValue("@EmpId", EmpId);
                cmdInsert.ExecuteNonQuery();



            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                cn.Close();
            }
        }
    }
}
