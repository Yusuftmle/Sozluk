using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlazerSozluk.common;
using BlazerSozluk.common.Events.Entry;
using BlazerSozluk.common.Events.EntryComment;
using BlazerSozluk.common.Infrastructure;
using MediatR;
using RabbitMQ.Client;

namespace BlazerSozluk.Api.Application.Features.Commands.Entry.CreateFav
{
    public class CreateEntryFavCommandHandler : IRequestHandler<CreateEntryFavCommand, bool>
    {

        public async Task<bool> Handle(CreateEntryFavCommand request, CancellationToken cancellationToken)
        {
            QueueFactory.SendMessageToExchange(exchangeName: SozlukConstants.FavExchangeName,
                                              exchangeType: SozlukConstants.DefaultExchangeType,
                                              queueName: SozlukConstants.CreateEntryFavQueueName,
                                              obj: new CreateEntryFavEvent()
                                              {
                                                  EntryId = request.EntryId,
                                                  CreatedBy = request.UserId
                                              });

            return await Task.FromResult(true);
        }
    }
}
