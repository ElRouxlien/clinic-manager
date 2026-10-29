using System.Data.SQLite;

namespace BaseTPFinal2526.Repositories
{
    public class Database
    {
        private string _dbPath = "Data Source=medicalCenter.db;Version=3;";
        public static string ConnectionString =>
        "Data Source=medicalCenter.db;Version=3;";

        public void InitializeDatabase()
        {
            // Vérifier si la base de données existe déjà
            if (!File.Exists("./medicalCenter.db"))
            {
                // Créer une nouvelle base de données SQLite
                SQLiteConnection.CreateFile("medicalCenter.db");

                // Ouvrir une connexion à la base de données
                using (SQLiteConnection connection = new SQLiteConnection(_dbPath))
                {
                    connection.Open();

                    try
                    {
                        // Activer les clés étrangères (bonne pratique avec SQLite)
                        using (var pragmaCmd = new SQLiteCommand("PRAGMA foreign_keys = ON;", connection))
                        {
                            pragmaCmd.ExecuteNonQuery();
                        }

                        string createTableQuery = @"
                            CREATE TABLE IF NOT EXISTS Person (
                                Id INTEGER PRIMARY KEY,
                                FirstName TEXT,
                                LastName TEXT,
                                Address TEXT,
                                PhoneNumber TEXT,
                                Email TEXT
                            );

                            CREATE TABLE IF NOT EXISTS Doctor (
                                Id INTEGER PRIMARY KEY,
                                INAMINumber TEXT UNIQUE,
                                Specialty TEXT,
                                ConsultationFee DECIMAL,
                                FOREIGN KEY (Id) REFERENCES Person(Id)
                            );

                            CREATE TABLE IF NOT EXISTS Patient (
                                Id INTEGER PRIMARY KEY,
                                BirthDate DATE,
                                MedicalRecordNumber TEXT UNIQUE,
                                IsInsured BOOLEAN,
                                FOREIGN KEY (Id) REFERENCES Person(Id)
                            );

                            CREATE TABLE IF NOT EXISTS Consultation (
                                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                                DoctorId INTEGER,
                                PatientId INTEGER,
                                Date DATETIME,
                                Duration INTEGER,
                                Type TEXT,
                                Status TEXT,
                                TotalFee DECIMAL,
                                FOREIGN KEY (DoctorId) REFERENCES Doctor(Id),
                                FOREIGN KEY (PatientId) REFERENCES Patient(Id)
                            );";

                        using (SQLiteCommand command = new SQLiteCommand(createTableQuery, connection))
                        {
                            command.ExecuteNonQuery();
                        }

                        MessageBox.Show("Database 'medicalCenter.db' created successfully.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }
    }
}
