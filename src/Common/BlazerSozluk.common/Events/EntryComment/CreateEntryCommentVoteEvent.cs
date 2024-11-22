using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlazerSozluk.common.ViewModels;

namespace BlazerSozluk.common.Events.EntryComment
{
    public class CreateEntryCommentVoteEvent
    {
      public Guid EntryCommentId { get; set; }
      public VoteType voteType { get; set; }    
      public Guid CreatedBy { get; set; }


    }
}
