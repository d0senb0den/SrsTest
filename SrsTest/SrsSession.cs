using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SrsTest
{
    public class SrsSession : ISrsSession
    {
        [JsonProperty("currentRepCount")]
        public int CurrentRepCount { get; set; }
        [JsonProperty("deadLine")]
        public DateTime? DeadLine { get; set; }
        [JsonProperty("endedTime")]
        public DateTime? EndedTime { get; set; }
        [JsonProperty("goalRepCount")]
        public int GoalRepCount { get; set; }
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("scheduledDateTime")]
        public DateTime? ScheduledDateTime { get; set; }
        [JsonProperty("state")]
        public string? State { get; set; }
        [JsonProperty("maxDuration")]
        public TimeSpan? MaxDuration { get; set; }
    }
}
