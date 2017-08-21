using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
	public class Tournament
	{
		
		public int TournamentId { get; set; }

		[Required]
		public string Name { get; set; }

		[Required]
		[DataType(DataType.Date)]
		public DateTime Start { get; set; }

		[Required]
		[DataType(DataType.Date)]
		public DateTime End { get; set; }

		[Required(ErrorMessage = "Location is required")]
		public string Location { get; set; }

		public List<Match> Matches { get; set; }

		public string OrganizerId { get; set; }

		public List<Team> Teams { get; set; }
	}
}