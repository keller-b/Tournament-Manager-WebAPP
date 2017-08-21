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
using Microsoft.AspNet.Identity;

namespace WebApplication1.Controllers
{
    public class TournamentsController : Controller
    {
        private TournamentManagerContext db = new TournamentManagerContext();

        // GET: Tournaments
        public async Task<ActionResult> Index()
        {
			var id = User.Identity.GetUserId();
			if (User.Identity.IsAuthenticated == false)
			{
				return Redirect("/Home/Index");
			}

			return View(await db.Tournaments.Where(a => a.OrganizerId == id).ToListAsync());

        }

        // GET: Tournaments/Details/5
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
            Tournament tournament = await db.Tournaments.FindAsync(id);
            if (tournament == null)
            {
                return HttpNotFound();
            }
            return View(tournament);
        }

        // GET: Tournaments/Create
        public ActionResult Create()
        {
			if (User.Identity.IsAuthenticated == false)
			{
				return Redirect("/Home/Index");
			}
			return View();
        }

        // POST: Tournaments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "TournamentId,Start,End,Name,Location,OrganizerId")] Tournament tournament)
        {
			if (User.Identity.IsAuthenticated == false)
			{
				return Redirect("/Home/Index");
			}
			tournament.OrganizerId = User.Identity.GetUserId();

			if (ModelState.IsValid)
            {
                db.Tournaments.Add(tournament);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(tournament);
        }

        // GET: Tournaments/Edit/5
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
            Tournament tournament = await db.Tournaments.FindAsync(id);
            if (tournament == null)
            {
                return HttpNotFound();
            }
            return View(tournament);
        }

        // POST: Tournaments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "TournamentId,Start,End,Name,Location,OrganizerId")] Tournament tournament)
        {
			if (User.Identity.IsAuthenticated == false)
			{
				return Redirect("/Home/Index");
			}
			tournament.OrganizerId = User.Identity.GetUserId();
			if (ModelState.IsValid)
            {
                db.Entry(tournament).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(tournament);
        }

        // GET: Tournaments/Delete/5
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
            Tournament tournament = await db.Tournaments.FindAsync(id);
            if (tournament == null)
            {
                return HttpNotFound();
            }
            return View(tournament);
        }

        // POST: Tournaments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
			Tournament tournament = await db.Tournaments.FindAsync(id);
            db.Tournaments.Remove(tournament);
            await db.SaveChangesAsync();
            return RedirectToAction($"Index/{tournament.OrganizerId}");
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
