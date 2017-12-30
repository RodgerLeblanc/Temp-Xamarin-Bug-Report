using System;
using System.Collections.Generic;
using System.Text;

namespace Nevitium.Helpers.Services
{
    public interface IJsonService
    {
        T DeserializeFromFile<T>(T obj, string filename) where T : new();
        void SerializeToFile<T>(T obj, string filename);

    }
}
