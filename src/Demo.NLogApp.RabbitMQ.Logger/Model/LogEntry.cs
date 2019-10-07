using Demo.NLogApp.RabbitMQ.Logger.Utils;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Demo.NLogApp.RabbitMQ.Logger.Model
{
    public class LogEntry
    {
        [JsonProperty("@source")]
        public string Source { get; set; }

        [JsonProperty("@timestamp")]
        public DateTime Timestamp { get; set; }

        [JsonProperty("@message")]
        public string Message { get; set; }

        [JsonProperty("level")]
        //[JsonConverter(typeof(LogLevelConverter))]
        public Microsoft.Extensions.Logging.LogLevel Level { get; set; }
    }
}