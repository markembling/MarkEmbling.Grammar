﻿using System.Collections.Generic;
using MarkEmbling.Utilities.Extensions;
using MarkEmbling.Utilities.Grammar.Rules;
using Xunit;

namespace MarkEmbling.Grammar.Tests {
    public class StringGrammarExtensionsTests {
        [Fact]
        public void PerformGrammarTransformation_transforms_with_given_rules() {
            const string input = "foo";
            var rules = new List<IGrammarTransformRule> {new TestRule()};
            var result = input.PerformGrammarTransformation(rules);
            Assert.Equal("bar", result);
        }

        [Fact]
        public void ToPlural_returns_plural_form_when_multiple() {
            const string singular = "item";
            var result = singular.ToPlural(2);
            Assert.Equal("items", result);
        }

        [Fact]
        public void ToPlural_returns_plural_form_when_zero() {
            const string singular = "item";
            var result = singular.ToPlural(0);
            Assert.Equal("items", result);
        }

        [Fact]
        public void ToPlural_returns_single_form_when_1() {
            const string singular = "item";
            var result = singular.ToPlural(1);
            Assert.Equal("item", result);
        }

        [Fact]
        public void ToPlural_returns_given_plural_form_when_multiple() {
            const string singular = "foo";
            var result = singular.ToPlural(2, "bar");
            Assert.Equal("bar", result);
        }

        [Fact]
        public void ToPlural_returns_single_form_when_single_and_plural_given() {
            const string singular = "foo";
            var result = singular.ToPlural(1, "bar");
            Assert.Equal("foo", result);
        }

        [Fact]
        public void ToPossessive_returns_possessive_form() {
            const string singular = "John";
            var result = singular.ToPossessive();
            Assert.Equal("John's", result);
        }
    }
}