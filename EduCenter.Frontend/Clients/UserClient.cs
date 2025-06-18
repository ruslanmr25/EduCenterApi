

using EduCenter.Frontend.Responses;
using EduCenterApi.Domain.Entities;
using EduCenterApi.Application.DTOs.UserDtos;

namespace EduCenter.Frontend.Clients;

public class UserClient(HttpClient httpClient) : BaseClient<User>(httpClient)
{


    public string uri = "/api/super-admin/users";



    public async Task<PaginatedResponse<User>> GetAllAsync(int pageIndex = 1, int pageSize = 40)
    {

        return await base.GetAllAsync(uri, pageIndex, pageSize);
    }


    public async Task CreateAsync(CreateUserDto user)
    {
        await base.CreateAsync<CreateUserDto>(uri, user);
    }




}
