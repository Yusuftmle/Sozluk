using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace BlazerSozluk.common.Events.User
{
    public class ChangeUserPasswordCommand:IRequest<bool>
    {     
        public Guid? UserId { get; set; }
        public string oldPassword { get; set; }
        public string newPassword { get; set; }

        public ChangeUserPasswordCommand(Guid userId, string oldPassword, string newPassword)
        {
            UserId = userId;
            this.oldPassword = oldPassword;
            this.newPassword = newPassword;
        }
    }
}
