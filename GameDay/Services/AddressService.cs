using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Domain.Layer.DataAccessLayer;
using Domain.Layer.Models;
using GameDay.Services.Interfaces;

namespace GameDay.Services
{
    public class AddressService : IAddress
    {
        GameDayContext db = new GameDayContext();

        public List<Address> GetAddresses()
        {
            return db.Locations.ToList();
        }

        public Address FindAddress(int? id)
        {
            return db.Locations.Find(id);
        }

        public void AddAddress(Address a)
        {
            db.Locations.Add(a);
            SaveChanges();
        }

        public void EditAddress(Address a)
        {
            db.Entry(a).State = EntityState.Modified;
            SaveChanges();
        }

        public void DeleteAddress(Address a)
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