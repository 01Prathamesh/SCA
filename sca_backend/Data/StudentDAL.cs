using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using StudentAPI.Models;

namespace StudentAPI.Data
{
    public class StudentDAL
    {
        private readonly string _connectionString;

        public StudentDAL(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public List<Student> GetAllStudents()
        {
            var students = new List<Student>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT Id, Name, Age, Course FROM Students", connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    students.Add(new Student
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Name = reader["Name"].ToString(),
                        Age = Convert.ToInt32(reader["Age"]),
                        Course = reader["Course"].ToString()
                    });
                }
            }

            return students;
        }

        public Student GetStudentById(int id)
        {
            Student student = null;

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT Id, Name, Age, Course FROM Students WHERE Id = @Id", connection);
                command.Parameters.AddWithValue("@Id", id);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    student = new Student
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Name = reader["Name"].ToString(),
                        Age = Convert.ToInt32(reader["Age"]),
                        Course = reader["Course"].ToString()
                    };
                }
            }

            return student;
        }

        public void AddStudent(Student student)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("INSERT INTO Students (Name, Age, Course) VALUES (@Name, @Age, @Course)", connection);
                command.Parameters.AddWithValue("@Name", student.Name);
                command.Parameters.AddWithValue("@Age", student.Age);
                command.Parameters.AddWithValue("@Course", student.Course);

                command.ExecuteNonQuery();
            }
        }

        public void UpdateStudent(Student student)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("UPDATE Students SET Name = @Name, Age = @Age, Course = @Course WHERE Id = @Id", connection);
                command.Parameters.AddWithValue("@Name", student.Name);
                command.Parameters.AddWithValue("@Age", student.Age);
                command.Parameters.AddWithValue("@Course", student.Course);
                command.Parameters.AddWithValue("@Id", student.Id);

                command.ExecuteNonQuery();
            }
        }

        public void DeleteStudent(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("DELETE FROM Students WHERE Id = @Id", connection);
                command.Parameters.AddWithValue("@Id", id);

                command.ExecuteNonQuery();
            }
        }
    }
}
