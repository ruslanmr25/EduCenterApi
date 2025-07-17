

using EduCenter.Frontend.Interfaces;
using EduCenter.Frontend.Responses;
using EduCenterApi.Application.DTOs.UserDtos;
using EduCenterApi.Domain.Entities;

namespace EduCenter.Frontend.Clients;

public class UserClient(HttpClient httpClient) : BaseClient<User>(httpClient), IClient
{

    public override string Uri { get; set; } = "/api/super-admin/users";



    public async Task<PaginatedResponse<User>> GetAllAsync(int pageIndex = 1, int pageSize = 40)
    {

        return await base.GetAllAsync(Uri, pageIndex, pageSize);
    }

    public async Task<PaginatedResponse<User>> GetAllCenterAdmins(int pageIndex = 1, int pageSize = 40)
    {
        var fullUrl = $"{Uri}/center-admins?pageIndex={pageIndex}&pageSize={pageSize}";


        var response = await _httpClient.GetFromJsonAsync<PaginatedResponse<User>>(fullUrl);

        return response ?? new PaginatedResponse<User>();

    }




    public async Task CreateAsync(CreateUserDto user)
    {
        await base.CreateAsync<CreateUserDto>(Uri, user);
    }
    public async Task UpdateAsync(int Id, UpdateUserDto userDto)
    {
        var url = $"{Uri}/{Id}";
        await base.UpdateAsync<UpdateUserDto>(url, userDto);
    }


    public async Task<User> GetCenterByIdAsync(int id)
    {

        return await base.GetByIdAsync(id, Uri);
    }




}
