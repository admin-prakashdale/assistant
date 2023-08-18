using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assistant.Services
{
    public interface IDialogService
    {
        Task <string> DisplayPromptAsync(string title, string message);
    }
    internal class DialogService : IDialogService
    {
        public async Task<string> DisplayPromptAsync(string title, string message)
        {
            var result = await Application.Current.MainPage.DisplayPromptAsync(title, message);

            return result;
        }
    }


}
