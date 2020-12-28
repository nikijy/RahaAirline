using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
   public interface IUserMessageRepository:IDisposable
    {
        IEnumerable<UserMessage> GetAllUserMessages();
        UserMessage GetUserMessageById(int userMessageId);
        bool InsertUserMessage(UserMessage userMessage);
        bool UpdateUserMessage(UserMessage userMessage);
        bool DeleteUserMessage(UserMessage userMessage);
        bool DeleteUserMessage(int userMessageId);
        void Save();
    }
}
