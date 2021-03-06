using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using MoodAnalyser;


namespace UnitTest1
{
    [TestClass]
    public class UnitTest1
    {
        //MoodAnalyse moodAnalyser;
        //string message = " I am in happy Mood";

        [TestInitialize]
        public void SetUp()
        {
            //moodAnalyser = new MoodAnalyse(message);
        }
        [TestMethod]
        public void TestMethodForHappyMood()

        {
            string expected = "happy";
            MoodAnalyser moodAnalyser = new MoodAnalyser("I am in happy Mood");
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

        [TestMethod]
        public void TestMethodForNullMood()

        {
            string expected = "happy";
            MoodAnalyse moodAnalyser = new MoodAnalyse("I am in happy Mood");
            string actual = moodAnalyser.AnalyzeMood();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethodForCustomizedNullException()

        {
            string expected = "Mood should not be null";
            try
            {

                MoodAnalyse moodAnalyser = new MoodAnalyse(null);
                moodAnalyser.AnalyzeMood();
            }
            catch (CustomException ex)
            {
                Assert.AreEqual(expected, ex.Message);
            }
        }
        [TestMethod]
        public void TestMethodForCustomizedEmptyException()

        {
            string expected = "Mood should not be empty";
            try
            {

                MoodAnalyse moodAnalyser = new MoodAnalyse(string.Empty);
                moodAnalyser.AnalyzeMood();
            }
            catch (CustomException ex)
            {
                Assert.AreEqual(expected, ex.Message);
            }
        }
        [TestMethod]
        public void Reflection_Return_Default_Constructor()
        {
            MoodAnalyse expected = new MoodAnalyse();
            object obj = null;
            try
            {
                Factory factory = new Factory();
                obj = factory.CreateMoodAnalyserObject("MoodAnalyserProblem2.MoodAnalyser", "MoodAnalyser");

            }
            catch (CustomException ex)
            {
                throw new System.Exception(ex.Message);
            }
        }
        //Neagtive Case
        [TestMethod]
        public void Reflection_Return_Default_Constructor_No_Class_Found()
        {
            string expected = "Class not found";
            object obj = null;
            try
            {
                Factory factory = new Factory();
                obj = factory.CreateMoodAnalyserObject("MoodAnalyserProblem2.MoodAnaly", "MoodAnaly");

            }
            catch (CustomException actual)
            {
                Assert.AreEqual(expected, actual.Message);
            }
        }
        //Neagtive Case
        [TestMethod]
        public void Reflection_Return_Default_Constructor_No_Constructor_Found()
        {
            string expected = "Constructor not found";
            object obj = null;
            try
            {
                Factory factory = new Factory();
                obj = factory.CreateMoodAnalyserObject("MoodAnalyserProblem2.MoodAnalyser", "MoodAnaly");

            }
            catch (CustomException actual)
            {
                Assert.AreEqual(expected, actual.Message);
            }
        }

        [TestMethod]
        public void Reflection_Return_Parameterized_Constructor()
        {
            string message = "I am in happy mood";
            MoodAnalyse expected = new MoodAnalyse(message);
            object actual = null;
            try
            {
                Factory factory = new Factory();
                actual = factory.CreateMoodAnalyserParameterizedObject("MoodAnalyserProblem2.MoodAnalyser", "MoodAnalyser", message);

            }
            catch (CustomException ex)
            {
                throw new System.Exception(ex.Message);
            }
            actual.Equals(expected);
        }
        //Invalid case
        [TestMethod]
        public void Reflection_Return_Parameterized_Class_Invalid()
        {
            string message = "I am in happy mood";
            MoodAnalyse expected = new MoodAnalyse(message);
            object actual = null;
            try
            {
                Factory factory = new Factory();
                actual = factory.CreateMoodAnalyserParameterizedObject("MoodAnalyserProblem2.MoodAna", "MoodAnalyser", message);

            }
            catch (CustomException actual1)
            {
                Assert.AreEqual(expected, actual1.Message);
            }
        }
        [TestMethod]
        public void Reflection_Return_Method()
        {
            string expected = "happy";
            Factory factory = new Factory();
            string actual = factory.InvokeAnalyserMethod("happy", "AnalyzeMood");
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Reflection_Return_Invalid_Method()
        {
            string expected = "happy";
            Factory factory = new Factory();
            string actual = factory.InvokeAnalyserMethod("happy", "Analyze");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Reflection_Return_Set_Feild_Happy_Message()
        {
            string expected = "happy";
            Factory factory = new Factory();
            string actual = factory.SetField("happy", "message");
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Reflection_Return_Set_Feild_Sad_Message()
        {
            string expected = "sad";
            Factory factory = new Factory();
            string actual = factory.SetField("sad", "message");
            Assert.AreEqual(expected, actual);
        }
    }
}
