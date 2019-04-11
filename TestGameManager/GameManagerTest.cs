using Microsoft.VisualStudio.TestTools.UnitTesting;
using MineSweeperGame;
using MineSweeperGame.Exceptions;
using MineSweeperGame.Interfaces;
using MineSweeperLogic.BusinessLogic;

namespace TestGameManager
{
    [TestClass]
    public class GameManagerTest
    {
        [TestMethod]
        [ExpectedException(typeof(NullMineFieldException), "Invalid mine field")]
        public void Should_Throw_MineFieldException()
        {
            //arrange
            GameManager gameManager = new GameManager();
            IFieldSettings fs = null;

            //act
            gameManager.PopulateMineField(fs);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidRowNumberException), "Invalid rows number")]
        public void ShouldThrowInvalidRowNumberException_WhenRowsLessThanZero()
        {
            //arrange
            GameManager gameManager = new GameManager();
            IFieldSettings fs = new FieldSettings();
            fs.RowsNo = -1;

            //act
            gameManager.PopulateMineField(fs);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidRowNumberException), "Invalid rows number")]
        public void ShouldThrowInvalidRowNumberException_WhenRowsGreaterThanOneHundred()
        {
            //arrange
            GameManager gameManager = new GameManager();
            IFieldSettings fs = new FieldSettings();
            fs.RowsNo = 101;

            //act
            gameManager.PopulateMineField(fs);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidColumnNumberException), "Invalid columns number")]
        public void ShouldThrowInvalidRowNumberException_WhenColumnsLessThanZero()
        {
            //arrange
            GameManager gameManager = new GameManager();
            IFieldSettings fs = new FieldSettings();
            fs.ColumnsNo = -1;

            //act
            gameManager.PopulateMineField(fs);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidColumnNumberException), "Invalid columns number")]
        public void ShouldThrowInvalidRowNumberException_WhenColumnsGreaterThanOneHundred()
        {
            //arrange
            GameManager gameManager = new GameManager();
            IFieldSettings fs = new FieldSettings();
            fs.ColumnsNo = 101;

            //act
            gameManager.PopulateMineField(fs);
        }

        [TestMethod]
        public void ShouldReturnMineField()
        {
            //arrange
            GameManager gameManager = new GameManager();
            IFieldSettings fs = new FieldSettings();
            fs.RowsNo = 5;
            fs.ColumnsNo = 6;

            //act
            char[,] inputField = gameManager.PopulateMineField(fs);

            //assert
            Assert.IsNotNull(inputField);
        }

    }
}
