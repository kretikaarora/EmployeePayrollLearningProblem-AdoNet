// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NunitTestProject.cs" company="Capgemini">
//   Copyright
// </copyright>
// <creator Name="Kretika Arora"/>
// --------------------------------------------------------------------------------------------------------------------

using NUnit.Framework;

namespace NUnitTestProject
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}