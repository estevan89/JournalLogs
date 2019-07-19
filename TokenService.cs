using System.Threading.Tasks;

namespace api
{
    public interface ITokenService
    {
        Task<string> GetToken();
    }
}