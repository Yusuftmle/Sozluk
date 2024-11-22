using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazerSozluk.Api.Domain.Models
{
    public  class EntryCommentFavorite:BaseEntity
    {
        public Guid EntryId { get; set; }
        public Guid CreatedById { get; set; }

        public virtual EntryComment Entry { get; set; }
        public virtual User CreatedUser { get; set; }
        public virtual ICollection<EntryCommentFavorite> EntryCommentFavorites { get; set; }


    }
}
