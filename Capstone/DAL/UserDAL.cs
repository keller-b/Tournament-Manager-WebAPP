using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplication1.DAL
{
	public class UserDAL
	{
		private string connectionString;

		public UserDAL(string connectionString)
		{
			this.connectionString = connectionString;
		}

		public bool DeleteUser(string email)
		{
			try
			{
				using (SqlConnection conn = new SqlConnection(connectionString))
				{
					conn.Open();

					SqlCommand cmd = new SqlCommand(@"DELETE FROM AspNetUsers WHERE email = @email;", conn);

					cmd.Parameters.AddWithValue("@email", email);

					int rowsAffected = cmd.ExecuteNonQuery();

					return (rowsAffected > 0); 
				}
			}
			catch (SqlException ex)
			{
				//log
				throw;
			}

		}
	}
}