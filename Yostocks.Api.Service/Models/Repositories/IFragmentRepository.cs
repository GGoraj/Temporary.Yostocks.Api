using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yostocks.Api.Service.Models.Repositories
{
    public interface IFragmentRepository
    {
        void AddFragmentAsync(Fragment fragment);
        List<Fragment> GetUserRelatedFragments(string email);

    }
}
