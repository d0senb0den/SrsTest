using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SrsTest
{
    internal class SupportedProgram : ISupportedProgram
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("shortcuts")]
        public IList<ISrsTrainableShortcut> Shortcuts { get; set; }
        public SupportedProgram(List<SrsTrainableShortcut> shortcuts)
        {
            Shortcuts = shortcuts.Select(s => (ISrsTrainableShortcut)s).ToList();
        }
    }
}
