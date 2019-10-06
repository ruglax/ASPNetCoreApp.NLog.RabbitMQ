using Newtonsoft.Json;
using System;

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
        public string Level { get; set; }
    }
}