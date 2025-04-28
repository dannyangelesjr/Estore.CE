using System.Data.SqlServerCe;

namespace Estore.Ce.Helpers
{
    public class DatabaseHelper
    {
        public static void ResetIdentity(string tableName, string identityColumnName)
        {
            string connectionString = Helpers.ConfigurationHelper.GetConnectionString("SqlCeConnection");

            using (var connection = new SqlCeConnection(connectionString))
            {
                connection.Open();

                using (var command = new SqlCeCommand())
                {
                    command.Connection = connection;

                    // Step 1: Delete all rows from the table
                    command.CommandText = "DELETE FROM " + tableName;
                    command.ExecuteNonQuery();

                    // Step 2: Reset the identity seed
                    command.CommandText = "ALTER TABLE " + tableName + " ALTER COLUMN " + identityColumnName + " IDENTITY (1, 1)";
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}