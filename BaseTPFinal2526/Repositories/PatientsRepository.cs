using BaseTPFinal2526.Models;
using System.Data.SQLite;

namespace BaseTPFinal2526.Repositories
{
    public class PatientsRepository :  PersonsRepositoryBase
    {
        private string _dbPath = "Data Source=medicalCenter.db;Version=3;";
        public List<Patient> GetAll()
        {
            var patients = new List<Patient>();

            try
            {
                using (var connection = new SQLiteConnection(_dbPath))
                {
                    connection.Open();

                    string sql = @"
                    SELECT p.Id, p.FirstName, p.LastName, p.Address, p.PhoneNumber, p.Email,
                           pa.BirthDate, pa.MedicalRecordNumber, pa.IsInsured
                    FROM Person p
                    INNER JOIN Patient pa ON p.Id = pa.Id;";

                    using (var cmd = new SQLiteCommand(sql, connection))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var patient = new Patient
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                FirstName = reader["FirstName"].ToString(),
                                LastName = reader["LastName"].ToString(),
                                Address = reader["Address"].ToString(),
                                PhoneNumber = reader["PhoneNumber"].ToString(),
                                Email = reader["Email"].ToString(),
                                BirthDate = Convert.ToDateTime(reader["BirthDate"]),
                                MedicalRecordNumber = reader["MedicalRecordNumber"].ToString(),
                                IsInsured = Convert.ToBoolean(reader["IsInsured"])
                            };

                            patients.Add(patient);
                        }
                        return patients;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error while retrieving Patients from database.", ex);
            }
        }

        public Patient GetById(int id)
        {
            try
            {
                using (var connection = new SQLiteConnection(_dbPath))
                {
                    connection.Open();

                    string sql = @"
                SELECT p.Id, p.FirstName, p.LastName, p.Address, p.PhoneNumber, p.Email,
                       pa.BirthDate, pa.MedicalRecordNumber, pa.IsInsured
                FROM Person p
                INNER JOIN Patient pa ON p.Id = pa.Id
                WHERE p.Id = @Id;";

                    using (var cmd = new SQLiteCommand(sql, connection))
                    {
                        cmd.Parameters.AddWithValue("@Id", id);

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (!reader.Read())
                                return null;

                            return new Patient
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                FirstName = reader["FirstName"].ToString(),
                                LastName = reader["LastName"].ToString(),
                                Address = reader["Address"].ToString(),
                                PhoneNumber = reader["PhoneNumber"].ToString(),
                                Email = reader["Email"].ToString(),
                                BirthDate = Convert.ToDateTime(reader["BirthDate"]),
                                MedicalRecordNumber = reader["MedicalRecordNumber"].ToString(),
                                IsInsured = Convert.ToBoolean(reader["IsInsured"])
                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error while retrieving Patient from database.", ex);
            }
        }

        public void Add(Patient patient)
        {
            try
            {
                using (var connection = new SQLiteConnection(_dbPath))
                {
                    connection.Open();
                    using (var transaction = connection.BeginTransaction())
                    {
                        int personId = InsertPerson(patient, connection, transaction);
                        patient.Id = personId;

                        string sql = @"
                        INSERT INTO Patient (Id, BirthDate, MedicalRecordNumber, IsInsured)
                        VALUES (@Id, @BirthDate, @MedicalRecordNumber, @IsInsured);";

                        using (var cmd = new SQLiteCommand(sql, connection, transaction))
                        {
                            cmd.Parameters.AddWithValue("@Id", patient.Id);
                            cmd.Parameters.AddWithValue("@BirthDate", patient.BirthDate);
                            cmd.Parameters.AddWithValue("@MedicalRecordNumber", patient.MedicalRecordNumber);
                            cmd.Parameters.AddWithValue("@IsInsured", patient.IsInsured);
                            cmd.ExecuteNonQuery();
                        }

                        transaction.Commit();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error while adding Patient to database.", ex);
            }
        }

        public void Update(Patient patient)
        {
            try
            {
                using (var connection = new SQLiteConnection(_dbPath))
                {
                    connection.Open();
                    using (var transaction = connection.BeginTransaction())
                    {
                        UpdatePerson(patient, connection, transaction);

                        string sql = @"
                    UPDATE Patient
                    SET BirthDate = @BirthDate,
                        MedicalRecordNumber = @MedicalRecordNumber,
                        IsInsured = @IsInsured
                    WHERE Id = @Id;";

                        using (var cmd = new SQLiteCommand(sql, connection, transaction))
                        {
                            cmd.Parameters.AddWithValue("@Id", patient.Id);
                            cmd.Parameters.AddWithValue("@BirthDate", patient.BirthDate);
                            cmd.Parameters.AddWithValue("@MedicalRecordNumber", patient.MedicalRecordNumber);
                            cmd.Parameters.AddWithValue("@IsInsured", patient.IsInsured);
                            cmd.ExecuteNonQuery();
                        }

                        transaction.Commit();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error while updating Patient in database.", ex);
            }
        }

        public void Delete(int patientId)
        {
            try
            {
                using (var connection = new SQLiteConnection(_dbPath))
                {
                    connection.Open();

                    using (var transaction = connection.BeginTransaction())
                    {
                        string deletePatientSql = "DELETE FROM Patient WHERE Id = @Id;";
                        using (var cmd = new SQLiteCommand(deletePatientSql, connection, transaction))
                        {
                            cmd.Parameters.AddWithValue("@Id", patientId);
                            cmd.ExecuteNonQuery();
                        }

                        DeletePerson(patientId, connection, transaction);

                        transaction.Commit();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error while deleting Patient from database.", ex);
            }
        }


    }
}
