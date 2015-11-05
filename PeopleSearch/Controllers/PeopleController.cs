using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PeopleSearch.Models;

namespace PeopleSearch.Controllers
{
	public class PeopleController : Controller
	{
		private PeopleDBContext db = new PeopleDBContext();

		[HttpPost]
		public string Index(FormCollection fc, string searchString)
		{
			return "<h3> From [HttpPost]Index: " + searchString + "</h3>";
		}

		// GET: People
		public ActionResult Index(string lastName, string searchString)
		{
			var people = from m in db.People
						 select m;

			if (!String.IsNullOrEmpty(searchString))
			{
				people = people.Where(s => s.FirstName.Contains(searchString));
			}

			if (!String.IsNullOrEmpty(lastName))
			{
				people = people.Where(s => s.LastName.Contains(lastName));
			}

			return View(people);
		}

		// GET: People/Details/5
		public ActionResult Details(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Person person = db.People.Find(id);
			if (person == null)
			{
				return HttpNotFound();
			}
			return View(person);
		}

		// GET: People/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: People/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create([Bind(Include = "PersonID,FirstName,LastName,Address,Age,Interests,Picture,AlternateText")] Person person)
		{
			if (ModelState.IsValid)
			{
				db.People.Add(person);
				db.SaveChanges();
				return RedirectToAction("Index");
			}

			return View(person);
		}

		// GET: People/Edit/5
		public ActionResult Edit(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Person person = db.People.Find(id);
			if (person == null)
			{
				return HttpNotFound();
			}
			return View(person);
		}

		// POST: People/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit([Bind(Include = "PersonID,FirstName,LastName,Address,Age,Interests,Picture,AlternateText")] Person person)
		{
			if (ModelState.IsValid)
			{
				db.Entry(person).State = EntityState.Modified;
				db.SaveChanges();
				return RedirectToAction("Index");
			}
			return View(person);
		}

		// GET: People/Delete/5
		public ActionResult Delete(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Person person = db.People.Find(id);
			if (person == null)
			{
				return HttpNotFound();
			}
			return View(person);
		}

		// POST: People/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed(int id)
		{
			Person person = db.People.Find(id);
			db.People.Remove(person);
			db.SaveChanges();
			return RedirectToAction("Index");
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
