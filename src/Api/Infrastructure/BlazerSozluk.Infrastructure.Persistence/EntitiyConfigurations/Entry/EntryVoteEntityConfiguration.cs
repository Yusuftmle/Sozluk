using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlazerSozluk.Api.Domain.Models;
using BlazerSozluk.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlazerSozluk.Infrastructure.Persistence.EntitiyConfigurations.Entry
{
    public class EntryVoteEntityConfiguration : BaseEntityConfiguartion<EntryVote>
    {
        public override void Configure(EntityTypeBuilder<EntryVote> builder)
        {
            // Base yapılandırmayı çağır
            base.Configure(builder);

            // Tablo adını "entryvote" olarak ayarla ve varsayılan şema kullan
            builder.ToTable("entryvote", BlazerSozlukContext.DEFAULT_SCHEMA);

            // Entry ile birebir ilişki kur ve yabancı anahtar olarak EntryId'yi kullan
            builder.HasOne(i => i.Entry)
                   .WithMany(i => i.EntryVotes)
                   .HasForeignKey(i => i.EntryId);
        }
    }

}
