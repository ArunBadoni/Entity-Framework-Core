using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using StoredProcedureInEFCore.Entities;
using System.Data;

namespace StoredProcedureInEFCore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Student student1 = new Student()
            {
                FirstName="Krishna",
                LastName="Yadhuvanshi",
                Branch = "Universe",
                Gender="Male"
            };
            Student student2 = new Student()
            {
                FirstName = "Gopi",
                LastName = "Gwalan",
                Branch = "Bhakti",
                Gender = "Female"
            };
            //int id1 = AddStudentUsingExecuteSqlRaw(student1);
            int id2 = AddStudentUsingExecuteSqlInterpolated(student2);

            Console.WriteLine($"Two new student records created with Id1 :  and Id2 :{id2} ");
        }

        private static int AddStudentUsingExecuteSqlRaw(Student student)
        {
            int result = 0;
            try
            {
                var context = new EFCoreDbContext();
                var FirstNameParam = new SqlParameter("@FirstName", SqlDbType.NVarChar)
                {
                    Value = student.FirstName
                };
                var LastNameParam = new SqlParameter("@LastName", SqlDbType.NVarChar)
                {
                    Value = student.LastName
                };
                var BranchParam = new SqlParameter("@Branch", SqlDbType.NVarChar)
                {
                    Value = student.Branch
                };
                var GenderParam = new SqlParameter("@Gender", SqlDbType.NVarChar)
                {
                    Value = student.Gender
                };
                var StudentIdOutParam = new SqlParameter("@StudentId", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };
                int NumberOfRowsAffected = context.Database.ExecuteSqlRaw("exec spInsertStudent @FirstName,@LastName,@Branch,@Gender,@StudentId OUTPUT",FirstNameParam,LastNameParam,BranchParam,GenderParam,StudentIdOutParam);
                if (NumberOfRowsAffected > 0)
                {
                    result = (int)StudentIdOutParam.Value;
                }                 
            }
            catch (Exception ex)
            {
                Console.WriteLine("AddStudent Error Occured in ExecuteSqlRaw: " + ex.ToString());
            }
            return result;
        }
        private static int AddStudentUsingExecuteSqlInterpolated(Student student)
        {
            int result = 0;
            try
            {
                var context = new EFCoreDbContext();
                var FirstNameParam = new SqlParameter("FirstName", student.FirstName);
                var LastNameParam = new SqlParameter("LastName", student.LastName);
                var BranchParam = new SqlParameter("Branch", student.LastName);
                var GenderParam = new SqlParameter("Gender", student.LastName);
                var StudentIdOutParam = new SqlParameter()
                {
                    ParameterName = "StudentId",
                    SqlDbType = SqlDbType.Int,
                    Direction = ParameterDirection.Output
                };
                int noOfRowsAffected = context.Database.ExecuteSqlInterpolated($"exec spInsertStudent @FirstName={FirstNameParam},@LastName={LastNameParam}, @Branch={BranchParam},@Gender={GenderParam},@StudentId={StudentIdOutParam} OUTPUT ");
                if (noOfRowsAffected > 0)
                {
                    result = (int)StudentIdOutParam.Value;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("AddStudent Error Occured in Interpolated: "+ex.Message);
            }
            return result;
        }
    }
}
