﻿// Copyright (c) André N. Klingsheim. See License.txt in the project root for license information.

using System;
using NWebsec.AspNetCore.Core.Extensions;
using NWebsec.AspNetCore.Core.HttpHeaders;
using NWebsec.AspNetCore.Core.Tests.TestHelpers;
using Xunit;

namespace NWebsec.AspNetCore.Core.Tests.Extensions
{
    public class ReferrerPolicyExtensionsTests
    {
        [Theory]
        [InlineData(ReferrerPolicy.Disabled)]
        [InlineData(Int32.MaxValue)]
        public void GetPolicyString_InvalidPolicy_Throws(ReferrerPolicy policy)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => policy.GetPolicyString());
        }

        [Theory]
        [ClassData(typeof(ReferrerPolicyStringsData))]

        public void GetPolicyString_ValidPolicy_ReturnsPolicyString(ReferrerPolicy policy, string expectedPolicy)
        {
            var result = policy.GetPolicyString();

            Assert.Equal(expectedPolicy, result);
        }
    }
}

