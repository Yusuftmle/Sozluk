using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlazerSozluk.Api.Domain.Models;
using BlazerSozluk.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlazerSozluk.Infrastructure.Persistence.EntitiyConfigurations.EntryComment
{
    public  class EntryCommentVoteConfiguration:BaseEntityConfiguartion<EntryCommentVote>
    {
        public override void Configure(EntityTypeBuilder<EntryCommentVote> builder)
        {
            base.Configure(builder);

            builder.ToTable("entrycommentvote", BlazerSozlukContext.DEFAULT_SCHEMA);

            builder.HasOne(x => x.EntryComment)
                   .WithMany(i => i.EntryCommentVotes)
                   .HasForeignKey(i => i.EntryCommentId);


        }
    }
}
