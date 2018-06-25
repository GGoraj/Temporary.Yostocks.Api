using System.Linq;
using System.Threading.Tasks;
using Yostocks.Api.Domain.YostocksUsers;


namespace Yostocks.Api.Application.Interfaces
{
    public interface IYostocksUserRepository
    {
        IQueryable<YostocksUser> GetYoStocksUsers();
        Task RegisterUser(YostocksUser yostocksUser);
        YostocksUser GetUserProfile(YoustocksUserProfileBindingModel userProfile);
        YostocksUser GetUserByEmail(string email);


    }
}
