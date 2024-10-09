namespace OldPhonePad
{
    internal class OldPhonePadProcess
    {
        public static String OldPhonePad(string input)
        {
            string result = "";
            int currentNumberLength = 1;

            // Multi-dimensional array to hold string data for processing
            string[][] charData = new string[][]
            {
                new string[] { " " },
                new string[] { "&", "'", "(" },
                new string[] { "A", "B", "C" },
                new string[] { "D", "E", "F" },
                new string[] { "G", "H", "I" },
                new string[] { "J", "K", "L" },
                new string[] { "M", "N", "O" },
                new string[] { "P", "Q", "R", "S" },
                new string[] { "T", "U", "V" },
                new string[] { "W", "X", "Y", "Z" },
            };

            //Check the input is empty or null, and check "#" exists at the end of the input.
            if (!string.IsNullOrEmpty(input) && input.Length > 1 && input[input.Length - 1].ToString() == "#")
            {
                for (int i = 1; i < input.Length; i++)
                {
                    //Declare input as a string to use many times for processing and checking
                    string nextInputString = input[i].ToString();
                    string currentInputString = input[i - 1].ToString();

                    if (currentInputString == "#") //"#" means the end of the input
                    {
                        break;
                    }
                    else if (!(char.IsDigit(input[i - 1]) || currentInputString == "*" || currentInputString == "#" || currentInputString == " ")) //Input should only contain digits, '*', '#', and spaces
                    {
                        continue;
                    }
                    else if (nextInputString == "*" || currentInputString == "*") //"*" means backspace key
                    {
                        currentNumberLength = 1;
                        continue;
                    }
                    else if (currentInputString == " ") //Space means to consider for split same number 
                    {
                        currentNumberLength = 1;
                        continue;
                    }
                    else if (nextInputString == currentInputString) //If same number and not include space, must be keep count and going next
                    {
                        currentNumberLength++;
                    }
                    else //Process to return correct result
                    {
                        //if current input value is number, declare input as an integer to use many times for processing
                        int currentInputInt = int.Parse(currentInputString);

                        //Logic to search characters with an aligned number count and avoid cycle looping
                        int numberForChar = currentNumberLength % charData[currentInputInt].Length;
                        if (numberForChar == 0) //If remainder is 0, output must be last character in corresponding array as the logic
                        {
                            result += (charData[currentInputInt][charData[currentInputInt].Length - 1]);
                        }
                        else //If remainder is not 0, correct character must be exist in array[(remainder -1)] as the logic
                        {
                            result += charData[currentInputInt][numberForChar - 1];
                        }
                        currentNumberLength = 1; //Reset currentNumberLength for next number
                    }

                }
            }
            else //For something wrong input
            {
                Console.WriteLine("");
            }
            return result;
        }
    }
}
