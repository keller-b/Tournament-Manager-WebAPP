using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class TeamsController : Controller
    {
        private TournamentManagerContext db = new TournamentManagerContext();

        // GET: Teams
        public async Task<ActionResult> Index(int? id)
        {
			if (User.Identity.IsAuthenticated == false)
			{
				return Redirect("/Home/Index");
			}
			ViewBag.id = id;
            return View(await db.Teams.Where(a => a.TournamentId == id).ToListAsync());
        }

        // GET: Teams/Details/5
        public async Task<ActionResult> Details(int? id)
        {
			if (User.Identity.IsAuthenticated == false)
			{
				return Redirect("/Home/Index");
			}
			if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Team team = await db.Teams.FindAsync(id);
            if (team == null)
            {
                return HttpNotFound();
            }
            return View(team);
        }

        // GET: Teams/Create
        public ActionResult Create(int? id)
        {
			if (User.Identity.IsAuthenticated == false)
			{
				return Redirect("/Home/Index");
			}
			ViewBag.id = id;
            return View();
        }

        // POST: Teams/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "TeamId,Name,TournamentId")] Team team, int id)
        {
			if (User.Identity.IsAuthenticated == false)
			{
				return Redirect("/Home/Index");
			}
			team.TournamentId = id;

            if (ModelState.IsValid)
            {
                db.Teams.Add(team);
                await db.SaveChangesAsync();
                return RedirectToAction($"Index/{id}");
            }

            return View(team);
        }

        // GET: Teams/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
			if (User.Identity.IsAuthenticated == false)
			{
				return Redirect("/Home/Index");
			}
			if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Team team = await db.Teams.FindAsync(id);
            if (team == null)
            {
                return HttpNotFound();
            }
            return View(team);
        }

        // POST: Teams/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "TeamId,Name,TournamentId")] Team team)
        {
			if (User.Identity.IsAuthenticated == false)
			{
				return Redirect("/Home/Index");
			}
			using (TournamentManagerContext context = new TournamentManagerContext())
			{
				var dbTeam = context.Teams.Where(a => a.TeamId == team.TeamId).ToList();
				team.TournamentId = dbTeam[0].TournamentId;

				if (ModelState.IsValid)
				{
					db.Entry(team).State = EntityState.Modified;
					await db.SaveChangesAsync();
					return RedirectToAction($"Index/{team.TournamentId}");
				}

			}
            return View(team);
        }

        // GET: Teams/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
			if (User.Identity.IsAuthenticated == false)
			{
				return Redirect("/Home/Index");
			}
			if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Team team = await db.Teams.FindAsync(id);
            if (team == null)
            {
                return HttpNotFound();
            }
            return View(team);
        }

        // POST: Teams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Team team = await db.Teams.FindAsync(id);
            db.Teams.Remove(team);
            await db.SaveChangesAsync();
            return RedirectToAction($"Index/{team.TournamentId}");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
