using EduCenter.Frontend.Responses;
using EduCenterApi.Domain.Entities;

namespace EduCenter.Frontend.Clients
{
    public class RoleClient(HttpClient httpClient) : BaseClient<Role>(httpClient)
    {

        public string uri = "/api/super-admin/roles";



        public async Task<PaginatedResponse<Role>>? GetAllAsync(int pageIndex = 1, int pageSize = 40)
        {

            return await base.GetAllAsync(uri, pageIndex, pageSize);
        }

    }
}
