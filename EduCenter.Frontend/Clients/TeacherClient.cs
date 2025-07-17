using EduCenter.Frontend.Responses;
using EduCenterApi.Application.DTOs.TeacherDto;
using EduCenterApi.Domain.Entities;

namespace EduCenter.Frontend.Clients;

public class TeacherClient(HttpClient httpClient) : BaseClient<User>(httpClient)
{

    public override string Uri { get; set; } = "/api/center-admin/teachers";

    public async Task<PaginatedResponse<User>> GetAllAsync(int pageIndex = 1, int pageSize = 40)
    {

        return await base.GetAllAsync(Uri, pageIndex, pageSize);
    }






    public async Task CreateAsync(CreateTeacherDto teacherDto)
    {
        await base.CreateAsync<CreateTeacherDto>(Uri, teacherDto);
    }
    public async Task UpdateAsync(int Id, UpdateTeacherDto teacherDto)
    {
        var url = $"{Uri}/{Id}";
        await base.UpdateAsync<UpdateTeacherDto>(url, teacherDto);
    }


    public async Task<User> GetTeacherByIdAsync(int id)
    {

        return await base.GetByIdAsync(id, Uri);
    }


}
