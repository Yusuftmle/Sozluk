using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlazerSozluk.Api.Domain.Models;
using BlazerSozluk.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlazerSozluk.Infrastructure.Persistence.EntitiyConfigurations
{
    public  class EmailConfirmationEntityConfiguration:BaseEntityConfiguartion<EmailConfirmation>
    {
        public override void Configure(EntityTypeBuilder<EmailConfirmation> builder)
        {
            base.Configure(builder);
            builder.ToTable("emailconfirmation", BlazerSozlukContext.DEFAULT_SCHEMA);
        }
    }
}
