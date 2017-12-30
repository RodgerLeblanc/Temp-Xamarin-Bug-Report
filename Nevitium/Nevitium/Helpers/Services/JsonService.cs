using Nevitium.Helpers;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using Xamarin.Forms;

namespace Nevitium.Helpers.Services
{
    public class JsonService : IJsonService
    {

        public void SerializeToFile<T>(T obj, string filename)
        {
            //string output = JsonConvert.SerializeObject(this);
            JsonSerializer serializer = new JsonSerializer();

            serializer.Converters.Add(new JavaScriptDateTimeConverter());
            serializer.NullValueHandling = NullValueHandling.Include;
            serializer.ReferenceLoopHandling = ReferenceLoopHandling.Serialize;
            //serializer.TypeNameHandling = TypeNameHandling.Auto;

            using (StreamWriter sw = new StreamWriter(DependencyService.Get<IFileHelper>().GetLocalFilePath(filename)))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, obj);
            }
        }

        public T DeserializeFromFile<T>(T obj, string filename) where T : new()
        {
            if (File.Exists(DependencyService.Get<IFileHelper>().GetLocalFilePath(filename)) == false)
            {                               
                return new T();
            }
            /*
            if (JsonConvert.DefaultSettings == null)
            {
                JsonConvert.DefaultSettings = () => new JsonSerializerSettings() ;
                
            }
            JsonConvert.DefaultSettings().TypeNameHandling = TypeNameHandling.Auto;*/
            var o = (T)JsonConvert.DeserializeObject<T>(File.ReadAllText(DependencyService.Get<IFileHelper>().GetLocalFilePath(filename)));
            
            return o;
        }

    }

    public class ConcreteTypeConverter<TConcrete> : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            //assume we can convert to anything for now
            return true;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            //explicitly specify the concrete type we want to create
            return serializer.Deserialize<TConcrete>(reader);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            //use the default serialization - it works fine
            serializer.Serialize(writer, value);
        }
    }
}
