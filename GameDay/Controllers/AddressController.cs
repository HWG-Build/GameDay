﻿using System.Net;
using System.Web.Mvc;
using Domain.Layer.Interfaces;
using Domain.Layer.Models;
using Domain.Layer;

namespace GameDay.Controllers
{
    [Authorize]
    public class AddressController : Controller
    {
        
        private readonly IService<Address> _addressservice;
        public AddressController(IService<Address> addressservice)
        {
            this._addressservice = addressservice;
        }

        // GET: Address
        public ActionResult Index()
        {
            return View(_addressservice.GetRecords());
        }

        // GET: Address/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Address address = _addressservice.FindRecord(id);
            if (address == null)
            {
                return HttpNotFound();
            }
            return View(address);
        }

        // GET: Address/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Address/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = Constant.Controller.AddressFields)] Address address)
        {
            if (ModelState.IsValid)
            {
                _addressservice.AddRecord(address);
                return RedirectToAction(Constant.Controller.Index);
            }

            return View(address);
        }

        // GET: Address/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Address address = _addressservice.FindRecord(id);
            if (address == null)
            {
                return HttpNotFound();
            }
            return View(address);
        }

        // POST: Address/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = Constant.Controller.AddressFields)] Address address)
        {
            if (ModelState.IsValid)
            {
                _addressservice.EditRecord(address);
                return RedirectToAction(Constant.Controller.Index);
            }
            return View(address);
        }

        // GET: Address/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Address address = _addressservice.FindRecord(id);
            if (address == null)
            {
                return HttpNotFound();
            }
            return View(address);
        }

        // POST: Address/Delete/5
        [HttpPost, ActionName(Constant.Controller.Delete)]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Address address = _addressservice.FindRecord(id);
            _addressservice.DeleteRecord(address);
            return RedirectToAction(Constant.Controller.Index);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _addressservice.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
