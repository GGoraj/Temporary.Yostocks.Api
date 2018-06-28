using System.Linq;
using System.Threading.Tasks;
using Yostocks.Api.Domain.YostocksUsers;
using Yostocks.Api.Infrastructure.YostocksUsers;


namespace Yostocks.Api.Application.Interfaces
{
    public interface IYostocksUserRepository
    {
        IQueryable<YostocksUser> GetYoStocksUsers();
        Task RegisterUser(YostocksUser yostocksUser);
        YostocksUser GetUserProfile(YostocksUserProfileBindingModel userProfile);
        YostocksUser GetUserByEmail(string email);


    }
}
