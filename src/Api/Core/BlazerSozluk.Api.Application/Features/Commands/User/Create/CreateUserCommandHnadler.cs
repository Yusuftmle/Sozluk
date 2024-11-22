using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BlazerSozluk.Api.Application.Interfaces.Repositories;
using BlazerSozluk.Api.Domain.Models;
using BlazerSozluk.common;
using BlazerSozluk.common.Events.User;
using BlazerSozluk.common.Infrastructure;
using BlazerSozluk.common.Infrastructure.Exceptions;
using BlazerSozluk.common.Models.Queries;
using BlazerSozluk.common.Models.RequestModels;
using MediatR;
using Microsoft.Extensions.Configuration;

namespace BlazerSozluk.Api.Application.Features.Commands.User.Create
{
    public class CreateUserCommandHnadler : IRequestHandler<CreateUserCommand, Guid>
    {
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;

        public CreateUserCommandHnadler(IUserRepository userRepository, IMapper mapper)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
        }

        public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var existUser =await userRepository.GetSingleAsync(i => i.EmailAddress == request.EmailAddress);

            if (existUser is not null)
            {
                throw new DataBaseValidationException("User already exist");
            }

            var pass = PasswordEncryptor.Encrpt(request.Password);

            var dbUser = mapper.Map<Domain.Models.User>(request);
			dbUser.Password = pass;

			var rows= await userRepository.AddAsync(dbUser);


            //email created/changed

            if (rows > 0)
            {
                var @event = new UserEmailChangedEvent()
                {
                    OldEmailAddress = null,
                    NewEmailAddress = request.EmailAddress,
                };
                QueueFactory.SendMessageToExchange(exchangeName:SozlukConstants.UserExchangeName,obj:@event,
                                                   exchangeType:SozlukConstants.DefaultExchangeType,
                                                   queueName:SozlukConstants.UserEmailChangedQueueName);
            }
            return dbUser.Id;
        }
      
    }

}
