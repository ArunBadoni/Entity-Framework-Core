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
            /*// Code for inserting data for new student
            Student student1 = new Student()
            {
                FirstName="Sansari",
                LastName="Purush",
                Branch = "SansariKaam",
                Gender="Male"
            };
            Student student2 = new Student()
            {
                FirstName = "Kami",
                LastName = "Stree",
                Branch = "KaamKaaj",
                Gender = "Female"
            };
            int id1 = AddStudentUsingExecuteSqlRaw(student1);
            int id2 = AddStudentUsingExecuteSqlInterpolated(student2);

            Console.WriteLine($"Two new student records created with Id1 :{id1}  and Id2 :{id2} ");
            */

            /* Code for GetStudentById
            GetStudentByIdUsingFromSqlRaw(2);
            GetStudentByIdUsingFromSqlInterpolated(1);
            */

            /*
            var context = new EFCoreDbContext();
            Student? student = context.Students.FirstOrDefault(x=>x.StudentId==2);
            if(student!=null)
            {
                student.Branch = "Milk,Curd and Cheese and Bhakti";
                
                UpdateStudentUsingExecuteSqlRaw(student);
                GetStudentByIdUsingFromSqlRaw(student.StudentId);
                //OR
                UpdateStudentUsingExecuteSqlInterpolated(student);
                GetStudentByIdUsingFromSqlInterpolated(student.StudentId);
            }
            else
                Console.WriteLine("Student does not exists.");
            */

            /*Delete Student Code
            DeleteStudentUsingExecuteSqlRaw(1003);
            DeleteStudentUsingExecuteSqlInterpolated(1002);
            */
            Console.ReadKey();
        }
        private static void DeleteStudentUsingExecuteSqlRaw(int StudentId)
        {
            try
            {
                var context = new EFCoreDbContext();
                var StudentIdParam = new SqlParameter("@StudentId", SqlDbType.Int)
                {
                    Value = StudentId
                };
                int rowAffected = context.Database.ExecuteSqlRaw($"EXEC spDeleteStudent @StudentId", StudentIdParam);
                if (rowAffected > 0)
                {
                    Console.WriteLine($"Student with Id : {StudentId} is deleted.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("DeleteStudentUsingExecuteSqlRaw- Exception : " + ex.Message);
            }
        }
        private static void DeleteStudentUsingExecuteSqlInterpolated(int StudentId)
        {
            var context = new EFCoreDbContext();
            int rowAffected=context.Database.ExecuteSqlInterpolated($"EXEC spDeleteStudent @StudentId={StudentId}");
            if( rowAffected >0 )
            {
                Console.WriteLine($"Student with Id : {StudentId} is deleted.");
            }
        }
        private static void UpdateStudentUsingExecuteSqlInterpolated(Student student)
        {
            try
            {
                var context = new EFCoreDbContext();
                var StudentIdParam = new SqlParameter("StudentId", student.StudentId);
                var FirstnameParam = new SqlParameter("Firstname", student.FirstName);
                var LastNameParam = new SqlParameter("LastName", student.LastName);
                var BranchParam = new SqlParameter("Branch", student.Branch);
                var GenderParam = new SqlParameter("Gender", student.Gender);
                int rowAfferted = context.Database.ExecuteSqlInterpolated($"EXEC spUpdateStudent @StudentId={StudentIdParam},@FirstName={FirstnameParam},@LastName={LastNameParam},@Branch={BranchParam},@Gender={GenderParam}");
                if (rowAfferted > 0)
                {
                    Console.WriteLine("Student data Updated");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("UpdateStudentUsingExecuteSqlInterpolated - Exception" + ex.Message);
            }
        }
        private static void UpdateStudentUsingExecuteSqlRaw(Student student)
        {
            try
            {
                var context = new EFCoreDbContext();
                var StudentIdParam = new SqlParameter("@StudentId", SqlDbType.Int)
                {
                    Value = student.StudentId
                };
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
                int rowAffected = context.Database.ExecuteSqlRaw("EXEC spUpdateStudent @StudentId,@FirstName,@LastName,@Branch,@Gender",
                    StudentIdParam, FirstNameParam, LastNameParam, BranchParam, GenderParam);
                if (rowAffected > 0)
                {
                    Console.WriteLine("Student data Updated..");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("UpdateStudentUsingExecuteSqlRaw - Exception:"+ex.Message);
            }
        }
        private static void GetStudentByIdUsingFromSqlInterpolated(int StudentId)
        {
            Student? student = null;
            try
            {
                var context = new EFCoreDbContext();

                var result = context.Students.FromSqlInterpolated($"EXEC spGetStudentByStudentId @StudentId={StudentId}").ToList();
                
                if (result.Count > 0)
                {
                    student = result.FirstOrDefault();

                    Console.WriteLine($"\nStudent Details:\nStudent Name:{student.FirstName} {student.LastName}" +
                    $"\nBranch:{student.Branch}" +
                    $"\nGender:{student.Gender}");
                }
                else
                    Console.WriteLine("\nNo Student available in database with StudentId : " + StudentId);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"GetStudentByIdUsingFromSqlInterpolated- Error Occurred : {ex.Message}");
            }
        }
        private static void GetStudentByIdUsingFromSqlRaw(int StudentId)
        {
            Student? student = null;
            try
            {
                var context = new EFCoreDbContext();
                var StudentIdParam = new SqlParameter("@StudentId", SqlDbType.Int)
                {
                    Value = StudentId
                };
                var result = context.Students.FromSqlRaw("EXEC spGetStudentByStudentId @StudentId", StudentIdParam).ToList();
                if (result.Count > 0)
                {
                    student = result.FirstOrDefault();
                
                    Console.WriteLine($"\nStudent Details----\nStudent Name:{student.FirstName} {student.LastName}" +
                    $"\nBranch:{student.Branch}" +
                    $"\nGender:{student.Gender}");
                }
                else
                    Console.WriteLine("No Student available in database with StudentId : " + StudentId);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"GetStudentById- Error Occurred : {ex.Message}");
            }
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
