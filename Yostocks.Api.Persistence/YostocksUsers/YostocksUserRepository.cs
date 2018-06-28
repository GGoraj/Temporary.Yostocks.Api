using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Yostocks.Api.Application.Interfaces;
using Yostocks.Api.Domain.YostocksUsers;
using Yostocks.Api.Infrastructure.YostocksUsers;

namespace Yostocks.Api.Service.Models.Repositories
{
    public class YostocksUserRepository : IYostocksUserRepository
    {
        public YostocksUser GetUserByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public YostocksUser GetUserProfile(YostocksUserProfileBindingModel userProfile)
        {
            throw new NotImplementedException();
        }

        public IQueryable<YostocksUser> GetYoStocksUsers()
        {
            throw new NotImplementedException();
        }

        public Task RegisterUser(YostocksUser yostocksUser)
        {
            throw new NotImplementedException();
        }
    }
}