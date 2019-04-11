using MineSweeperGame.DataAccess;
using MineSweeperGame.Exceptions;
using MineSweeperGame.Interfaces;
using System;
using System.Collections.Generic;

namespace MineSweeperLogic.BusinessLogic
{
    /// <summary>
    /// This class contains the logic of the game
    /// </summary>
    public class GameManager
    {
        /// <summary>
        /// Retrieves the field settings
        /// </summary>
        /// <returns></returns>
        public List<IFieldSettings> GetFieldSettings()
        {
            List<IFieldSettings> fields = new List<IFieldSettings>();
            fields = DBHelper.GetRecords();

            return fields;
        }

        /// <summary>
        /// populate the input field matrix according to the given settings
        /// </summary>
        /// <param name="fs"></param>
        /// <returns></returns>
        public char[,] PopulateMineField(IFieldSettings fs)
        {
            if (fs == null)
            {
                throw new NullMineFieldException("Invalid mine field");
            }

            if (fs.RowsNo < 0 || fs.RowsNo > 100)
            {
                throw new InvalidRowNumberException("Invalid rows number");
            }

            if (fs.ColumnsNo < 0 || fs.ColumnsNo > 100)
            {
                throw new InvalidColumnNumberException("Invalid columns number");
            }

            char[,] InputField = new char[fs.RowsNo, fs.ColumnsNo];
            // Fill the input field with safe spots
            for (int i = 0; i < fs.RowsNo; i++)
            {
                for (int j = 0; j < fs.ColumnsNo; j++)
                {
                    InputField[i, j] = '.';
                }
            }
            //insert the mines randomly
            InputField = PlaceRandomMines(fs, InputField);

            return InputField;
        }

        /// <summary>
        /// places the mines randomly inside the input field matrix
        /// </summary>
        /// <param name="fs"></param>
        /// <param name="InputField"></param>
        /// <returns></returns>
        private char[,] PlaceRandomMines(IFieldSettings fs, char[,] InputField)
        { 
            int randomRow, randomCol;
            int minesToPlace = fs.MinesNo;
            Random random = new Random();

            //place randomly the mines
            while (minesToPlace != 0)
            {
                randomRow = random.Next(0, fs.RowsNo);
                randomCol = random.Next(0, fs.ColumnsNo);
                //don't replace an existing mine
                if (InputField[randomRow, randomCol].Equals('*')) continue;
                InputField[randomRow, randomCol] = '*';
                minesToPlace--;
            }

            return InputField;
        }

        /// <summary>
        /// generates and returns the output field matrix starting from the input field
        /// </summary>
        /// <param name="fs"></param>
        /// <param name="inputField"></param>
        /// <returns></returns>
        public string[,] GenerateOutputField(IFieldSettings fs, char[,] inputField)
        {
            string[,] outputField = new string[fs.RowsNo, fs.ColumnsNo];

            for (int i = 0; i < fs.RowsNo; i++)
            {
                for (int j = 0; j < fs.ColumnsNo; j++)
                {
                    if (inputField[i, j].Equals('*'))
                    {
                        outputField[i, j] = "*";
                    }
                    else
                    {
                        outputField[i, j] = CalculateAdjacentMines(i, j, fs, inputField);
                    }
                }
            }
            return outputField;
        }

        // calculate the number of adjacent mines for each matrix element
        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="fs"></param>
        /// <param name="inputField"></param>
        /// <returns></returns>
        private string CalculateAdjacentMines(int x, int y, IFieldSettings fs, char[,] inputField)
        {
            int minX, minY, maxX, maxY;
            int result = 0;
            string res = "";

            // Don't check outside the edge of the field
            minX = (x <= 0 ? 0 : x - 1);
            minY = (y <= 0 ? 0 : y - 1);
            maxX = (x >= fs.RowsNo - 1 ? fs.RowsNo : x + 2);
            maxY = (y >= fs.ColumnsNo - 1 ? fs.ColumnsNo : y + 2);

            // Check all immediate neighbours for mines
            for (int i = minX; i < maxX; i++)
            {
                for (int j = minY; j < maxY; j++)
                {
                    if (inputField[i, j].Equals('*')) result++;
                }
            }
            res = result.ToString();
            return res;
        }
    }
}
