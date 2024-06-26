﻿using Confab.Modules.Tickets.Core.DTO;

namespace Confab.Modules.Tickets.Core.Services
{
    internal interface ITicketService
    {
        Task PurchaseAsync(Guid conferenceId, Guid userId);
        Task<IEnumerable<TicketDto>> GetForUserAsync(Guid userId);
    }
}
