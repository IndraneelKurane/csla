﻿using Csla;
using Csla.DataPortalClient;
using System;

#if NUNIT
using NUnit.Framework;
using TestClass = NUnit.Framework.TestFixtureAttribute;
using TestInitialize = NUnit.Framework.SetUpAttribute;
using TestCleanup = NUnit.Framework.TearDownAttribute;
using TestMethod = NUnit.Framework.TestAttribute;
using TestSetup = NUnit.Framework.SetUpAttribute;
#elif MSTEST
using Microsoft.VisualStudio.TestTools.UnitTesting;
#endif

namespace Csla.Test.Utilities
{
  [TestClass]
  public class CoerseValueTests
  {
    [TestMethod]
    public void TestCoerseValue()
    {

      UtilitiesTestHelper helper = new UtilitiesTestHelper();

      helper.IntProperty = 0;
      helper.StringProperty = "1";
      helper.IntProperty = (int)Csla.Utilities.CoerceValue(typeof(int), typeof(string), null, helper.StringProperty);
      Assert.AreEqual(1, helper.IntProperty, "Should have converted to int");

      helper.IntProperty = 2;
      helper.StringProperty = "";
      helper.StringProperty = (string)Csla.Utilities.CoerceValue(typeof(string), typeof(int), null, helper.IntProperty);
      Assert.AreEqual("2", helper.StringProperty, "Should have converted to string");


      helper.StringProperty = "1";
      helper.NullableStringProperty = null;
      object convertedValue = Csla.Utilities.CoerceValue(typeof(string), typeof(string), null, helper.NullableStringProperty);
      Assert.IsNull(helper.NullableStringProperty);
      Assert.IsNull(convertedValue);

      Assert.AreEqual(UtilitiesTestHelper.ToStringValue, (string)Csla.Utilities.CoerceValue(typeof(string), typeof(UtilitiesTestHelper), null, helper), "Should have issued ToString()");
    }
  }
}