using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Domain.Layer.Interfaces;
using Domain.Layer.Models;
using GameDay.Models;
using Domain.Layer;
using Domain.Service.Services;

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
        PlayerService _playerService = new PlayerService();


        // GET: Event
        public ActionResult Index()
        {
            var games = _gameservice.GetRecords();
            var events = games.Select(x => new EventVM()
            {
                ID = x.ID,
                Name = x.Name,
                Game = x.Game,
                Date = x.Date,
                Time = x.Time,
                AddressName = _addressService.FindRecord(x.AddressId).Name,
                });
            
            return View(Constant.Partial.EventListPartial, events);
        }

        // GET: Event/Details/5
        //[HandleError(ExceptionType = typeof(CustomException), View = "CustomError")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Event @event =_gameservice.FindRecord(id);

            if (@event == null)
            {
                return HttpNotFound();
            }

            EventVM eventVM = new EventVM
            {
                ID = @event.ID,
                Name = @event.Name,
                Game = @event.Game,
                Date = @event.Date,
                Time = @event.Time,
                Location = _addressService.FindRecord(@event.AddressId),
                Audit =  _gameservice.GetAuditLogs(@event.ID).ToList()
            };

            return View(Constant.Partial.EventDetailPartial, eventVM);
        }

        // POST: Event/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EventVM @event)
        {
            if (ModelState.IsValid)
            {
                Event e = new Event
                {
                    ID = @event.ID,
                    Name = @event.Name,
                    Game = @event.Game,
                    Date = @event.Date,
                    Time = @event.Time,
                    AddressId = @event.AddressId,
                    };
                _gameservice.AddRecord(e);
                return RedirectToAction(Constant.Controller.Index, Constant.Controller.Home);
            }

            return RedirectToAction(Constant.Controller.Index, Constant.Controller.Home);
        }

        // GET: Event/Edit/5
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
            EventVM eventVM = new EventVM()
            {
                Name = @event.Name,
                Game = @event.Game,
                Date = @event.Date,
                Time = @event.Time,
                Location = _addressService.FindRecord(@event.AddressId),
                Addresses = _addressService.GetRecords(),
                AddressId = @event.AddressId
        };

            return View(Constant.Partial.EditDetailPartial, eventVM);
        }

        // POST: Event/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EventVM @event)
        {
            Event e = new Event();
            if (ModelState.IsValid)
            {
                e.ID = @event.ID;
                e.Name = @event.Name;
                e.Game = @event.Game;
                e.Date = @event.Date;
                e.Time = @event.Time;
                e.AddressId = @event.AddressId;
                //e.PlayerId = @event.PlayerId;
                _gameservice.EditRecord(e);
                return RedirectToAction(Constant.Controller.Index, Constant.Controller.Home);
            }
            return View(e);
        }

        // GET: Event/Delete/5
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
            EventVM eventVM = new EventVM()
            {
                ID = @event.ID,
                Name = @event.Name,
                Game = @event.Game,
                Date = @event.Date,
                Time = @event.Time,
                Location = _addressService.FindRecord(@event.AddressId),
                //e.PlayerId = @event.PlayerId;
            };
            return View(eventVM);
        }

        // POST: Event/Delete/5
        [HttpPost, ActionName(Constant.Controller.Delete)]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Event @event = _gameservice.FindRecord(id);
            _gameservice.DeleteRecord(@event);
            return RedirectToAction(Constant.Controller.Index,Constant.Controller.Home);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _gameservice.Dispose();
            }
            base.Dispose(disposing);
        }


    }
}
