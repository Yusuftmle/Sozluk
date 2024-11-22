using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlazerSozluk.Api.Application.Interfaces.Repositories;
using BlazerSozluk.common.Infrastructure.Exceptions;
using MediatR;

namespace BlazerSozluk.Api.Application.Features.Commands.User.ConfirmEmail
{
    public class ConfirmEmailCommandHandler : IRequestHandler<ConfirmEmailCommand, bool>
    {
        private readonly IUserRepository userRepository;
        private readonly IEmailConfimationRepository emailConfimationRepository;

        public ConfirmEmailCommandHandler(IUserRepository userRepository, IEmailConfimationRepository emailConfimationRepository)
        {
            this.userRepository = userRepository;
            this.emailConfimationRepository = emailConfimationRepository;
        }

        public async Task<bool> Handle(ConfirmEmailCommand request, CancellationToken cancellationToken)
        {
            var confimation = await emailConfimationRepository.GetByIdAsync(request.ConfirmationId);
            if (confimation is null) 
               throw new DataBaseValidationException("confirmation not found");
            

            var dbUser = await userRepository.GetSingleAsync(i => i.EmailAddress == confimation.NewEmail);

            if(dbUser is null)
              throw new DataBaseValidationException("User Not Found with this email");

            if (dbUser.EmailConfirmed)
                throw new DataBaseValidationException("email address is already confirmed");

            dbUser.EmailConfirmed = true;

            await userRepository.UpdateAsync(dbUser);

            return true;


        }
    }
}
