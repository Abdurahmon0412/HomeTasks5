using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Notifications.Application.Commoon.Models.Querying;
using Notifications.Application.Commoon.Notifications.Services;
using Notifications.Application.Commoon.Querying.Extensions;
using Notifications.Domain.Entities;
using Notifications.Persistance.Repositories.Interfaces;
using System.Linq.Expressions;
using Notifications.Domain.Enums;

namespace Notifications.Infrastructure.Common.Notifications.Services.SmsServices;

public class SmsTemplateService : ISmsTemplateService
{
    private readonly ISmsTemplateRepository _smsTemplateRepository;
    private readonly IValidator<SmsTemplate> _smsTemplateValidator;

    public SmsTemplateService(
        ISmsTemplateRepository smsTemplateRepository,
        IValidator<SmsTemplate> validator
        )
    {
        _smsTemplateRepository = smsTemplateRepository;
        _smsTemplateValidator = validator;
    }

    public async ValueTask<SmsTemplate?> GetByTypeAsync(
        NotificationTemplateType templateType,
        bool asNoTracking = false,
        CancellationToken cancellationToken = default
    ) =>
        await _smsTemplateRepository.Get(template => template.TemplateType == templateType, asNoTracking)
            .SingleOrDefaultAsync(cancellationToken);


    public async ValueTask<IList<SmsTemplate>> GetByFilterAsync(FilterPagination paginationOptions, bool asNoTracking = false, CancellationToken cancellationToken = default)
        => await _smsTemplateRepository.Get(asNoTracking: asNoTracking)
        .ApplyPagination(paginationOptions)
        .ToListAsync(cancellationToken: cancellationToken);

    public ValueTask<SmsTemplate> CreateAsync(SmsTemplate smsTemplate,
        bool saveChanges = true, 
        CancellationToken cancellationToken = default)
    {
        var validationResult = _smsTemplateValidator.Validate(smsTemplate);
        if(!validationResult.IsValid)
            throw new Exception(validationResult.Errors.ToString());

        return _smsTemplateRepository.CreateAsync(smsTemplate, saveChanges, cancellationToken);
    }
}
