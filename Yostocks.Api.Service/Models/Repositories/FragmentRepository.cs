using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Yostocks.Api.Service.Models.Repositories
{
    public class FragmentRepository : IFragmentRepository
    {
        private ApplicationDbContext _db;
        private DbSet<Fragment> fragments;

        //CONSTRUCTOR
        public FragmentRepository(ApplicationDbContext db)
        {
            _db = db;
            fragments = db.Fragments;
        }

        //AddFragment
        public void AddFragmentAsync(Fragment fragment)
        {
            fragments.Add(fragment);
            _db.SaveChangesAsync();
        }

        public List<Fragment> GetUserRelatedFragments(string email)
        {
            throw new NotImplementedException();
        }
    }
}