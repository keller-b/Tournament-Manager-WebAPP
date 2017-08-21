using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class BracketController : Controller
    {
        private TournamentManagerContext db = new TournamentManagerContext();

        //GET: Bracket/GetTournament/5
        public ActionResult Index(int? id)
        {
			
			ViewBag.Id = id.ToString();
            return View();
        }

        public JsonResult GetTournament(int? id)
        {
            if (id == null)
            {
                //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            //Tournament tournament = db.Tournaments.Find(id);
            var tournamentTeams = db.Teams.Where(a => a.TournamentId == id).ToList();

            if (tournamentTeams == null)
            {
                //return HttpNotFound();
            }

            TourneyJSON output = new TourneyJSON();

            for (int i = 0; i < tournamentTeams.Count() - 1; i += 2)
            {
                string teamA = tournamentTeams[i].Name;
                var teamB = (tournamentTeams[i + 1].Name == null) ? null : tournamentTeams[i + 1].Name;

                output.teams.Add(new List<string>() { teamA, teamB });
            }

            return Json(output, JsonRequestBehavior.AllowGet);
        }
    }
}