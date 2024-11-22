using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlazerSozluk.Api.Application.Features.Commands.EntryCommand.CreateFav;
using BlazerSozluk.common;
using BlazerSozluk.common.Events.EntryComment;
using BlazerSozluk.common.Infrastructure;
using MediatR;

namespace BlazerSozluk.Api.Application.Features.Commands.EntryComment.CreateFav
{
    public class CreateEntryCommentFavCommandHandler : IRequestHandler<deleteentryCommentFavCommand, bool>
    {
        async Task<bool> IRequestHandler<deleteentryCommentFavCommand, bool>.Handle(deleteentryCommentFavCommand request, CancellationToken cancellationToken)
        {
            QueueFactory.SendMessageToExchange(exchangeName: SozlukConstants.FavExchangeName,
                                              exchangeType: SozlukConstants.DefaultExchangeType,
                                              queueName: SozlukConstants.CreateEntryCommentFavQueueName,
                                              obj: new CreateEntryCommentFavEvent()
                                              {
                                                  EntryCommentId = request.EntryCommentId,
                                                  CreatedBy = request.UserId
                                              });

            return await Task.FromResult(true);
        }
    }
}
