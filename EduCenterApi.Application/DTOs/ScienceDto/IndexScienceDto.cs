using System;
using EduCenterApi.Domain.Entities;

namespace EduCenterApi.Application.DTOs.ScienceDto;

public class IndexScienceDto
{


     public int Id { get; set; }


     public required string Name { get; set; }
    
    
    public int CenterId { get; set; }
    public Center Center { get; set; }


}
