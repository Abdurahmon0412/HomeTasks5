using AutoMapper;
using Notifications.Application.Commoon.Notifications.Models;
using Notifications.Domain.Entities;

namespace Notifications.Infrastructure.Common.Mappers;

public class NotificationHistoryMapper : Profile
{
    public NotificationHistoryMapper()
    {
        CreateMap<EmailMessage, EmailHistory>();
        CreateMap<SmsMessage, SmsHistory>();
    }
}