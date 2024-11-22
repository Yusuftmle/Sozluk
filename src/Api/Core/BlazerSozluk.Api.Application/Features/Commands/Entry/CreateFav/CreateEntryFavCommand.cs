using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace BlazerSozluk.Api.Application.Features.Commands.Entry.CreateFav
{
    public class CreateEntryFavCommand:IRequest<bool>
    {
        public Guid EntryId { get; set; }
        public Guid UserId { get; set; }
        public CreateEntryFavCommand(Guid entryId)
        {

        }

        public CreateEntryFavCommand(Guid entryId, Guid userId)
        {
            EntryId = entryId;
            UserId = userId;
        }
        
    }
}
