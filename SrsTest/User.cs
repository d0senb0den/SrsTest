using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SrsTest
{
    internal class User
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("supportedPrograms")]
        public IList<ISupportedProgram> SupportedPrograms { get; set; }

        public User(List<SupportedProgram> supportedPrograms)
        {
            SupportedPrograms = supportedPrograms.Select(s => (ISupportedProgram)s).ToList();
        }
    }
}
