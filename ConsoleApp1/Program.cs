using MineSweeperGame.BusinessLogic;
using MineSweeperGame.Exceptions;
using MineSweeperGame.Interfaces;
using MineSweeperLogic.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;


namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {                             
                GameManager gameManager = new GameManager();
                OutputManager outputManager = new OutputManager();              
                List<IFieldSettings> fields = gameManager.GetFieldSettings();
                List<char[,]> inputFields = new List<char[,]>();
                List<string[,]> outputFields = new List<string[,]>();

                // scan every element of the setting list and add the fields inside the input and output fields lists
                foreach (IFieldSettings fs in fields)
                {
                    //add an input field inside the input fields list
                    inputFields.Add(gameManager.PopulateMineField(fs));
                    //add an output field inside the output field list
                    outputFields.Add(gameManager.GenerateOutputField(fs, inputFields.Last()));               
                }
                // print the input and output lists
                outputManager.PrintInput(fields, inputFields);
                outputManager.PrintOutput(fields, outputFields);
                Console.ReadKey();
            }
            catch (GameException gEx)
            {
                Console.WriteLine($"Managed exception occurred: {gEx.Message}");

                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Unmanaged exception occurred: {e.Message}");

                Console.ReadKey();
            }
        }
        
    }
}

