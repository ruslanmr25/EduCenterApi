using EduCenter.Frontend.Responses;
using EduCenterApi.Domain.Entities;
using EduCenterApi.Application.DTOs.UserDtos;
using EduCenterApi.Application.DTOs.CenterDtos;

namespace EduCenter.Frontend.Clients;

public class CenterClient(HttpClient httpClient) : BaseClient<Center>(httpClient)
{


    public override string Uri { get; set; } = "/api/super-admin/centers";




    public async Task<PaginatedResponse<Center>> GetAllAsync(int pageIndex = 1, int pageSize = 40)
    {

        return await base.GetAllAsync(Uri, pageIndex, pageSize);
    }


    public async Task CreateAsync(CreateCenterDto center)
    {
        await base.CreateAsync<CreateCenterDto>(Uri, center);
    }
    public async Task UpdateAsync(int Id, UpdateCenterDto centerDto)
    {
        var url = $"{Uri}/{Id}";

      
        await base.UpdateAsync<UpdateCenterDto>(url, centerDto);
    }

    public async Task<Center> GetCenterByIdAsync(int id)
    {

        return await base.GetByIdAsync(id, Uri);
    }

    
  



}
