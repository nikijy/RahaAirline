using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class UserMessageRepository : IUserMessageRepository
    {

        private RahaAirlineContext db;

        public UserMessageRepository(RahaAirlineContext context)
        {
            db = context;
        }


        public IEnumerable<UserMessage> GetAllUserMessages()
        {
            return db.UserMessages;
        }

        public UserMessage GetUserMessageById(int userMessageId)
        {
            return db.UserMessages.Find(userMessageId);
        }

        public bool InsertUserMessage(UserMessage userMessage)
        {
            try
            {
                db.UserMessages.Add(userMessage);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool UpdateUserMessage(UserMessage userMessage)
        {
            try
            {
                db.Entry(userMessage).State = EntityState.Modified;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool DeleteUserMessage(int userMessageId)
        {
            try
            {
                var usermessage = GetUserMessageById(userMessageId);
                DeleteUserMessage(userMessageId);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteUserMessage(UserMessage userMessage)
        {
            try
            {
                db.Entry(userMessage).State = EntityState.Deleted;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public void Save()
        {
            db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
