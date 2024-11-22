using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BlazerSozluk.Api.Domain.Models;
using BlazerSozluk.common.Models.Queries;
using BlazerSozluk.common.Models.RequestModels;

namespace BlazerSozluk.Api.Application.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<User, LoginUserViewModel>()
                .ReverseMap();

            CreateMap<CreateUserCommand, User>();

            CreateMap<UpdateUserCommand, User>();
			CreateMap<UserDetailViewModel, User>()
			   .ReverseMap();

			CreateMap<CreateEntryCommand, Entry>()
                .ReverseMap();
            CreateMap<Entry, GetEntriesViewModel>()
               .ForMember(x => x.CommentCount, y => y.MapFrom(z => z.EntryComments.Count));

            CreateMap<CreateEntryCommentCommand , EntryComment>()
                .ReverseMap();

			

		}
    }
}
