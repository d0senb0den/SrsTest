using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SrsTest
{
    public class SrsTrainableShortcutBuilder
    {
        private ISrsTrainableShortcut shortcut;

        public SrsTrainableShortcutBuilder Create()
        {
            shortcut = new SrsTrainableShortcut(new SrsSchema(new List<SessionAndPauseTime>()));
            return this;
        }

        public SrsTrainableShortcutBuilder SpecifyIsMastered(bool mastered)
        {
            shortcut.IsMastered = mastered;
            return this;
        }

        public SrsTrainableShortcutBuilder SpecifyHasBeenUsed(bool used)
        {
            shortcut.HasBeenUsed = used;
            return this;
        }

        public SrsTrainableShortcutBuilder SpecifyDeckIndex(int index)
        {
            shortcut.DeckIndex = index;
            return this;
        }
        public SrsTrainableShortcutBuilder SpecifyDifficultyLevel(string level)
        {
            shortcut.DifficultyLevel = level;
            return this;
        }
        public ISrsTrainableShortcut Build()
        {
            return shortcut;
        }

        public SrsTrainableShortcutBuilder SpecifyId(int id)
        {
            shortcut.Id = id;
            shortcut.SrsSchema.ShortcutId = shortcut.Id;
            return this;
        }
    }
}
