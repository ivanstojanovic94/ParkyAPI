﻿using ParkyAPI.Data;
using ParkyAPI.Models;
using ParkyAPI.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkyAPI.Repository
{
    public class NationalParkRepository : INationalParkRepository
    {
        private readonly ApplicationDbContext _db;

        public NationalParkRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public bool CreateNationalPark(NationalPark nationalPark)
        {
            _db.NationalParks.Add(nationalPark);
            return Save();
        }

        public bool DeleteNationalPark(NationalPark nationalPark)
        {
            _db.NationalParks.Remove(nationalPark);
            return Save();
        }

        public NationalPark GetNationalPark(int nationalParkId)
        {
            return _db.NationalParks.FirstOrDefault(e => e.Id == nationalParkId);
        }

        public ICollection<NationalPark> GetNationalParks()
        {
            return _db.NationalParks.OrderBy(e => e.Name).ToList();
        }

        public bool NationalParkExists(string name)
        {
            bool value = _db.NationalParks.Any(e => e.Name.ToLower().Trim() == name.ToLower().Trim());
            return value;
        }

        public bool NationalParkExists(int Id)
        {
            return _db.NationalParks.Any(e => e.Id == Id);
        }

        public bool Save()
        {
            return _db.SaveChanges() >= 0 ? true : false;
        }

        public bool UpdateNationalPark(NationalPark nationalPark)
        {
             _db.NationalParks.Update(nationalPark);
            return Save();
        }
    }
}
