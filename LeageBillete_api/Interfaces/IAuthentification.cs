using LeageBillete_api.Model.Request;
using LeageBillete_api.Model.RequestResp;

namespace LeageBillete_api.Interfaces
{
    public interface IAuthentification
    {
        public Task<AuthentificationResp> login(AuthRequest inputs);
        public Task<bool> RegisterUser(RegistrationRequest request, int tipeUser);
        public Task DataIni();
    }
}
