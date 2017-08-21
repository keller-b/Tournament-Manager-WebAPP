using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace WebApplication1.Models
{
	public class TournamentManagerContext: DbContext
	{
		public TournamentManagerContext() 
			: base("DefaultConnection")
		{
		}
		public DbSet<Tournament> Tournaments { get; set; }
		public DbSet<Match> Matches { get; set; }
		public DbSet<Team> Teams { get; set; }
	}
}