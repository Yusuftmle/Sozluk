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
    public class UserEntityConfiguration:BaseEntityConfiguartion<User>
    {

        public override void Configure(EntityTypeBuilder<User> builder)
        {
            base.Configure(builder);
            builder.ToTable("user",BlazerSozlukContext.DEFAULT_SCHEMA);
        }
    }
}
