using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SrsTest
{
    public class SrsTrainableShortcut : ISrsTrainableShortcut
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("isMastered")]
        public bool IsMastered { get; set; }
        [JsonProperty("hasBeenUsed")]
        public bool HasBeenUsed { get; set; }
        [JsonProperty("deckIndex")]
        public int DeckIndex { get; set; }
        [JsonProperty("difficultyLevel")]
        public string DifficultyLevel { get; set; }
        [JsonProperty("srsSchema")]
        public ISrsSchema SrsSchema { get; set; }
        public int SupportedProgramId { get; set; }
        public SrsTrainableShortcut(SrsSchema srsSchema)
        {
            SrsSchema = srsSchema;
        }

        
    }
}
