using Notifications.Application.Commoon.Models.Querying;
using Notifications.Application.Commoon.Notifications.Services;
using Notifications.Domain.Entities;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Notifications.Application.Commoon.Querying.Extensions;
using Notifications.Persistance.Repositories.Interfaces;

namespace Notifications.Infrastructure.Common.Notifications.Services.EmailServices;

public class EmailHistoryService : IEmailHistoryService
{
    private readonly IEmailHistoryRopository _emailHistoryRopository;

    public EmailHistoryService(IEmailHistoryRopository emailHistoryRopository)
    {
        _emailHistoryRopository = emailHistoryRopository;
    }

    public ValueTask<EmailHistory> CreateAsync(EmailHistory emailHistory, bool saveChanges = true,
        CancellationToken cancellationToken = default)
        => _emailHistoryRopository.CreateAsync(emailHistory, saveChanges, cancellationToken);

    public async ValueTask<IList<EmailHistory>> GetByFilterAsync(FilterPagination paginationOptions,
        bool asNoTracking = false, CancellationToken cancellationToken = default)
        => await _emailHistoryRopository.Get().ApplyPagination(paginationOptions).ToListAsync(cancellationToken);
}
