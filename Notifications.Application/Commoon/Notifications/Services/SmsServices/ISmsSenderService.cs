﻿namespace Notifications.Application.Commoon.Notifications.Services;

public interface ISmsSenderService
{
    ValueTask<bool> SendAsync(
        string senderPhoneNumber,
        string receiverPhoneNumber,
        string message,
        CancellationToken cancellationToken
    );
}