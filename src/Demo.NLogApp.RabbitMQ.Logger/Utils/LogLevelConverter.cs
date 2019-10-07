using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;

namespace Demo.NLogApp.RabbitMQ.Logger.Utils
{
    class LogLevelConverter : JsonConverter
    {
        public override bool CanRead
        {
            get { return true; }
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(LogLevel);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            string level = reader.Value.ToString().ToUpper();
            switch (level)
            {
                case "TRACE":
                    level = "Trace";
                    break;
                case "DEBUG":
                    level = "Debug";
                    break;
                case "INFO":
                    level = "Information";
                    break;
                case "WARN":
                    level = "Warning";
                    break;
                case "ERROR":
                    level = "Error";
                    break;
                case "CRITICAL":
                    level = "Critical";
                    break;
                default:
                    break;
            }
            
            Enum.TryParse<LogLevel>(level, out var levelOut);
            return levelOut;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
