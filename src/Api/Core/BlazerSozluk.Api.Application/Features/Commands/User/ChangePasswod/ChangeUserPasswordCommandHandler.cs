using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlazerSozluk.Api.Application.Interfaces.Repositories;
using BlazerSozluk.common.Events.User;
using BlazerSozluk.common.Infrastructure;
using BlazerSozluk.common.Infrastructure.Exceptions;
using MediatR;

namespace BlazerSozluk.Api.Application.Features.Commands.User.ChangePasswod
{
    public class ChangeUserPasswordCommandHandler : IRequestHandler<ChangeUserPasswordCommand, bool>
    {

        public readonly IUserRepository userRepository;

        public ChangeUserPasswordCommandHandler(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task<bool> Handle(ChangeUserPasswordCommand request, CancellationToken cancellationToken)
        {
            if(!request.UserId.HasValue)
                throw new ArgumentNullException(nameof(request.UserId));

            var dbUser = await userRepository.GetByIdAsync(request.UserId.Value);
          
            var encPass= PasswordEncryptor.Encrpt(request.oldPassword);

            if (dbUser.Password != encPass)
                throw new DataBaseValidationException("old password is wrong");

            dbUser.Password= PasswordEncryptor.Encrpt(request.newPassword);
            await userRepository.UpdateAsync(dbUser);

            return true;
        }
    }
}
