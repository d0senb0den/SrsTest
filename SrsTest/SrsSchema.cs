using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SrsTest
{
    public class SrsSchema : ISrsSchema
    {
        [JsonProperty("shortcut")]
        public int ShortcutId { get; set; }

        public ISrsSession CurrentSession { get; }

        [JsonProperty("currentSessionIndex")]
        public int CurrentSessionIndex { get; set; }

        [JsonProperty("sessionsAndPauseTimes")]
        public IList<ISessionAndPauseTime> SessionsAndPauseTimes { get; set; }
        public int Id { get; set; }

        public SrsSchema(List<SessionAndPauseTime> sessionsAndPauseTimes)
        {
            SessionsAndPauseTimes = sessionsAndPauseTimes?.Select(s => (ISessionAndPauseTime)s).ToList();
        }
    }
}
