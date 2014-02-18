﻿// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

using System;
using Xunit;

namespace Microsoft.Data.Entity.Metadata
{
    public class AnnotationTest
    {
        [Fact]
        public void MembersCheckArguments()
        {
            Assert.Equal(
                Strings.ArgumentIsEmpty("name"),
                Assert.Throws<ArgumentException>(() => new Annotation("", "Kake")).Message);

            Assert.Equal(
                Strings.ArgumentIsEmpty("value"),
                Assert.Throws<ArgumentException>(() => new Annotation("Lie", "")).Message);
        }

        [Fact]
        public void CanCreateAnnotation()
        {
            var annotation = new Annotation("Foo", "Bar");

            Assert.Equal("Foo", annotation.Name);
            Assert.Equal("Bar", annotation.Value);
        }
    }
}
