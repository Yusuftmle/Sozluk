using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlazerSozluk.common.Events.Entry;
using BlazerSozluk.common.Infrastructure;
using BlazerSozluk.common;
using BlazerSozluk.common.Models.RequestModels;
using MediatR;

namespace BlazerSozluk.Api.Application.Features.Commands.Entry.CreateVote
{
    public class CreateEntryVoteCommandHandler : IRequestHandler<CreateEntryVoteCommand, bool>
    {

       
        public async Task<bool> Handle(CreateEntryVoteCommand request, CancellationToken cancellationToken)
        {
            QueueFactory.SendMessageToExchange(exchangeName: SozlukConstants.VoteExchangeName,
                                             exchangeType: SozlukConstants.DefaultExchangeType,
                                             queueName: SozlukConstants.CreateEntryVoteQueueName,
                                             obj: new CreateEntryVoteEvent()
                                             {
                                                 EntryId = request.EntryId,
                                                 CreatedBy = request.CreatedBy,
                                                 VoteType= request.VoteType,
                                                 
                                             });

            return await Task.FromResult(true);
        }
    }
}
