using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Assistant.Services
{
    public interface ISettingsService
    {
        Task Set<T>(string key, T value);
        Task<T> Get<T>(string key, T defaultValue);
    }
    internal class SettingsService : ISettingsService
    {
        public Task<T> Get<T>(string key, T defaultValue)
        {
            var data = Preferences.Default.Get<string>(key, null);
            if (data == null) return Task.FromResult(defaultValue);

            T value = JsonSerializer.Deserialize<T>(data);

            return Task.FromResult(value);
        }

        public Task Set<T>(string key, T value)
        {
            var data = JsonSerializer.Serialize<T>(value);
            Preferences.Default.Set<string>(key, data);
            return Task.CompletedTask;
        }
    }
}
