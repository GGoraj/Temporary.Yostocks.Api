using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yostocks.Api.Domain.Fragments;

namespace Yostocks.Api.Application.Interfaces
{
    public interface IFragmentRepository
    {
        void AddFragment(Fragment fragment);
        List<Fragment> GetUserFragmentsByEmail(string email);
        ICollection<Fragment> GetUserFragmentsByUserId(int id);

    }
}
