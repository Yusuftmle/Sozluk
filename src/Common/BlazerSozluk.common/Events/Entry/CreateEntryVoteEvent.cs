using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlazerSozluk.common.ViewModels;

namespace BlazerSozluk.common.Events.Entry
{
    public class CreateEntryVoteEvent
    {
        public Guid EntryId { get; set; }

        public VoteType VoteType { get; set; }
        public Guid CreatedBy { get; set; }
    }
}

