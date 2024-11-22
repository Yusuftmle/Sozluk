using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlazerSozluk.common.ViewModels;

namespace BlazerSozluk.Api.Domain.Models
{
    public  class EntryCommentVote:BaseEntity
    {
        public Guid EntryCommentId { get; set; }
        public VoteType voteType { get; set; }

        public Guid CreateById { get; set; }

        public virtual EntryComment EntryComment { get; set; }

    }
}
