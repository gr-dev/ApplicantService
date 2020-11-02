using Data.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Bll
{
    public class MyApplicationContext : ApplicationContext
    {
        string ConnectionString;
        public MyApplicationContext(string connectionString)
        {
            this.ConnectionString = connectionString;
        }
        public override Applicant AddApplicant(Applicant applicant)
        {
            //TODO: проверить айдишник
            var queryString = $"insert into  Applicants values " +
                $"('{applicant.Name}' , '{applicant.Phone}' )";
            using (SqlConnection connection = new SqlConnection(
              ConnectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();
                command.ExecuteNonQuery();
            }
            //TODO: айдишник сущности фигачнуть
            return applicant;
        }

        public override Interview AddInterview(Interview interview)
        {
            //TODO: формирование интервью
            var queryString = $"insert into  Interviews " +
                $"(ExecutorId, Received, ExamenotorId, Status, Rating, " +
                $"PositionFor, Exercise, InterviewerId, " +
                $"DeadLine, DoneTime)" +
                $" values ('{interview.ExecutorId}' , '{interview.Received}', '{interview.ExamenotorId}'," +
                $"{(int)interview.Status}, {(int)interview.Rating}, " +
                $"'{interview.PositionFor}', '{interview.Exercise}', " +
                $" {interview.InterviewerId}, '{interview.DeadLine}', '{interview.DoneTime}')";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();
                command.ExecuteNonQuery();
            }
            //TODO: айдишник сущности фигачнуть
            return interview;
        }

        public override Applicant GetApplicant(int applicantId)
        {
            var query = $"select * from applicants where id = {applicantId}";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.IsDBNull(0))
                        {
                            return null;
                        }
                        else
                        {
                            Applicant result = new Applicant();

                            while (reader.Read())
                            {
                                result.Id = reader.GetInt32(0);
                                result.Name = reader.GetString(1);
                                result.Phone = reader.GetString(2);
                                Console.WriteLine("{0} {1} {2}", reader.GetInt32(0), reader.GetString(1), reader.GetString(2));
                            }
                            return result;

                        }

                    }
                }

            }
        }

        public override List<Applicant> GetApplicants()
        {
            var result = new List<Applicant>();
            var query = "select * from applicants";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                //SqlCommand command = new SqlCommand(queryString, connection);
                //command.Connection.Open();
                // command.ExecuteNonQuery();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            result.Add(new Applicant()
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                Phone = reader.GetString(2)
                            });
                            Console.WriteLine("{0} {1} {2}", reader.GetInt32(0), reader.GetString(1), reader.GetString(2));
                        }
                    }
                }

            }
            return result;
        }

        public override List<Employe> Getemployees()
        {
            var result = new List<Employe>();
            var query = "select * from employees";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                //SqlCommand command = new SqlCommand(queryString, connection);
                //command.Connection.Open();
                // command.ExecuteNonQuery();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            result.Add(new Employe()
                            {
                                Id = reader.GetInt32(0),
                                 Name = reader.GetString(1),
                                  Position = reader.GetString(2)
                            });
                            Console.WriteLine($"запись {reader.GetInt32(0)} значение");
                        }
                    }
                }

            }
            return result;
        }

        public override List<Interview> GetInterviews()
        {
            var result = new List<Interview>();
            var query = "select * from interviews";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                //SqlCommand command = new SqlCommand(queryString, connection);
                //command.Connection.Open();
                // command.ExecuteNonQuery();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            result.Add(new Interview()
                            {
                                Id = reader.GetInt32(0)
                            });
                            Console.WriteLine($"запись {reader.GetInt32(0)} значение");
                        }
                    }
                }

            }
            return result;
        }

        public override Applicant UpdateApplicant(Applicant applicant)
        {
            throw new NotImplementedException();
        }

        public override Interview UpdateInterview(Interview interview)
        {
            //TODO: логика по обновлению
            var queryString = $"update interviews set rating = {(int)interview.Rating} where id = {interview.Id}";
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();
                command.ExecuteNonQuery();
            }
            //TODO: айдишник сущности фигачнуть
            return interview;
        }
    }

}
