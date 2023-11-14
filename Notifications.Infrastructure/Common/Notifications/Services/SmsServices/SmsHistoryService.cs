﻿using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Notifications.Application.Commoon.Models.Querying;
using Notifications.Application.Commoon.Notifications.Services;
using Notifications.Application.Commoon.Querying.Extensions;
using Notifications.Domain.Entities;
using Notifications.Persistance.Repositories.Interfaces;
using System.Linq.Expressions;

namespace Notifications.Infrastructure.Common.Notifications.Services.SmsServices;

public class SmsHistoryService : ISmsHistoryService
{
    private readonly ISmsHistoryRepository _smsHistoryRepository;
    private readonly IValidator<SmsHistory> _smsHistoryValidator;

    public SmsHistoryService(ISmsHistoryRepository smsHistoryRepository,
        IValidator<SmsHistory> validator)
    {
        _smsHistoryRepository = smsHistoryRepository;
        _smsHistoryValidator = validator;
    }

    public IQueryable<SmsHistory> Get(Expression<Func<SmsHistory, bool>>? predicate = null, bool asNoTracking = false)
        => _smsHistoryRepository.Get(predicate, asNoTracking);

    public async ValueTask<IList<SmsHistory>> GetByFilterAsync(FilterPagination paginationOptions, bool asNoTracking = false, CancellationToken cancellationToken = default)
        => await Get(asNoTracking: asNoTracking)
        .ApplyPagination(paginationOptions)
        .ToListAsync(cancellationToken: cancellationToken);

    public ValueTask<SmsHistory> CreateAsync(SmsHistory smsHistory, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        var validationResult = _smsHistoryValidator.Validate(smsHistory);
        if (!validationResult.IsValid)
            throw new InvalidOperationException();

        return _smsHistoryRepository.CreateAsync(smsHistory, saveChanges, cancellationToken);
    }
}