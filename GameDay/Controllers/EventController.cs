using System.Net;
using System.Web.Mvc;
using Domain.Layer.Interfaces;
using Domain.Layer.Models;
using GameDay.Models;
using Domain.Layer;

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

        // GET: Event
        public ActionResult Index()
        {
            return View(Constants.Partial.EventListPartial,_gameservice.GetRecords());
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
            return View(Constants.Partial.EventDetailPartial,@event);
        }

        // POST: Event/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = Constants.Controller.EventFields)] Event @event)
        {
            if (ModelState.IsValid)
            {
                _gameservice.AddRecord(@event);
                return RedirectToAction(Constants.Controller.Index, Constants.Controller.Home);
            }

            return RedirectToAction(Constants.Controller.Index, Constants.Controller.Home);
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
            return View(Constants.Partial.EditDetailPartial,@event);
        }

        // POST: Event/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = Constants.Controller.EventFields)] Event @event)
        {
            if (ModelState.IsValid)
            {
                _gameservice.EditRecord(@event);
                return RedirectToAction(Constants.Controller.Index, Constants.Controller.Home);
            }
            return View(@event);
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
            return View(@event);
        }

        // POST: Event/Delete/5
        [HttpPost, ActionName(Constants.Controller.Delete)]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Event @event = _gameservice.FindRecord(id);
            _gameservice.DeleteRecord(@event);
            return RedirectToAction(Constants.Controller.Index,Constants.Controller.Home);
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
