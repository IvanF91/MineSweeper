using MineSweeperGame.Interfaces;
using System;
using System.Collections.Generic;

namespace MineSweeperGame.BusinessLogic
{
    // manage every output operations that has to be displayed
    public class OutputManager
    {
        // print the list of input fields
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

        //print the list of output fields
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
