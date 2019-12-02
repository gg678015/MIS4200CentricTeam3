﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using MIS4200team3.DAL;
using MIS4200team3.Models;

namespace MIS4200team3.Controllers
{
    [Authorize]
    public class ProfilesController : Controller
    {
        private Context db = new Context();

        // GET: Profiles
        public ActionResult Index(string searchString)
        {
            var testusers = from u in db.Profile select u;
            if(!String.IsNullOrEmpty(searchString))
            {
                testusers = testusers.Where(u =>
                    u.lastName.Contains(searchString)
                      || u.firstName.Contains(searchString));
                return View(testusers.ToList());
            }
            return View(db.Profile.ToList());
        }

        public ActionResult MyProfile()
        {
            Guid profileID;  // create a variable to hold the GUID
            Guid.TryParse(User.Identity.GetUserId(), out profileID);
            Profile profile = db.Profile.Find(profileID);
            if (profile == null)
            {
                return HttpNotFound();
            }
            var recList = db.Recognition.Where(r => r.id == profileID).ToList();
            ViewBag.Profile = recList;

            var totalCnt = recList.Count(); //counts all the recognitions for that person
            var rec1Cnt = recList.Where(r => r.values == Recognition.cValues.DeliveryExcellance).Count();
            // counts all the Excellence recognitions
            // notice how the Enum values are references, class.enum.value
            // the next two lines show another way to do the same counting
            var rec2Cnt = recList.Count(r => r.values == Recognition.cValues.Culture);
            var rec3Cnt = recList.Count(r => r.values == Recognition.cValues.Integrity);
            var rec4Cnt = recList.Count(r => r.values == Recognition.cValues.Stewardship);
            var rec5Cnt = recList.Count(r => r.values == Recognition.cValues.Innovation);
            var rec6Cnt = recList.Count(r => r.values == Recognition.cValues.GreaterGood);
            var rec7Cnt = recList.Count(r => r.values == Recognition.cValues.Balance);
            // copy the values into the ViewBag
            ViewBag.total = totalCnt;
            ViewBag.Excellence = rec1Cnt;
            ViewBag.Culture = rec2Cnt;
            ViewBag.Integrity = rec3Cnt;
            ViewBag.Stewardship = rec4Cnt;
            ViewBag.Innovation = rec5Cnt;
            ViewBag.GreaterGood = rec6Cnt;
            ViewBag.Balance = rec7Cnt;

            return View(profile);
        }

        // GET: Profiles/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Profile profile = db.Profile.Find(id);
            if (profile == null)
            {
                return HttpNotFound();
            }

            var recList = db.Recognition.Where(r => r.id == id).ToList();
            ViewBag.Profile = recList;

            var totalCnt = recList.Count(); //counts all the recognitions for that person
            var rec1Cnt = recList.Where(r => r.values == Recognition.cValues.DeliveryExcellance).Count();
            // counts all the Excellence recognitions
            // notice how the Enum values are references, class.enum.value
            // the next two lines show another way to do the same counting
            var rec2Cnt = recList.Count(r => r.values == Recognition.cValues.Culture);
            var rec3Cnt = recList.Count(r => r.values == Recognition.cValues.Integrity);
            var rec4Cnt = recList.Count(r => r.values == Recognition.cValues.Stewardship);
            var rec5Cnt = recList.Count(r => r.values == Recognition.cValues.Innovation);
            var rec6Cnt = recList.Count(r => r.values == Recognition.cValues.GreaterGood);
            var rec7Cnt = recList.Count(r => r.values == Recognition.cValues.Balance);
            // copy the values into the ViewBag
            ViewBag.total = totalCnt;
            ViewBag.Excellence = rec1Cnt;
            ViewBag.Culture = rec2Cnt;
            ViewBag.Integrity = rec3Cnt;
            ViewBag.Stewardship = rec4Cnt;
            ViewBag.Innovation = rec5Cnt;
            ViewBag.GreaterGood = rec6Cnt;
            ViewBag.Balance = rec7Cnt;


            return View(profile);
        }

        // GET: Profiles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Profiles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "profileID,firstName,lastName,businessUnit,hireDate,employeeTitle,phone,email")] Profile profile)
        {
            if (ModelState.IsValid)
            {
                //userDetails.ID = Guid.NewGuid(); // original new GUID
                Guid profileID;  // create a variable to hold the GUID
                Guid.TryParse(User.Identity.GetUserId(), out profileID);
                profile.ID = profileID;
                db.Profile.Add(profile);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(profile);
        }

        // GET: Profiles/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Profile profile = db.Profile.Find(id);
            if (profile == null)
            {
                return HttpNotFound();
            }
            Guid guid;
            Guid.TryParse(User.Identity.GetUserId(), out guid);
            if (profile.ID == guid)
            {
                return View(profile);
            }
            else
            {
                return View("NotAuthenticated");
            }
            return View(profile);
        }

        // POST: Profiles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "profileID,firstName,lastName,businessUnit,hireDate,employeeTitle,phone,email")] Profile profile)
        {
            if (ModelState.IsValid)
            {
                db.Entry(profile).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(profile);
        }

        // GET: Profiles/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Profile profile = db.Profile.Find(id);
            if (profile == null)
            {
                return HttpNotFound();
            }
            return View(profile);
        }

        // POST: Profiles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Profile profile = db.Profile.Find(id);
            db.Profile.Remove(profile);
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
