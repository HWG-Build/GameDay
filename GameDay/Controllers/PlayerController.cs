using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Domain.Layer.DataAccessLayer;
using Domain.Layer.Models;
using GameDay.Services.Interfaces;

namespace GameDay.Controllers
{
    public class PlayerController : Controller
    {
        private readonly IPlayer playerservice;
        public PlayerController(IPlayer playerservice)
        {
            this.playerservice = playerservice;
        }

        // GET: Player
        public ActionResult Index()
        {
            return View(playerservice.GetPlayers());
        }

        // GET: Player/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Player player = playerservice.FindPlayer(id);
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
        public ActionResult Create([Bind(Include = "ID,FirstName,LastName,Position,Phone")] Player player)
        {
            if (ModelState.IsValid)
            {
                playerservice.AddPlayer(player);
                return RedirectToAction("Index");
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
            Player player = playerservice.FindPlayer(id);
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
        public ActionResult Edit([Bind(Include = "ID,FirstName,LastName,Position,Phone")] Player player)
        {
            if (ModelState.IsValid)
            {
                playerservice.EditPlayer(player);
                return RedirectToAction("Index");
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
            Player player = playerservice.FindPlayer(id);
            if (player == null)
            {
                return HttpNotFound();
            }
            return View(player);
        }

        // POST: Player/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Player player = playerservice.FindPlayer(id);
            playerservice.DeletePlayer(player);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                playerservice.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
