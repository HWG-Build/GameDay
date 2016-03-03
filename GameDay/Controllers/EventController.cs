using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Web.Mvc;
using Data.Layer.Interfaces;
using Data.Layer.Models;
using GameDay.Models;
using Data.Layer;
using Domain.Layer.Services;
using Domain.Service.CustomExceptions;

namespace GameDay.Controllers
{
    [Authorize]
    public class EventController : Controller
    {
        private readonly IService<Event> _gameservice;

        public EventController(IService<Event> game)
        {
            //throw new NullReferenceException();
            this._gameservice = game;
        }

        AddressService _addressService = new AddressService();

        // GET: Event
        [HttpGet]
        public ActionResult Index()
        {
            var games = _gameservice.GetRecords();
            var events = games.Select(x => new EventVM()
            {
                ID = x.ID,
                Name = x.Name,
                Game = x.Game,
                DateTime = x.DateTime,
                Time = x.Time,
                AddressName = _addressService.FindRecord(x.AddressId).Name,
            });

            return View(Constant.Partial.EventListPartial, events);
        }

        // GET: Event/Details/5
        //[HandleError(ExceptionType = typeof(CustomException), View = "CustomError")]
        [HttpGet]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Event @event = _gameservice.FindRecord(id);

            if (@event == null)
            {
                return HttpNotFound();
            }

            EventVM eventVM = MapEventVM(@event);
            eventVM.Location = _addressService.FindRecord(@event.AddressId);
            eventVM.Audit = _gameservice.GetAuditLogs(@event.ID).ToList();
            eventVM.PlayersAttending = @event.PlayersAttending;
            eventVM.PlayerAttendingList = @event.PlayersAttending?.Split(',').ToList() ?? new List<string>();
            return View(Constant.Partial.EventDetailPartial, eventVM);
        }

        // POST: Event/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EventVM @event)
        {
            if (ModelState.IsValid)
            {
                Event e = MapEvent(@event);
                _gameservice.AddRecord(e);
                return RedirectToAction(Constant.Controller.Index, Constant.Controller.Home);
            }
            return RedirectToAction(Constant.Controller.Index, Constant.Controller.Home);
        }

        // GET: Event/Edit/5
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = _gameservice.FindRecord(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            EventVM eventVM = MapEventVM(@event);
            eventVM.Location = _addressService.FindRecord(@event.AddressId);
            eventVM.Addresses = _addressService.GetRecords();
            eventVM.PlayersAttending = @event.PlayersAttending;
            return View(Constant.Partial.EditDetailPartial, eventVM);
        }

        // POST: Event/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EventVM @event)
        {
            if (ModelState.IsValid)
            {
                Event e = MapEvent(@event);
                e.PlayersAttending = @event.PlayersAttending;
                _gameservice.EditRecord(e);
                return RedirectToAction(Constant.Controller.Index, Constant.Controller.Home);
            }
            throw new EventException("Fields cannot be null");
        }

        // GET: Event/Delete/5
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = _gameservice.FindRecord(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            EventVM eventVM = MapEventVM(@event);
            eventVM.Location = _addressService.FindRecord(@event.AddressId);
            return View(eventVM);
        }

        // POST: Event/Delete/5
        [HttpPost, ActionName(Constant.Controller.Delete)]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Event @event = _gameservice.FindRecord(id);
            _gameservice.DeleteRecord(@event);
            return RedirectToAction(Constant.Controller.Index, Constant.Controller.Home);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _gameservice.Dispose();
            }
            base.Dispose(disposing);
        }


        public Event MapEvent(EventVM eventVM)
        {
            Event e = new Event();
            e.ID = eventVM.ID;
            e.Name = eventVM.Name;
            e.Game = eventVM.Game;
            e.DateTime = eventVM.DateTime;
            e.Time = eventVM.Time;
            e.AddressId = eventVM.AddressId;
            return e;
        }

        public EventVM MapEventVM(Event e)
        {
            EventVM eventVM = new EventVM();
            eventVM.ID = e.ID;
            eventVM.Name = e.Name;
            eventVM.Game = e.Game;
            eventVM.DateTime = e.DateTime;
            eventVM.Time = e.Time;
            eventVM.AddressId = e.AddressId;
            return eventVM;
        }

    }
}
