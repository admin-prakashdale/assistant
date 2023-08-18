using Assistant.Model;
using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assistant.Services
{
    public interface IConversationService
    {
        Task<IList<Conversation>> GetConversationsAsync();
    }
    public class ConversationService : IConversationService
    {
        public ConversationService()
        {
            
        }

        
        public async Task<IList<Conversation>> GetConversationsAsync()
        {
            
            return await Task.FromResult<IList<Conversation>>(new List<Conversation>());
        }
    }
}
