using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Notifications.Application.Commoon.Models.Querying;
using Notifications.Application.Commoon.Notifications.Services;
using Notifications.Application.Commoon.Querying.Extensions;
using Notifications.Domain.Entities;
using Notifications.Persistance.Repositories.Interfaces;
using System.Linq.Expressions;

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


    public IQueryable<SmsTemplate> Get(Expression<Func<SmsTemplate, bool>>? predicate = null, bool asNoTracking = false)
        => _smsTemplateRepository.Get(predicate, asNoTracking);

    public async ValueTask<IList<SmsTemplate>> GetByFilterAsync(FilterPagination paginationOptions, bool asNoTracking = false, CancellationToken cancellationToken = default)
        => await Get(asNoTracking: asNoTracking)
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
