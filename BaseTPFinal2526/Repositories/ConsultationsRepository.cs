using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseTPFinal2526.Models;
using BaseTPFinal2526.Models.Enums;
using System.Data.SQLite;

namespace BaseTPFinal2526.Repositories
{
    public class ConsultationsRepository
    {
        private readonly string _dbPath;

        public ConsultationsRepository(string dbPath)
        {
            _dbPath = dbPath;
        }

        private bool HasOverlappingConsultation(
        Consultation consultation,
        SQLiteConnection connection,
        SQLiteTransaction transaction)
        {
            string sql = @"
                        SELECT COUNT(*) FROM Consultation
                        WHERE DoctorId = @DoctorId
                        AND Status = 'Scheduled'
                        AND (
                            Date < @EndDate
                            AND datetime(Date, '+' || Duration || ' minutes') > @StartDate
                        );";

            using (var cmd = new SQLiteCommand(sql, connection, transaction))
            {
                cmd.Parameters.AddWithValue("@DoctorId", consultation.Doctor.Id);
                cmd.Parameters.AddWithValue("@StartDate", consultation.Date);
                cmd.Parameters.AddWithValue("@EndDate", consultation.Date.AddMinutes(consultation.Duration));

                long count = (long)cmd.ExecuteScalar();
                return count > 0;
            }
        }


        private decimal CalculateTotalFee(int duration, decimal consultationFee)
        {
            return duration * consultationFee;
        }


        public void Add(Consultation consultation)
        {
            try
            {
                using (var connection = new SQLiteConnection(_dbPath))
                {
                    connection.Open();

                    using (var transaction = connection.BeginTransaction())
                    {
                        if (consultation.Date <= DateTime.Now)
                            throw new Exception("Consultation date must be in the future.");

                        if (HasOverlappingConsultation(consultation, connection, transaction))
                            throw new Exception("Doctor already has a consultation at this time.");

                        consultation.TotalFee = CalculateTotalFee(
                            consultation.Duration,
                            consultation.Doctor.ConsultationFee);

                        string sql = @"
                        INSERT INTO Consultation
                        (DoctorId, PatientId, Date, Duration, Type, Status, TotalFee)
                        VALUES
                        (@DoctorId, @PatientId, @Date, @Duration, @Type, @Status, @TotalFee);";

                        using (var cmd = new SQLiteCommand(sql, connection, transaction))
                        {
                            cmd.Parameters.AddWithValue("@DoctorId", consultation.Doctor.Id);
                            cmd.Parameters.AddWithValue("@PatientId", consultation.Patient.Id);
                            cmd.Parameters.AddWithValue("@Date", consultation.Date);
                            cmd.Parameters.AddWithValue("@Duration", consultation.Duration);
                            cmd.Parameters.AddWithValue("@Type", consultation.Type.ToString());
                            cmd.Parameters.AddWithValue("@Status", ConsultationStatus.Scheduled.ToString());
                            cmd.Parameters.AddWithValue("@TotalFee", consultation.TotalFee);

                            cmd.ExecuteNonQuery();
                        }

                        transaction.Commit();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error while creating consultation.", ex);
            }
        }

        public List<Consultation> GetAll(
        DoctorsRepository doctorsRepository,
        PatientsRepository patientsRepository)
        {
            var consultations = new List<Consultation>();

            using (var connection = new SQLiteConnection(_dbPath))
            {
                connection.Open();

                string sql = "SELECT * FROM Consultation ORDER BY Date;";

                using (var cmd = new SQLiteCommand(sql, connection))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int doctorId = reader.GetInt32(reader.GetOrdinal("DoctorId"));
                        int patientId = reader.GetInt32(reader.GetOrdinal("PatientId"));

                        consultations.Add(new Consultation
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            Doctor = doctorsRepository.GetById(doctorId),
                            Patient = patientsRepository.GetById(patientId),
                            Date = reader.GetDateTime(reader.GetOrdinal("Date")),
                            Duration = reader.GetInt32(reader.GetOrdinal("Duration")),
                            Type = Enum.Parse<ConsultationType>(reader["Type"].ToString()),
                            Status = Enum.Parse<ConsultationStatus>(reader["Status"].ToString()),
                            TotalFee = reader.GetDecimal(reader.GetOrdinal("TotalFee"))
                        });
                    }
                }
            }



            return consultations;
        }
        public void Cancel(int consultationId)
        {
            using (var connection = new SQLiteConnection(_dbPath))
            {
                connection.Open();

                string sql = @"
                            UPDATE Consultation
                            SET Status = @Status
                            WHERE Id = @Id;
                            ";

                using (var cmd = new SQLiteCommand(sql, connection))
                {
                    cmd.Parameters.AddWithValue("@Status", ConsultationStatus.Cancelled.ToString());
                    cmd.Parameters.AddWithValue("@Id", consultationId);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void Update(Consultation consultation)
        {
            if (consultation.Status == ConsultationStatus.Cancelled)
                throw new Exception("A cancelled consultation cannot be edited.");

            using (var connection = new SQLiteConnection(_dbPath))
            {
                connection.Open();

                using (var transaction = connection.BeginTransaction())
                {
                    if (consultation.Date <= DateTime.Now)
                        throw new Exception("Consultation date must be in the future.");

                    if (HasOverlappingConsultation(consultation, connection, transaction))
                        throw new Exception("Doctor already has a consultation at this time.");

                    consultation.TotalFee =
                        consultation.Duration * consultation.Doctor.ConsultationFee;

                    string sql = @"
                                    UPDATE Consultation
                                    SET DoctorId = @DoctorId,
                                        PatientId = @PatientId,
                                        Date = @Date,
                                        Duration = @Duration,
                                        Type = @Type,
                                        TotalFee = @TotalFee
                                    WHERE Id = @Id;
                                ";

                    using (var cmd = new SQLiteCommand(sql, connection, transaction))
                    {
                        cmd.Parameters.AddWithValue("@Id", consultation.Id);
                        cmd.Parameters.AddWithValue("@DoctorId", consultation.Doctor.Id);
                        cmd.Parameters.AddWithValue("@PatientId", consultation.Patient.Id);
                        cmd.Parameters.AddWithValue("@Date", consultation.Date);
                        cmd.Parameters.AddWithValue("@Duration", consultation.Duration);
                        cmd.Parameters.AddWithValue("@Type", consultation.Type.ToString());
                        cmd.Parameters.AddWithValue("@TotalFee", consultation.TotalFee);

                        cmd.ExecuteNonQuery();
                    }

                    transaction.Commit();
                }
            }
        }
    }
}
    
