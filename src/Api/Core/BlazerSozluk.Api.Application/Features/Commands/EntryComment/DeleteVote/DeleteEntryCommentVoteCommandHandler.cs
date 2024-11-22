using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlazerSozluk.common.Events.EntryComment;
using BlazerSozluk.common.Infrastructure;
using BlazerSozluk.common;
using MediatR;

namespace BlazerSozluk.Api.Application.Features.Commands.EntryComment.DeleteVote
{
    public class DeleteEntryCommentVoteCommandHandler : IRequestHandler<DeleteEntryCommentVoteCommand, bool>
    {
        public async Task<bool> Handle(DeleteEntryCommentVoteCommand request, CancellationToken cancellationToken)
        {
            QueueFactory.SendMessageToExchange(exchangeName: SozlukConstants.VoteExchangeName,
                                               exchangeType: SozlukConstants.DefaultExchangeType,
                                               queueName: SozlukConstants.CreateEntryCommentVoteQueueName,
                                               obj: new DeleteEntryCommentVoteEvent()
                                               {
                                                   EntryCommentId = request.EntryCommentId,                                                
                                                   CreatedBy = request.UserId

                                           });

            return await Task.FromResult(true);
        }
    }
}
