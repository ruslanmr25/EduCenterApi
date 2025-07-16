using System;
using EduCenter.Frontend.Responses;
using EduCenterApi.Application.DTOs.StudentDto;
using EduCenterApi.Domain.Entities;

namespace EduCenter.Frontend.Clients;

public class StudentClient(HttpClient httpClient) : BaseClient<Student>(httpClient)
{
     public override string Uri { get; set; } = "/api/center-admin/students";


     public async Task<PaginatedResponse<IndexStudentDto>> GetAllAsync(int pageIndex = 1, int pageSize = 40)
     {

          var fullUrl = $"{Uri}?pageIndex={pageIndex}&pageSize={pageSize}";


          var response = await _httpClient.GetFromJsonAsync<PaginatedResponse<IndexStudentDto>>(fullUrl);

          return response ?? new PaginatedResponse<IndexStudentDto>();

     }






     public async Task CreateAsync(CreateStudentDto studentDto)
     {
          await base.CreateAsync<CreateStudentDto>(Uri, studentDto);
     }
     public async Task UpdateAsync(int Id, UpdateStudentDto studentDto)
     {
          var url = $"{Uri}/{Id}";
          await base.UpdateAsync<UpdateStudentDto>(url, studentDto);
     }


     public async Task<Student> GetStudentByIdAsync(int id)
     {

          return await base.GetByIdAsync(id, Uri);
     }



}
