using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazerSozluk.common
{
    public class SozlukConstants
    {
        public const string RabbitMqHost = "localhost";
        public const string DefaultExchangeType = "direct";

        public const string UserExchangeName= "UserExchange";
        public const string UserEmailChangedQueueName = "UserEmailChangedQueue";
        //fav Exchange Name
        public const string FavExchangeName = "FavExchangeName";
        public const string CreateEntryFavQueueName = "CreateEntryFavQueue";
        public const string CreateEntryCommentFavQueueName= "CreateEntryCommentFavQueue";
        public const string DeleteEntryFavQueueName = "DeleteEntryFavQueue";

        public const string VoteExchangeName = "VoteExchangeName";
        public const string CreateEntryVoteQueueName = "CreateEntryVoteQueue";

        public const string DeleteEntryVoteQueueName = "DeleteEntryVoteQueue";

        public const string CreateEntryCommentVoteQueueName = "CreateEntryCommentVoteQueue";


        public const string DeleteEntryCommentFavQueueName = "DeleteEntryCommentFavQueue";

        public const string DeleteEntryCommentVoteQueueName = " DeleteEntryCommentVoteQueue";

    }
}
