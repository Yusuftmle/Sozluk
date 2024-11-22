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
    public class EntryCommentFavoriteEntityConfiguration:BaseEntityConfiguartion<EntryCommentFavorite>
    {
        public override void Configure(EntityTypeBuilder<EntryCommentFavorite> builder)
        {
            base.Configure(builder);
            builder.ToTable("EntryCommentFavorite", BlazerSozlukContext.DEFAULT_SCHEMA);

            // CreatedBy ile birebir ilişki kur ve yabancı anahtar olarak CreatedById'yi kullan
            builder.HasOne(i => i.Entry)
               .WithMany(i => i.EntryCommentFavorites)
               .HasForeignKey(i => i.EntryId);

            builder.HasOne(i => i.CreatedUser)
                .WithMany(i => i.EntryCommonFavorites)
                .HasForeignKey(i => i.CreatedById)
                .OnDelete(DeleteBehavior.Restrict);


        }
    }
}
