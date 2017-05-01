using System.Collections.Generic;
using System.Linq;

namespace MarkEmbling.Grammar.Rules {
    /// <summary>
    /// Basic rule which ensures uncountable words do not get swapped or modified.
    /// </summary>
    public class PluralUncountableCasesRule : IGrammarTransformRule {
        private readonly string[] _uncountables = new [] {
            "deer",
            "sheep"
        };

        public bool CanTransform(string input) {
            return _uncountables.Contains(input.ToLowerInvariant());
        }

        public string Transform(string input) {
            return input;
        }
    }
}