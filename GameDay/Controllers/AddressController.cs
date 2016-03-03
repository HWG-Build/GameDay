using System.Net;
using System.Web.Mvc;
using Data.Layer.Interfaces;
using Data.Layer.Models;
using Data.Layer;
using GameDay.Models;
using System.Linq;

namespace GameDay.Controllers
{
    [Authorize]
    public class AddressController : Controller
    {
        //Inject Address Service into the controller
        private readonly IService<Address> _addressservice;
        public AddressController(IService<Address> addressservice)
        {
            this._addressservice = addressservice;
        }

        // GET: Address
        //Getting a list of all addresses
        [HttpGet]
        public ActionResult Index()
        {

            return View(_addressservice.GetRecords().Select(x=>new AddressVM()
            {
                ID = x.ID,
                Name = x.Name,
                Line1 = x.Line1,
                Line2 = x.Line2,
                City = x.City,
                State = x.State,
                Zip = x.Zip
        }).ToList());
        }

        // GET: Address/Details/5
        //grabbing record and its audit logs
        [HttpGet]
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
            AddressVM addressVM = MapModelVM(address);
            addressVM.Audit = _addressservice.GetAuditLogs(address.ID).ToList();      
            return View(addressVM);
        }

        // GET: Address/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Address/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(/*[Bind(Include = Constant.Controller.AddressFields)]*/ AddressVM address)
        {
            Address a = new Address();
            if (ModelState.IsValid)
            {
                a = MapModel(address);
                _addressservice.AddRecord(a);
                return RedirectToAction(Constant.Controller.Index);
            }

            return View(a);
        }

        // GET: Address/Edit/5
        [HttpGet]
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
            AddressVM addressVM = MapModelVM(address);
            return View(addressVM);
        }

        // POST: Address/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AddressVM address)
        {
            Address a = new Address();
            if (ModelState.IsValid)
            {
                a = MapModel(address);
                _addressservice.EditRecord(a);
                return RedirectToAction(Constant.Controller.Index);
            }
            return View(a);
        }

        // GET: Address/Delete/5
        [HttpGet]
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
            AddressVM addressVM = MapModelVM(address);
            return View(addressVM);
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

        //Mapping Model to ModelViewModel without the use of AutoMapper
        private AddressVM MapModelVM(Address address)
        {
            AddressVM addressVM = new AddressVM
            {
                ID = address.ID,
                Name = address.Name,
                Line1 = address.Line1,
                Line2 = address.Line2,
                City = address.City,
                State = address.State,
                Zip = address.Zip
            };
            return addressVM;
        }

        //Mapping ModelViewModel to Model without the use of AutoMapper
        private Address MapModel(AddressVM address)
        {
            Address a = new Address
            {
                ID = address.ID,
                Name = address.Name,
                Line1 = address.Line1,
                Line2 = address.Line2,
                City = address.City,
                State = address.State,
                Zip = address.Zip
            };
            return a;
        }
    }
}
