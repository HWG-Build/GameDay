using System.Net;
using System.Web.Mvc;
using Domain.Layer;
using Domain.Layer.Models;
using Domain.Layer.Interfaces;

namespace GameDay.Controllers
{
    [Authorize]
    public class PlayerController : Controller
    {
        
        private readonly IService<Player> _playerservice;
        public PlayerController(IService<Player> playerservice)
        {
            this._playerservice = playerservice;
        }

        // GET: Player
        public ActionResult Index()
        {
            return View(_playerservice.GetRecords());
        }

        // GET: Player/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Player player = _playerservice.FindRecord(id);
            if (player == null)
            {
                return HttpNotFound();
            }
            return View(player);
        }

        // GET: Player/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Player/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = Constant.Controller.PlayerFields)] Player player)
        {
            if (ModelState.IsValid)
            {
                _playerservice.AddRecord(player);
                return RedirectToAction(Constant.Controller.Index);
            }

            return View(player);
        }

        // GET: Player/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Player player = _playerservice.FindRecord(id);
            if (player == null)
            {
                return HttpNotFound();
            }
            return View(player);
        }

        // POST: Player/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = Constant.Controller.PlayerFields)] Player player)
        {
            if (ModelState.IsValid)
            {
                _playerservice.EditRecord(player);
                return RedirectToAction(Constant.Controller.Index);
            }
            return View(player);
        }

        // GET: Player/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Player player = _playerservice.FindRecord(id);
            if (player == null)
            {
                return HttpNotFound();
            }
            return View(player);
        }

        // POST: Player/Delete/5
        [HttpPost, ActionName(Constant.Controller.Delete)]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Player player = _playerservice.FindRecord(id);
            _playerservice.DeleteRecord(player);
            return RedirectToAction(Constant.Controller.Index);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _playerservice.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
