using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
	public class Match
	{
		public int TeamAId { get; set; }
		public int TeamBId { get; set; }
		public int MatchId { get; set; }
		public int TournamentId { get; set; }
		public int AScore { get; set; }
		public int BScore { get; set; }
		public int Round { get; set; }
	}
}