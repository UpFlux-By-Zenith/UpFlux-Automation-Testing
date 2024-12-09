using System.Collections.Generic;

namespace UpFluxAutomation.Helpers
{
    public class MemoryRepository
    {
        private readonly Dictionary<string, object> _data = new();

        public void Add(string key, object value)
        {
            _data[key] = value;
        }

        public T Get<T>(string key)
        {
            if (_data.TryGetValue(key, out var value))
            {
                return (T)value;
            }

            throw new KeyNotFoundException($"The key '{key}' was not found in the repository.");
        }
    }
}
