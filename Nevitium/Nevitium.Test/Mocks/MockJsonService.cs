using Nevitium.Helpers.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nevitium.Test.Mocks
{
    class MockJsonService : IJsonService
    {
        public T DeserializeFromFile<T>(T obj, string filename) where T : new()
        {
            return new T();
        }

        public void SerializeToFile<T>(T obj, string filename)
        {
            
        }
    }
}
