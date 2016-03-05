using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Web.Mvc;
using AutoMapper;
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
            this._gameservice = game;
        }

        AddressService _addressService = new AddressService();

        // GET: Event
        //Load list of event with their addresses and the count of players attending the event
        [HttpGet]
        public ActionResult Index()
        {
            var games = _gameservice.GetRecords();
            var eventListPartial = new EventListPartialVM()
            {
                Events = games.Select(x => new EventListPartialVM.EventBucket()
                {
                    ID = x.ID,
                    Name = x.Name,
                    Game = x.Game,
                    DateTime = x.DateTime,
                    AddressName = _addressService.FindRecord(x.AddressId).Name,
                    PlayerCount = x.PlayersAttending != null ? x.PlayersAttending?.Split(',').ToList().Count() : 0
                })
            };

            return View(Constant.Partial.EventListPartial, eventListPartial);
        }

        // GET: Event/Details/5
        //Get event record with players attending as a string(comma seperated for tagsinput)
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

            EventDetailsPartialVM eventDetailsPartialVM = new EventDetailsPartialVM()
            {
                ID = @event.ID,
                Name = @event.Name,
                Game = @event.Game,
                DateTime = @event.DateTime,
                Location = _addressService.FindRecord(@event.AddressId),
                Audit = _gameservice.GetAuditLogs(@event.ID).ToList(),
                PlayersAttending = @event.PlayersAttending,
                PlayerAttendingList = @event.PlayersAttending?.Split(',').ToList() ?? new List<string>()
            };
            
            return View(Constant.Partial.EventDetailPartial, eventDetailsPartialVM);

        }

        // POST: Event/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EventVM @event)
        {
            if (ModelState.IsValid)
            {
                Event e = new Event()
                {
                    Name = @event.Name,
                    Game = @event.Game,
                    DateTime = @event.DateTime,
                    AddressId = @event.AddressId
                };
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
            EditDetailsPartialVM editDetailsPartialVM = new EditDetailsPartialVM()
            {
                ID = @event.ID,
                Name = @event.Name,
                Game = @event.Game,
                DateTime = @event.DateTime,
                AddressId = @event.AddressId,
                Addresses = _addressService.GetRecords(),
                PlayersAttending = @event.PlayersAttending
            };

            return View(Constant.Partial.EditDetailPartial, editDetailsPartialVM);
        }

        // POST: Event/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EditDetailsPartialVM editDetailsPartialVM)
        {
            if (ModelState.IsValid)
            {
                Event e = new Event()
                {
                    ID = editDetailsPartialVM.ID,
                    Name = editDetailsPartialVM.Name,
                    Game = editDetailsPartialVM.Game,
                    DateTime = editDetailsPartialVM.DateTime,
                    AddressId = editDetailsPartialVM.AddressId,
                    PlayersAttending = editDetailsPartialVM.PlayersAttending
                };
                _gameservice.EditRecord(e);
                return RedirectToAction(Constant.Controller.Index, Constant.Controller.Home);
            }
            throw new EventException(Constant.EventExceptions.Message);
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
            EventDeleteVM eventDeleteVM = new EventDeleteVM()
            {
                ID = @event.ID,
                Name = @event.Name,
                Game = @event.Game,
                DateTime = @event.DateTime,
                Location = _addressService.FindRecord(@event.AddressId)
            };
            return View(eventDeleteVM);
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

        //Map EventViewModel to Event
    }
}
