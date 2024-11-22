using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace BlazerSozluk.Api.Application.Features.Commands.EntryCommand.CreateFav
{
    public class deleteentryCommentFavCommand:IRequest<bool>
    {
        public deleteentryCommentFavCommand(Guid entryCommandId, Guid userId)
        {
            EntryCommentId = entryCommandId;
            UserId = userId;
        }

        public Guid EntryCommentId { get; set; }    
        public Guid UserId { get; set;}

        public deleteentryCommentFavCommand()
        {
            
        }

    }
}
