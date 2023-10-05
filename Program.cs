using System.Runtime.CompilerServices;

namespace Calculator;

class Program
{
    static void Main(string[] args)
    {   
        #nullable disable
        string operation = "";
        DateTime date;
        DateTime endDate;
        int daysToAdd;
        int counter;
        bool run = true;
        
        PrintWelcomeMessage();  

        while (run)
        {
            if(GetMode(0) == 1){
                operation = GetOperation();
                counter = int.Parse(GetCounter(operation));
                GetNumbers(counter, operation);                 
            } else {
                date = GetDate();  
                daysToAdd = GetDaysToAdd();
                endDate = CalculateDate(date, daysToAdd);
                DisplayDate(endDate);
            }
             
        }
    }

    private static void PrintWelcomeMessage()
    {
        Console.WriteLine("");
        Console.WriteLine("Welcome to the calculator!");
        Console.WriteLine("==========================");
        Console.WriteLine("");
    }

    private static int GetMode(int num){
        bool displayMessage = true;
        string userInput = "";

        while (displayMessage)
        {
            Console.WriteLine("Please choose a calculator mode?");
            Console.WriteLine("1 = Numbers");
            Console.WriteLine("2 = Dates");
            userInput = Console.ReadLine();
            CheckExitProgram(userInput);
            if(CheckNumber(0, userInput) > 0 & CheckNumber(0, userInput) < 3) displayMessage = false;
        }
        return int.Parse(userInput);
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
            Console.Clear();
        }
        return operation;
    }    

    private static string GetCounter(string operation){
        bool displayMessage = true;
        string userInput = "";
        bool valid = true;
        
        while (displayMessage)
        {
            Console.Write("How many numbers do you want to {0}? ", operation);
            userInput = Console.ReadLine();
            if(CheckNumber(0, userInput) > 0) displayMessage = false; 
            CheckExitProgram(userInput); 
            Console.Clear();    
        } 
        return userInput;  
    }    

    private static void GetNumbers(int counter, string operation){
        string userInput = "";
        bool valid = true; 
        int[] numbersArray = new int[counter];

        for (int i = 0; i < numbersArray.Length; i++)
        {   
            bool displayMessage = true;
            while (displayMessage)
            {
                int number;
                Console.Write("Please enter number {0}? ", i + 1);
                userInput = Console.ReadLine();
                if(CheckNumber(0, userInput) > 0) displayMessage = false;
            }
                numbersArray[i] = int.Parse(userInput);        
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
        Console.WriteLine();
    } 

    private static void CheckExitProgram(string operation){
        if(operation == "E"){
            Environment.Exit(0);
        }
    }

    private static int CheckNumber(int num, string userInput){
        bool success = int.TryParse(userInput, out num);
        return num;
    }

    private static DateTime GetDate(){
        DateTime date = DateTime.Today;
        string userInput;
        bool displayMessage = true;

        Console.WriteLine("Please enter a date: ");
        while (displayMessage)
        {
            userInput = Console.ReadLine();
            CheckExitProgram(userInput); 
            if(DateTime.TryParse(userInput, out date)) displayMessage = false;
        }
        return date;
    }

    private static int GetDaysToAdd(){
        bool displayMessage = true;
        string userInput = "";

        while (displayMessage)
        {   
            Console.WriteLine("Plese enter the number of days to add: ");            
            userInput = Console.ReadLine();
            CheckExitProgram(userInput);
            if(CheckNumber(0, userInput) > 0) displayMessage = false;
        }
        return int.Parse(userInput );
    }

    private static DateTime CalculateDate(DateTime date, int daysToAdd){
        return date.AddDays(daysToAdd);
    }

    private static void DisplayDate(DateTime date){
        Console.WriteLine("The answer is {0}", date.ToShortDateString());
        Console.WriteLine();
    }
}