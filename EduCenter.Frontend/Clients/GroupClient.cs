using System;
using EduCenter.Frontend.Responses;
using EduCenterApi.Application.DTOs.GroupDto;
using EduCenterApi.Domain.Entities;

namespace EduCenter.Frontend.Clients;

public class GroupClient(HttpClient httpClient) : BaseClient<Group>(httpClient)
{
     public override string Uri { get; set; } = "/api/center-admin/groups";

     public async Task<PaginatedResponse<Group>> GetAllAsync(int pageIndex = 1, int pageSize = 40)
     {

          return await base.GetAllAsync(Uri, pageIndex, pageSize);
     }



     public async Task CreateAsync(CreateGroupDto groupDto)
     {
          await base.CreateAsync<CreateGroupDto>(Uri, groupDto);
     }
     public async Task UpdateAsync(int Id, UpdateGroupDto groupDto)
     {
          var url = $"{Uri}/{Id}";
          await base.UpdateAsync<UpdateGroupDto>(url, groupDto);
     }


     public async Task<Group> GetGroupByIdAsync(int id)
     {

          return await base.GetByIdAsync(id, Uri);
     }

}
