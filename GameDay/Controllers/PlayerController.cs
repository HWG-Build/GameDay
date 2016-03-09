using System.Net;
using System.Web.Mvc;
using Data.Layer;
using Data.Layer.Models;
using Data.Layer.Interfaces;
using GameDay.Models;
using System.Linq;

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
        [HttpGet]
        public ActionResult Index()
        {
            return View(_playerservice.GetRecords().Select(x => new PlayerVM()
            {
                ID = x.ID,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Position = x.Position,
                Phone = x.Phone
        }));
        }

        // GET: Player/Details/5
        [HttpGet]
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
            PlayerVM playerVM = MapModelVM(player);
            playerVM.Audit = _playerservice.GetAuditLogs(player.ID).ToList();
            return View(playerVM);
        }

        // GET: Player/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Player/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PlayerVM player)
        {
            Player p = new Player();
            if (ModelState.IsValid)
            {
                p = MapModel(player);
                _playerservice.AddRecord(p);
                return RedirectToAction(Constant.Controller.Index);
            }

            return View(p);
        }

        // GET: Player/Edit/5
        [HttpGet]
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
            PlayerVM playerVM = MapModelVM(player);
            return View(playerVM);
        }

        // POST: Player/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PlayerVM player)
        {
            Player p = new Player();
            if (ModelState.IsValid)
            {
                p = MapModel(player);
                _playerservice.EditRecord(p);
                return RedirectToAction(Constant.Controller.Index);
            }
            return View(p);
        }

        // GET: Player/Delete/5
        [HttpGet]
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
            PlayerVM playerVM = MapModelVM(player);
            return View(playerVM);
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

        private PlayerVM MapModelVM(Player player)
        {
            PlayerVM playerVM = new PlayerVM
            {
                ID = player.ID,
                FirstName = player.FirstName,
                LastName = player.LastName,
                FullName = player.FirstName + " " + player.LastName,
                Position = player.Position,
                Phone = player.Phone,
            };
            return playerVM;
        }

        private Player MapModel(PlayerVM playerVM)
        {
            Player p = new Player
            {
                ID = playerVM.ID,
                FirstName = playerVM.FirstName,
                LastName = playerVM.LastName,
                FullName = playerVM.FirstName + "" + playerVM.LastName,
                Position = playerVM.Position,
                Phone = playerVM.Phone,
            };
            return p;
        }
    }
}
