using Dapper;
using Rush_1.Entities;
using System.Data;
using System.Data.SqlClient;

namespace Rush_1.Repositories
{
    public class StudentRepository
    {
        private readonly IDbConnection _dbConnection;

        public StudentRepository()
        {
            string connectionString = "Data Source=(local)\\SQLEXPRESS;Initial Catalog=School;User Id=Emmanuel;Password=3040;";
            _dbConnection = new SqlConnection(connectionString);
        }
        public void InsertStudent(Student student)
        {
            _dbConnection.Open();
            string sql = "INSERT INTO Student (Name, Email, Gender, CreationDate) VALUES (@Name, @Email, @Gender, @CreationDate);";
            _dbConnection.Execute(sql, student);
        }

        public Student GetStudent(int studentId)
        {
            _dbConnection.Open();
            var sql = "SELECT * FROM Students WHERE StudentId = @StudentId";
            return _dbConnection.QueryFirstOrDefault<Student>(sql, new { StudentId = studentId });
        }

        public void UpdateStudent(Student student)
        {
            _dbConnection.Open();
            var sql = "UPDATE Students SET Name = @Name, Email = @Email, Gender = @Gender, CreationDate = @CreationDate WHERE StudentId = @StudentId";
            _dbConnection.Execute(sql, student);
        }

        public void DeleteStudent(int studentId)
        {
            _dbConnection.Open();
            var sql = "DELETE FROM Students WHERE StudentId = @StudentId";
            _dbConnection.Execute(sql, new { StudentId = studentId });
        }

        public void CloseConnection()
        {
            if (_dbConnection.State == ConnectionState.Open)
            {
                _dbConnection.Close();
            }
        }
    }
}
