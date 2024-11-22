using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazerSozluk.Api.Domain.Models
{
    public class EmailConfirmation:BaseEntity
    {
        public string OldEmail { get; set; }
        public string NewEmail { get; set; }
    }
}
