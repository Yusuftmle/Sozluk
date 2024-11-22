using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlazerSozluk.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlazerSozluk.Infrastructure.Persistence.EntitiyConfigurations.EntryComment
{
    public class EntryCommentEntityConfiguration : BaseEntityConfiguartion<Api.Domain.Models.EntryComment>
    {
        public override void Configure(EntityTypeBuilder<Api.Domain.Models.EntryComment> builder)
        {
            // Base yapılandırmayı çağır    
            base.Configure(builder);

            // Tablo adını "entrycomment" olarak ayarla ve varsayılan şema kullan
            builder.ToTable("entrycomment", BlazerSozlukContext.DEFAULT_SCHEMA);

            // CreatedBy ile birebir ilişki kur ve yabancı anahtar olarak CreatedById'yi kullan
            builder.HasOne(i => i.CreatedBy)
          .WithMany(i => i.EntryComments)
          .HasForeignKey(i => i.CreatedById)
          .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(i => i.Entry)
                .WithMany(i => i.EntryComments)
                .HasForeignKey(i => i.EntryId);
        }
    }

}
