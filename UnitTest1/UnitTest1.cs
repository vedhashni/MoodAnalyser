using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using MoodAnalyser;


namespace UnitTest1
{
    [TestClass]
    public class UnitTest1
    {
        MoodAnalyse moodAnalyser;
        string message = " I am in happy Mood";
        
        [TestInitialize]
        public void SetUp()
        {
            moodAnalyser = new MoodAnalyse(message);
        }
        [TestMethod]
        public void TestMethodForHappyMood()

        {
            string expected = "happy";

            string actual = moodAnalyser.AnalyzeMood();
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestMethodForSadMood()

        {
            string expected = "sad";
            MoodAnalyse moodAnalyser = new MoodAnalyse("I am in sad Mood");
            string actual = moodAnalyser.AnalyzeMood();
            Assert.AreEqual(expected, actual);

        }
    }
}
