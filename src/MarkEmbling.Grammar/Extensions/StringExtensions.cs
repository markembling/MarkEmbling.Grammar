﻿using MarkEmbling.Grammar.Rules;
using System.Collections.Generic;

namespace MarkEmbling.Grammar.Extensions {
    public static class StringExtensions {
        /// <summary>
        /// Apply the given grammar rules to the input string
        /// </summary>
        /// <param name="str">Current string instance</param>
        /// <param name="rules">Rules to apply</param>
        public static string PerformGrammarTransformation(this string str, IEnumerable<IGrammarTransformRule> rules) {
            var transformer = new GrammarTransformer(rules);
            return transformer.Transform(str);
        }

        /// <summary>
        /// Apply default (naive English) pluralisation rules based on count
        /// </summary>
        /// <param name="str">Current string instance</param>
        /// <param name="count">Number to apply pluralisation rules against</param>
        public static string ToPlural(this string str, int count) {
            return count == 1 ?
                str :
                PerformGrammarTransformation(str, DefaultRuleSets.Plural);
        }

        /// <summary>
        /// Return either the single form (the current string) or the given plural form,
        /// based on the provided count.
        /// </summary>
        /// <param name="str">Current string instance</param>
        /// <param name="count">Number to apply pluralisation rules against</param>
        /// <param name="multipleForm">Alternate plural form of the word</param>
        public static string ToPlural(this string str, int count, string multipleForm) {
            return count == 1 ? str : multipleForm;
        }

        /// <summary>
        /// Apply default (naive English) possession rules
        /// </summary>
        /// <param name="str">Current string instance</param>
        public static string ToPossessive(this string str) {
            return PerformGrammarTransformation(str, DefaultRuleSets.Possessive);
        }
    }
}