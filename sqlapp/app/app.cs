using System;
using System.Data;
using System.Data.SqlClient;

class app {
    static void Main() {
        try {
            using (SqlConnection connection = new SqlConnection()) {
                connection.ConnectionString = @"Data Source=db\SQLEXPRESS;"
                    + "Integrated Security=False;"
                    + "User ID=sa;"
                    + "Password=P@ssw0rd";
                connection.Open();
                using (SqlCommand cmd = new SqlCommand("select [id], isnumeric([id]) as numeric from [sample].[dbo].[SampleTable]")) {
                    cmd.Connection = connection;
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataReader reader = cmd.ExecuteReader()) {
                        while (reader.Read()) {
                            Console.WriteLine(reader["id"] + ", " + reader["numeric"]);
                        }
                    }
                }
            }
        } catch (Exception e) {
            Console.WriteLine(e);
        }
    }
}
