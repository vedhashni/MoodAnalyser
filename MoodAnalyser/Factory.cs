using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Reflection;

namespace MoodAnalyser
{
    class Factory
    {
        public object CreateMoodAnalyserObject(string className, string constructor)
        {
            string p = @"." + constructor + "$";
            Match result = Regex.Match(className, p);
            if (result.Success)
            {
                try
                {
                    Assembly assembly = Assembly.GetExecutingAssembly();
                    Type moodAnalyserType = assembly.GetType(className);
                    var res = Activator.CreateInstance(moodAnalyserType);
                    return res;
                }
                catch (Exception)
                {
                    throw new CustomException(CustomException.ExceptionType.CLASS_NOT_FOUND, "Class not found");
                }
            }
            else
            {
                throw new CustomException(CustomException.ExceptionType.CONSTRUCTOR_NOT_FOUND, "Constructor not found");
            }
        }

        public object CreateMoodAnalyserParameterizedObject(string className, string constructor, string message)
        {
            try
            {
                Type type = typeof(MoodAnalyse);
                if (type.Name.Equals(className) || type.FullName.Equals(className))
                {
                    if (type.Name.Equals(constructor))
                    {
                        ConstructorInfo constructorInfo = type.GetConstructor(new[] { typeof(string) });
                        var obj = constructorInfo.Invoke(new object[] { message });
                        return obj;
                    }
                    else
                    {
                        throw new CustomException(CustomException.ExceptionType.CONSTRUCTOR_NOT_FOUND, "Constructor not found");

                    }

                }
            }
            catch (Exception)
            {
                throw new CustomException(CustomException.ExceptionType.CLASS_NOT_FOUND, "Class not found");

            }
            return default;
        }

        public string InvokeAnalyserMethod(string message, string methodName)
        {
            try
            {
                Type type = typeof(MoodAnalyse);

                MethodInfo methodInfo = type.GetMethod(methodName);
                Factory factory = new Factory();
                object moodAnalyserObject = factory.CreateMoodAnalyserParameterizedObject("MoodAnalyserProblem2.MoodAnalyser", "MoodAnalyser", message);
                object info = methodInfo.Invoke(moodAnalyserObject, null);
                return info.ToString();
            }
            catch (NullReferenceException)
            {
                throw new CustomException(CustomException.ExceptionType.METHOD_NOT_FOUND, "Method not found");
            }
        }

        public string SetField(string message, string fieldName)
        {
            try
            {
                MoodAnalyse moodAnalyser = new MoodAnalyse();
                Type type = typeof(MoodAnalyse);
                FieldInfo fieldInfo = type.GetField(fieldName, BindingFlags.Public | BindingFlags.Instance);
                if (message == null)
                {
                    throw new CustomException(CustomException.ExceptionType.EMPTY_MESSAGE, "Message should not be null");
                }
                fieldInfo.SetValue(moodAnalyser, message);
                return moodAnalyser.message;
            }
            catch (NullReferenceException)
            {
                throw new CustomException(CustomException.ExceptionType.NO_SUCH_FIELD, "Feild is not found");
            }
        }

    }
}
