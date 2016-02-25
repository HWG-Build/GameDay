using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Domain.Layer.DataAccessLayer;
using Domain.Layer.Models;
using Domain.Layer.Interfaces;

namespace Domain.Service.Services
{
    public class AddressService : IService<Address>
    {
        GameDayContext db = new GameDayContext();

        public List<Address> GetRecords()
        {
            return db.Locations.ToList();
        }

        public Address FindRecord(int? id)
        {
            return db.Locations.Find(id);
        }

        public void AddRecord(Address a)
        {
            db.Locations.Add(a);
            SaveChanges();
        }

        public void EditRecord(Address a)
        {
            db.Entry(a).State = EntityState.Modified;
            SaveChanges();
        }

        public void DeleteRecord(Address a)
        {
            db.Locations.Remove(a);
            SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }

        public void SaveChanges()
        {
            db.SaveChanges();
        }
    }
}