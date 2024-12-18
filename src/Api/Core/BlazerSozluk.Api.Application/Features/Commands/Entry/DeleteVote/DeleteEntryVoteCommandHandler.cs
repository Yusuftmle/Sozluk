﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlazerSozluk.common.Events.Entry;
using BlazerSozluk.common.Infrastructure;
using BlazerSozluk.common;
using MediatR;

namespace BlazerSozluk.Api.Application.Features.Commands.Entry.DeleteVote
{
    public class DeleteEntryVoteCommandHandler : IRequestHandler<DeleteEntryVoteCommand, bool>
    {
        public async Task<bool> Handle(DeleteEntryVoteCommand request, CancellationToken cancellationToken)
        {
            QueueFactory.SendMessageToExchange(exchangeName: SozlukConstants.VoteExchangeName,
                                               exchangeType: SozlukConstants.DefaultExchangeType,
                                               queueName: SozlukConstants.DeleteEntryVoteQueueName,
                                               obj: new DeleteEntryVoteEvent()
                                               {
                                                   EntryId = request.EntryId,
                                                   CreatedBy = request.UserId,
                                                   

                                               });

            return await Task.FromResult(true);
        }
    }
}
