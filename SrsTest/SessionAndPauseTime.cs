using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SrsTest
{
    public class SessionAndPauseTime : ISessionAndPauseTime
    {
        [JsonProperty("srsSession")]
        public ISrsSession? SrsSession { get; set; }
        [JsonProperty("pauseTime")]
        public TimeSpan? PauseTime { get; set; }
        public SessionAndPauseTime(SrsSession session)
        {
            SrsSession = session;
        }
    }
}
