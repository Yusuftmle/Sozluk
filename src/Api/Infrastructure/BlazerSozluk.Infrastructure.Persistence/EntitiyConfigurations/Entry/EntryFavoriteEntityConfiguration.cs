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
    public class EntryFavoriteEntityConfiguration : BaseEntityConfiguartion<EntryFavorite>
    {
        public override void Configure(EntityTypeBuilder<EntryFavorite> builder)
        {
            // Base yapılandırmayı çağır
            base.Configure(builder);

            // Tablo adını "entryfavorite" olarak ayarla ve varsayılan şema kullan
            builder.ToTable("entryfavorite", BlazerSozlukContext.DEFAULT_SCHEMA);

            // Entry ile birebir ilişki kur ve yabancı anahtar olarak EntryId'yi kullan
            builder.HasOne(i => i.Entry)
                   .WithMany(i => i.EntryFavorites)
                   .HasForeignKey(i => i.EntryId);

            // CreatedUser ile birebir ilişki kur ve yabancı anahtar olarak CreatedById'yi kullan
            builder.HasOne(i => i.CreatedUser)
                   .WithMany(i => i.EntryFavorites)
                   .HasForeignKey(i => i.CreatedById)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }

}
