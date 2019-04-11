using MineSweeperGame.Interfaces;
using System;
using System.Collections.Generic;

namespace MineSweeperGame.BusinessLogic
{
    /// <summary>
    /// manages every output operations that has to be displayed
    /// </summary>
    public class OutputManager
    {
        /// <summary>
        /// prints the list of input fields
        /// </summary>
        /// <param name="fs"></param>
        /// <param name="inputField"></param>
        public void PrintInput(List<IFieldSettings> fs, List<char[,]> inputField)
        {
            Console.WriteLine("INPUT");
            for (int k = 0; k < inputField.Count; k++)
            {
                Console.WriteLine($"{fs[k].RowsNo} {fs[k].ColumnsNo}");
                for (int i = 0; i < fs[k].RowsNo; i++)
                {
                    for (int j = 0; j < fs[k].ColumnsNo; j++)
                    {
                        Console.Write(inputField[k][i, j]);
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
            }
        }
        /// <summary>
        /// prints the list of output fields
        /// </summary>
        /// <param name="fs"></param>
        /// <param name="outputField"></param>
        public void PrintOutput(List<IFieldSettings> fs, List<string[,]> outputField)
        {
            Console.WriteLine("OUTPUT");
            for (int k=0; k < fs.Count; k++)
            {
                Console.WriteLine($"Field #{fs[k].FieldId}:");
                for (int i = 0; i < fs[k].RowsNo; i++)
                {
                    for (int j = 0; j < fs[k].ColumnsNo; j++)
                    {
                        Console.Write(outputField[k][i, j]);                      
                    }
                    Console.WriteLine();   
                }
                Console.WriteLine();
            }
        }
    }
}
