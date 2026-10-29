using BaseTPFinal2526.Models;
using System.Data.SQLite;

namespace BaseTPFinal2526.Repositories
{
    public abstract class PersonsRepositoryBase
    {

        protected int InsertPerson(Person person, SQLiteConnection connection, SQLiteTransaction transaction)
        {
            try
            {
                string sql = @"
                INSERT INTO Person (FirstName, LastName, Address, PhoneNumber, Email)
                VALUES (@FirstName, @LastName, @Address, @PhoneNumber, @Email);
                SELECT last_insert_rowid();";

                using (var cmd = new SQLiteCommand(sql, connection, transaction))
                {
                    cmd.Parameters.AddWithValue("@FirstName", person.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", person.LastName);
                    cmd.Parameters.AddWithValue("@Address", person.Address);
                    cmd.Parameters.AddWithValue("@PhoneNumber", person.PhoneNumber);
                    cmd.Parameters.AddWithValue("@Email", person.Email);

                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch(Exception ex)
            {
                throw new Exception("Error while inserting Person into database.", ex);
            }
        }

        protected void UpdatePerson(Person person, SQLiteConnection connection, SQLiteTransaction transaction)
        {
            try
            {
                string sql = @"
                UPDATE Person
                SET FirstName = @FirstName,
                    LastName = @LastName,
                    Address = @Address,
                    PhoneNumber = @PhoneNumber,
                    Email = @Email
                WHERE Id = @Id;";

                using (var cmd = new SQLiteCommand(sql, connection, transaction))
                {
                    cmd.Parameters.AddWithValue("@FirstName", person.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", person.LastName);
                    cmd.Parameters.AddWithValue("@Address", person.Address);
                    cmd.Parameters.AddWithValue("@PhoneNumber", person.PhoneNumber);
                    cmd.Parameters.AddWithValue("@Email", person.Email);
                    cmd.Parameters.AddWithValue("@Id", person.Id);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error while inserting Person into database.", ex);
            }
            
        }

        protected void DeletePerson(int id, SQLiteConnection connection, SQLiteTransaction transaction)
        {
            try
            {
                string sql = "DELETE FROM Person WHERE Id = @Id;";

                using (var cmd = new SQLiteCommand(sql, connection, transaction))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error while inserting Person into database.", ex);
            }
        }
    }
}
