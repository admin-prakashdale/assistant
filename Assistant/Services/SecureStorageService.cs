using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assistant.Services
{
    public interface ISecureStorageService
    {
        Task SetValue(string key, string value);
    }
    internal class SecureStorageService : ISecureStorageService
    {
        public Task SetValue(string key, string value)
        {
            return SecureStorage.SetAsync(key, value);
        }
    }
}
