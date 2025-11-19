using AutoMapper;
using Opi.Reports.Application.DTOs;
using Opi.Reports.Domain.Entities;

namespace Opi.Reports.Application.Mappings
{
    public class ReportRecordProfile : Profile
    {
        public ReportRecordProfile()
        {
            CreateMap<ReportRecord, ReportRecordDto>().ForMember(dest => dest.CreatedAt,opt => opt.MapFrom(src => DateTime.SpecifyKind(src.CreatedAt, DateTimeKind.Utc))).ReverseMap();
        }
    }
}
