using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace PrincessBrideTrivia.Tests
{
    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void LoadQuestions_RetrievesQuestionsFromFile()
        {
            string filePath = Path.GetRandomFileName();
            try
            {
                // Arrange
                GenerateQuestionsFile(filePath, 2);

                // Act
                Question[] questions = Program.LoadQuestions(filePath);

                // Assert 
                Assert.AreEqual(2, questions.Length);
            }
            finally
            {
                File.Delete(filePath);
            }
        }

        [TestMethod]
        [DataRow("1", true)]
        [DataRow("2", false)]
        public void DisplayResult_ReturnsTrueIfCorrect(string userGuess, bool expectedResult)
        {
            // Arrange
            Question question = new Question();
            question.CorrectAnswerIndex = "1";

            // Act
            bool displayResult = Program.DisplayResult(userGuess, question);

            // Assert
            Assert.AreEqual(expectedResult, displayResult);
        }

        [TestMethod]
        public void GetFilePath_ReturnsFileThatExists()
        {
            // Arrange

            // Act
            string filePath = Program.GetFilePath();

            // Assert
            Assert.IsTrue(File.Exists(filePath));
        }

        [TestMethod]
        [DataRow(1, 1, "100%")]
        [DataRow(5, 10, "50%")]
        [DataRow(1, 10, "10%")]
        [DataRow(0, 10, "0%")]
        public void GetPercentCorrect_ReturnsExpectedPercentage(int numberOfCorrectGuesses, 
            int numberOfQuestions, string expectedString)
        {
            // Arrange

            // Act
            string percentage = Program.GetPercentCorrect(numberOfCorrectGuesses, numberOfQuestions);

            // Assert
            Assert.AreEqual(expectedString, percentage);
        }


        private static void GenerateQuestionsFile(string filePath, int numberOfQuestions)
        {
            for (int i = 0; i < numberOfQuestions; i++)
            {
                string[] lines = new string[5];
                lines[0] = "Question " + i + " this is the question text";
                lines[1] = "Answer 1";
                lines[2] = "Answer 2";
                lines[3] = "Answer 3";
                lines[4] = "2";
                File.AppendAllLines(filePath, lines);
            }
        }

        [TestMethod]
        [DataRow(3)]
        [DataRow(5)]
        [DataRow(10)]
        [DataRow(13)]
        public void GetShuffledIndexes_ReturnsDifferentIndexes(int maxValue)
        {
            int[] indexesToShuffle = Program.GetRandomIndexes(maxValue);

            Assert.AreNotEqual(indexesToShuffle[0], indexesToShuffle[1]);

            Assert.IsTrue(indexesToShuffle[0] < maxValue && indexesToShuffle[1] < maxValue);
        }

        [TestMethod]
        [DataRow(3)]
        [DataRow(4)]
        [DataRow(7)]
        [DataRow(9)]
        public void ShuffleQuestions_ReturnsShuffledArray(int maxValue)
        {
            string filePath = Path.GetRandomFileName();
            try
            {
                GenerateQuestionsFile(filePath, maxValue);

                Question[] questions = Program.LoadQuestions(filePath);
                Question[] shuffledQuestions = Program.LoadQuestions(filePath);
                Program.ShuffleQuestions(shuffledQuestions);

                bool shuffled = false;
                for (int i = 0; i < questions.Length; i++)
                {
                    if (questions[i].Text != shuffledQuestions[i].Text)
                        shuffled = true;
                }
                Assert.IsTrue(shuffled);
            }
            finally
            {
                File.Delete(filePath);
            }
        }
    }
}
