using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplication1.DAL
{
	public class TournamentDAL
	{
		private string connectionString;

		public TournamentDAL(string connectionString)
		{
			this.connectionString = connectionString;
		}

		public bool DeleteTournament(string name)
		{
			try
			{
				using (SqlConnection conn = new SqlConnection(connectionString))
				{
					conn.Open();

					SqlCommand cmd = new SqlCommand(@"DELETE FROM Tournaments WHERE name = @name;", conn);

					cmd.Parameters.AddWithValue("@name", name);

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
		public bool DeleteTeam(string name)
		{
			try
			{
				using (SqlConnection conn = new SqlConnection(connectionString))
				{
					conn.Open();

					SqlCommand cmd = new SqlCommand(@"DELETE FROM Teams WHERE name = @name;", conn);

					cmd.Parameters.AddWithValue("@name", name);

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