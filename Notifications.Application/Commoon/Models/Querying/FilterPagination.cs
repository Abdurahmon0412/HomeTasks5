namespace Notifications.Application.Commoon.Models.Querying;

public class FilterPagination
{
    public uint PageSize { get; set; } = 10;

    public uint PageToken { get; set; } = 1;
}