using AutoMapper;
using Notifications.Application.Commoon.Notifications.Models;
using Notifications.Domain.Entities;

namespace Notifications.Infrastructure.Common.Mappers;

public class NotificationHistoryMapper : Profile
{
    public NotificationHistoryMapper()
    {
        CreateMap<EmailMessage, EmailHistory>()
            .ForMember(dest => dest.TemplateId, options => options.MapFrom(src => src.Template.Id))
            .ForMember(dest => dest.Content, options => options.MapFrom(src => src.Body));

        CreateMap<SmsMessage, SmsHistory>()
            .ForMember(dest => dest.TemplateId, options => options.MapFrom(src => src.Template.Id))
            .ForMember(dest => dest.Content, options => options.MapFrom(src => src.Message));
    }
}