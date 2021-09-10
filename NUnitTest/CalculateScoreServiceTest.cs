using MyNUnitDemo.Services;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace NUnitTest
{
    class CalculateScoreServiceTest
    {
        [SetUp]
        public void SetUp()
        {

        }

        // given-whe-then
        [Test]
        public void Score77_Execute_True()
        {
            var calc = new CalculateScoreService();
            var res = calc.Execute("77");

            //check unit 
            Assert.True(res);
        }

        [Test]
        public void Score50_Execute_True()
        {
            var calc = new CalculateScoreService();
            var res = calc.Execute("50");

            //check unit 
            Assert.True(res);
        }

        [Test]
        public void Score22_Execute_False()
        {
            var calc = new CalculateScoreService();
            var res = calc.Execute("22");

            //check unit 
            Assert.False(res);
        }

        [Test]
        public void ScoreXXX_Execute_ThrowException()
        {
            var expected = "Error! Please input number.";
            var calc = new CalculateScoreService();
            // var res = calc.Execute("xxx");

            var res = Assert.Throws<Exception>(() => calc.Execute("xxx"));

            //check unit 
            Assert.AreEqual(expected, res.Message);
        }


        [Test]
        public void ScoreNull_Execute_ThrowException()
        {
            var expected = "Error! Please input number.";
            var calc = new CalculateScoreService();
            // var res = calc.Execute("xxx");

            var res = Assert.Throws<Exception>(() => calc.Execute(null));

            //check unit 
            Assert.AreEqual(expected, res.Message);
        }

        [Test]
        public void Score500Point25_Execute_ThrowException()
        {
            var expected = "Error! Please input number.";
            var calc = new CalculateScoreService();
            // var res = calc.Execute("xxx");

            var res = Assert.Throws<Exception>(() => calc.Execute("500.25"));

            //check unit 
            Assert.AreEqual(expected, res.Message);
        }

        [TearDown]
        public void TearDown()
        {

        }
    }
}
