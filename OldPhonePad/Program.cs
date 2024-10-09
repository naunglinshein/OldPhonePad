using OldPhonePad;

namespace YourProjectName
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the OldPhonePad Method!");
            while (true)
            {
                Console.WriteLine("Enter input or type 'exit' to quit:");
                string input = Console.ReadLine();

                // Check if the user wants to exit
                if (input.ToLower() == "exit")
                {
                    break;
                }
                // Call OldPhonePad method and display the output
                string result = OldPhonePadProcess.OldPhonePad(input);
                Console.WriteLine("Result: " + result);
            }
        }
    }
}
