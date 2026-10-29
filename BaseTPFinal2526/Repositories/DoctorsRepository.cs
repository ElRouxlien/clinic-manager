using BaseTPFinal2526.Models;
using BaseTPFinal2526.Models.Enums;
using System.Data.SQLite;

namespace BaseTPFinal2526.Repositories
{
    public class DoctorsRepository : PersonsRepositoryBase
    {
        private string _dbPath = "Data Source=medicalCenter.db;Version=3;";
        public List<Doctor> GetAll()
        {
            var doctors = new List<Doctor>();

            try
            {
                using (var connection = new SQLiteConnection(_dbPath))
                {
                    connection.Open();

                    string sql = @"
                    SELECT p.Id, p.FirstName, p.LastName, p.Address, p.PhoneNumber, p.Email,
                           d.Specialty, d.INAMINumber, d.ConsultationFee
                    FROM Person p
                    INNER JOIN Doctor d ON p.Id = d.Id;";

                    using (var cmd = new SQLiteCommand(sql, connection))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var doctor = new Doctor
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                FirstName = reader["FirstName"].ToString(),
                                LastName = reader["LastName"].ToString(),
                                Address = reader["Address"].ToString(),
                                PhoneNumber = reader["PhoneNumber"].ToString(),
                                Email = reader["Email"].ToString(),
                                Specialty = (DoctorSpeciality)Enum.Parse(typeof(DoctorSpeciality), reader["Specialty"].ToString()),
                                INAMINumber = reader["INAMINumber"].ToString(),
                                ConsultationFee = Convert.ToDecimal(reader["ConsultationFee"])
                            };

                            doctors.Add(doctor);
                        }
                        return doctors;
                    }
                }
            }
            catch (Exception ex) 
            {
                throw new Exception("Error while inserting Person into database.", ex);
            }

        }

        public Doctor GetById(int id)
        {
            try
            {
                using (var connection = new SQLiteConnection(_dbPath))
                {
                    connection.Open();

                    string sql = @"
                    SELECT p.Id, p.FirstName, p.LastName, p.Address, p.PhoneNumber, p.Email,
                           d.Specialty, d.INAMINumber, d.ConsultationFee
                    FROM Person p
                    INNER JOIN Doctor d ON p.Id = d.Id
                    WHERE p.Id = @Id;";

                    using (var cmd = new SQLiteCommand(sql, connection))
                    {
                        cmd.Parameters.AddWithValue("@Id", id);

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (!reader.Read())
                                return null;

                            return new Doctor
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                FirstName = reader["FirstName"].ToString(),
                                LastName = reader["LastName"].ToString(),
                                Address = reader["Address"].ToString(),
                                PhoneNumber = reader["PhoneNumber"].ToString(),
                                Email = reader["Email"].ToString(),
                                Specialty = (DoctorSpeciality)Enum.Parse(typeof(DoctorSpeciality), reader["Specialty"].ToString()),
                                INAMINumber = reader["INAMINumber"].ToString(),
                                ConsultationFee = Convert.ToDecimal(reader["ConsultationFee"])
                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error while inserting Person into database.", ex);
            }
        }

        public void Add(Doctor doctor)
        {
            try
            {
                using (var connection = new SQLiteConnection(_dbPath))
                {
                    connection.Open();
                    using (var transaction = connection.BeginTransaction())
                    {
                        int personId = InsertPerson(doctor, connection, transaction);
                        doctor.Id = personId;

                        string sql = @"
                        INSERT INTO Doctor (Id, Specialty, INAMINumber, ConsultationFee)
                        VALUES (@Id, @Specialty, @INAMINumber, @ConsultationFee);";

                        using (var cmd = new SQLiteCommand(sql, connection, transaction))
                        {
                            cmd.Parameters.AddWithValue("@Id", doctor.Id);
                            cmd.Parameters.AddWithValue("@Specialty", doctor.Specialty.ToString());
                            cmd.Parameters.AddWithValue("@INAMINumber", doctor.INAMINumber);
                            cmd.Parameters.AddWithValue("@ConsultationFee", doctor.ConsultationFee);
                            cmd.ExecuteNonQuery();
                        }

                        transaction.Commit();
                    }
                }
            }
            catch(Exception ex) 
            {
                throw new Exception("Error while inserting Person into database.", ex);
            }
        }

        public void Update(Doctor doctor)
        {
            try
            {
                using (var connection = new SQLiteConnection(_dbPath))
                {
                    connection.Open();
                    using (var transaction = connection.BeginTransaction())
                    {
                        UpdatePerson(doctor, connection, transaction);

                        string sql = @"
                        UPDATE Doctor
                        SET Specialty = @Specialty,
                            INAMINumber = @INAMINumber,
                            ConsultationFee = @ConsultationFee
                        WHERE Id = @Id;";

                        using (var cmd = new SQLiteCommand(sql, connection, transaction))
                        {
                            cmd.Parameters.AddWithValue("@Id", doctor.Id);
                            cmd.Parameters.AddWithValue("@Specialty", doctor.Specialty.ToString());
                            cmd.Parameters.AddWithValue("@INAMINumber", doctor.INAMINumber);
                            cmd.Parameters.AddWithValue("@ConsultationFee", doctor.ConsultationFee);
                            cmd.ExecuteNonQuery();
                        }

                        transaction.Commit();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error while inserting Person into database.", ex);
            }
        }

        public void Delete(int doctorId)
        {
            try
            {
                using (var connection = new SQLiteConnection(_dbPath))
                {
                    connection.Open();

                    using (var transaction = connection.BeginTransaction())
                    {
                        string deleteDoctorSql = "DELETE FROM Doctor WHERE Id = @Id;";
                        using (var cmd = new SQLiteCommand(deleteDoctorSql, connection, transaction))
                        {
                            cmd.Parameters.AddWithValue("@Id", doctorId);
                            cmd.ExecuteNonQuery();
                        }

                        DeletePerson(doctorId, connection, transaction);

                        transaction.Commit();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error while deleting Doctor from database.", ex);
            }
        }


        public Doctor GetByINAMINumber(string inamiNumber)
        {
            try
            {
                using (var connection = new SQLiteConnection(_dbPath))
                {
                    connection.Open();

                    string sql = @"
                    SELECT p.Id, p.FirstName, p.LastName, p.Address, p.PhoneNumber, p.Email,
                           d.Specialty, d.INAMINumber, d.ConsultationFee
                    FROM Person p
                    INNER JOIN Doctor d ON p.Id = d.Id
                    WHERE d.INAMINumber = @INAMINumber;";

                    using (var cmd = new SQLiteCommand(sql, connection))
                    {
                        cmd.Parameters.AddWithValue("@INAMINumber", inamiNumber);

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (!reader.Read())
                                return null;

                            return new Doctor
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                FirstName = reader["FirstName"].ToString(),
                                LastName = reader["LastName"].ToString(),
                                Address = reader["Address"].ToString(),
                                PhoneNumber = reader["PhoneNumber"].ToString(),
                                Email = reader["Email"].ToString(),
                                Specialty = (DoctorSpeciality)Enum.Parse(typeof(DoctorSpeciality), reader["Specialty"].ToString()),
                                INAMINumber = reader["INAMINumber"].ToString(),
                                ConsultationFee = Convert.ToDecimal(reader["ConsultationFee"])
                            };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error while inserting Person into database.", ex);
            }
        }
    }
}
