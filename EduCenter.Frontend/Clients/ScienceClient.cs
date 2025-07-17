using EduCenter.Frontend.Responses;
using EduCenterApi.Application.DTOs.ScienceDto;
using EduCenterApi.Domain.Entities;

namespace EduCenter.Frontend.Clients;

public class ScienceClient(HttpClient httpClient) : BaseClient<Since>(httpClient)
{
    public override string Uri { get; set; } = "/api/center-admin/sciences";

    public async Task<PaginatedResponse<Since>> GetAllAsync(int pageIndex = 1, int pageSize = 40)
    {
        return await base.GetAllAsync(Uri, pageIndex, pageSize);
    }

    public async Task CreateAsync(CreateScienceDto science)
    {
        await base.CreateAsync<CreateScienceDto>(Uri, science);
    }

    public async Task UpdateAsync(int Id, UpdateScienceDto scienceDto)
    {
        var url = $"{Uri}/{Id}";

        await base.UpdateAsync<UpdateScienceDto>(url, scienceDto);
    }

    public async Task<Since> GetScienceByIdAsync(int id)
    {
        return await base.GetByIdAsync(id, Uri);
    }
}
