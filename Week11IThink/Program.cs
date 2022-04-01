using System;
using System.Text.RegularExpressions;
using System.IO;


public class Test
{

    //[STUDENT NOTE] my files uses the \ instead of the / in the assignment page, so it might have problems on someone else's computer, sorry.

    // in your lecture videos you also use the \ instead of the / for your examples. also trying to check a .exe file might cause the program to crash


    public static void Main()
    {
       
        var FileChecker = new Regex(@"^[A-Za-z0-9]+(:\\)+((.+)+(.txt))"); //used to check if user's input is a valid file location

        //string file = (@"C:\Users\komkr\Documents\Serious s\ExampleBongo.txt");   //example 1
        //string file = (@"C:\Users\komkr\Documents\Coco Games\BlasterMaster.txt"); //example 2
        //string file = (@"C:\Users\komkr\Documents\dualtail\SeriousExample.txt");  //example 3
      
        Console.Write("Please enter a file path: ");

        string file = @"" + Console.ReadLine(); //convert user's inputted string into a readable file name


        if (FileChecker.IsMatch(file)) //check if file is valid
        {
            Console.WriteLine("File path is valid"); //notify the user that the input was validated

            try
            {
                int counter = 0; //count each word in the file

                int count = 1; //count each word in each string in the text file

                int len = 0; //used to go through each word in the string in the text file

              

                StreamReader sr = new StreamReader(file);   // try and read file
                
                string line;                                //hold each line in the text file as string

                Console.WriteLine("Opening the file...\n"); //notify the user that the program is opening the file

                do // do until line is null
                {

                    line = sr.ReadLine(); //get a line from the text file
                    
                    Console.WriteLine(line); //output to user

                    if (line == null || line == "") //if line is null, skip to prevent crashing, if line is empty, skip to prevent faulty data due to an empty string
                    {
                        
                        //Console.WriteLine("null or empty"); //skip to prevent null error or false data due to empty string
                    }
                    else
                    {
                        //Console.WriteLine("go"); //[Debug] check if line is recieved
                        
                        while (len <= line.Length - 1)
                        {
                            if (line[len] == ' ' || line[len] == '\n' || line[len] == '\t')
                            {
                                count++;
                            }
                            len++;
                        }

                        len = 0; //reset for next string called by StreamReader
                        counter += count; //add word count to total word count , be sure to prevent a empty string from being used or else counter will go up by 1 without needing to
                        count = 1; //reset for next string after adding to total counter
                        
                        //Console.WriteLine("counter:" + counter); //[debug] check if counter is adding the total word count correctly after each string
                    }
                    

                } while (line != null); //loop until line is null

                Console.WriteLine("Closing the file..."); //notify the user that the program has finished reading the text file
                Console.WriteLine("There are " + counter + " words in this file"); //output total word count to user
            }
            
            catch (Exception e)
            {
                Console.WriteLine("Unfortunately, that file does not exist"); //output to user that the text file does not exist.
            }


            
        }
        else
        {
            Console.WriteLine("Not a valid file "); //output to user that the input was not valid for being checked as a file.
        }
        
    }
}
