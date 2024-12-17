using Microsoft.Analytics.Interfaces;
using Microsoft.Analytics.Interfaces.Streaming;
using Microsoft.Analytics.Types.Sql;
using Microsoft.Analytics.UnitTest;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Logic;
using Themes;


namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {

        static int GetMaxZeroSequenceLength(string binaryString)
        {
            int maxLength = 0;
            int currentLength = 0;

            foreach (char c in binaryString)
            {
                if (c == '0') 
                {
                    currentLength++;

                    if (currentLength > maxLength)
                    {
                        maxLength = currentLength;
                    }
                }
                else
                {
                    
                    currentLength = 0;
                }
            }

            if (currentLength > maxLength)
            {
                maxLength = currentLength;
            }

            return maxLength;
        }



        [TestMethod]
        public void TestGetMaxZeroSequenceLength_WithMultipleSequences()
        {
            // Arrange
            string input = "10010000101000000";
            int expectedResult = 6;

            // Act
            int actualResult = GetMaxZeroSequenceLength(input);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void TestGetMaxZeroSequenceLength_WithNoZeros()
        {
            // Arrange
            string input = "1111111";
            int expectedResult = 0;

            // Act
            int actualResult = GetMaxZeroSequenceLength(input);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void TestGetMaxZeroSequenceLength_WithOnlyZeros()
        {
            // Arrange
            string input = "0000";
            int expectedResult = 4;

            // Act
            int actualResult = GetMaxZeroSequenceLength(input);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void TestGetMaxZeroSequenceLength_WithSingleZero()
        {
            // Arrange
            string input = "1_0_1";
            int expectedResult = 1;

            // Act
            int actualResult = GetMaxZeroSequenceLength(input.Replace("_", "")); // Удаляем символы подчеркивания

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void TestGetMaxZeroSequenceLength_EmptyString()
        {
            // Arrange
            string input = "";
            int expectedResult = 0;

            // Act
            int actualResult = GetMaxZeroSequenceLength(input);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }


        [TestMethod]
        public void TestMethod1()
        {
            
            string themes1 = "\"Статус работы\" \"Казарез Полина Андреевна\" \"Практическая работа\" 2023.10.02 \"В процессе\"";

            StatusOfWorks statusRES = (StatusOfWorks)StringManipulation.ObjectOutput(themes1);

            StatusOfWorks status = new StatusOfWorks()
            {
                Type = "Статус работы",
                StudentsName = "Казарез Полина Андреевна",
                TopicName = "Практическая работа",
                DateOfIssue = DateTime.Parse("2023.10.02")
            };

            ReferenceEquals(status, statusRES);

        }

        [TestMethod]
        public void ParseString_ShouldReturnCorrectArray_WhenInputValid()
        {
            // Arrange
            string input = "\"Тема работы\" \"Иванов Иван\" \"Моя работа\" \"2023.10.15\"";
            var expected = new string[] { "Тема работы", "Иванов Иван", "Моя работа", "2023.10.15" };

            // Act
            var result = StringManipulation.ParseString(input);

            // Assert
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void ParseFile_FileNotFound_ReturnsEmptyArray()
        {
            // Arrange
            
            string nonexistentFilePath = "C:\\Users\\polin\\source\\repos\\pis_pr3\\pis_pr3\\bin\\Debug\\blablabla.txt"; 

            // Act
            var result = StringManipulation.StrFromFiles(nonexistentFilePath);

            // Assert
            Assert.AreEqual(0, result.Length);
        }






    }
}
