namespace Calculator;

class Program
{
    static void Main(string[] args)
    {   
        #nullable disable
        string operation = "";
        int counter;
        bool run = true;
        
        PrintWelcomeMessage();  

        while (run)
        {
            operation = GetOperation();
            counter = int.Parse(GetCounter(operation));
            GetNumbers(counter, operation);  
        }
    }

    private static void PrintWelcomeMessage()
    {
        Console.WriteLine("");
        Console.WriteLine("Welcome to the calculator!");
        Console.WriteLine("==========================");
        Console.WriteLine("");
    }

    private static string GetOperation(){
        bool displayMenu = true;
        string operation = "";
        while (displayMenu)
        {
            Console.Write("Please enter a valid operator: ");
            operation = Console.ReadLine();
            CheckExitProgram(operation);
            if(operation == "+" || operation == "-" || operation == "*" || operation == "/"){
                displayMenu = false;
            }
        }
        return operation;
    }    

    private static string GetCounter(string operation){
        Console.Write("How many numbers do you want to {0}? ", operation);
        string userInput = Console.ReadLine();
        CheckExitProgram(userInput); 
        return userInput;
    }    

    private static void GetNumbers(int counter, string operation){
        
        int[] numbersArray = new int[counter];

        for (int i = 0; i < numbersArray.Length; i++)
        {   
            Console.Write("Please enter number {0}? ", i + 1);
            numbersArray[i] = int.Parse(Console.ReadLine());
        }

        PerformCalculations(numbersArray, operation);
    }

    private static void PerformCalculations(int[] numbersArray, string operation){
        double sumNumbers = 0;
        
        if (operation == "*"){
            sumNumbers = 1;
        }

        for (int i = 0; i < numbersArray.Length; i++)
        {   
            if(operation == "+"){
                    sumNumbers += numbersArray[i];
                } else if(operation == "-"){
                    if(i == 0){
                        sumNumbers =  numbersArray[i];
                    } else {
                        sumNumbers -= numbersArray[i];
                    }
                } else if(operation == "*"){
                    sumNumbers *= numbersArray[i];
                } else if(operation == "/"){
                    if(i == 0){
                        sumNumbers = numbersArray[i];
                    } else {
                        sumNumbers /= numbersArray[i];
                    }
                }           
        }
        Console.WriteLine("The answer is {0}", sumNumbers);
    } 

    private static void CheckExitProgram(string operation){
        if(operation == "E"){
            Environment.Exit(0);
        }
    }
}