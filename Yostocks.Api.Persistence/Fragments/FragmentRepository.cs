using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Yostocks.Api.Application.Interfaces;
using Yostocks.Api.Domain.Fragments;
using Yostocks.Api.Persistence;

namespace Yostocks.Api.Service.Models.Repositories
{
    public class FragmentRepository : IFragmentRepository
    {
        private YostocksDbContext _db;
        private DbSet<Fragment> fragments;

        //CONSTRUCTOR
        public FragmentRepository(YostocksDbContext db)
        {
            _db = db;
            fragments = db.Fragments;
        }

        //AddFragment
        public void AddFragment(Fragment fragment)
        {
            fragments.Add(fragment);
            _db.SaveChanges();
        }

        public List<Fragment> GetUserFragmentsByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public ICollection<Fragment> GetUserFragmentsByUserId(int id)
        {
            throw new NotImplementedException();
        }
        
    }
}