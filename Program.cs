using System.Runtime.CompilerServices;

namespace Calculator;

class Program
{
    static void Main(string[] args)
    {   
        #nullable disable                       
        PrintWelcomeMessage();  
        while (true)
        {
            if(GetMode(0) == 1){
                NumbersCalculator.NumbersMode();
            } else {
                DatesCalculator.DatesMode();
            }             
        }
    }

    private static void PrintWelcomeMessage()
    {
        Console.WriteLine("");
        Console.WriteLine("Welcome to the calculator!");
        Console.WriteLine("==========================");        
    }

    private static int GetMode(int num){
        bool display = true;
        string userInput = "";

        while (display)
        {
            Console.WriteLine("");
            Console.WriteLine("Please choose a calculator mode?");
            Console.WriteLine("1 = Numbers");
            Console.WriteLine("2 = Dates");
            userInput = Console.ReadLine();
            CheckExitProgram(userInput);
            if(CheckNumber(0, userInput) > 0 & CheckNumber(0, userInput) < 3) display = false;
        }
        return int.Parse(userInput);
    }

    
    

    public static void CheckExitProgram(string operation){
        if(operation == "E"){
            Environment.Exit(0);
        }
    }

    public static int CheckNumber(int num, string userInput){
        bool success = int.TryParse(userInput, out num);
        return num;
    }   
}

class NumbersCalculator {
    public static void NumbersMode(){
        string operation = "";
        int counter;
        double result = 0;

        operation = GetOperation();
        counter = int.Parse(GetCounter(operation));
        int[] array = new int[counter];
        int[] numbersArray = GetNumbers(array);
        result = PerformCalculations(result, numbersArray, operation);
        DisplayNumbersResult(result);
    }

    private static string GetOperation(){
        bool display = true;
        string operation = "";
        while (display)
        {
            Console.Write("Please enter a valid operator: ");
            operation = Console.ReadLine();
            Program.CheckExitProgram(operation);
            if(operation == "+" || operation == "-" || operation == "*" || operation == "/"){
                display = false;
            }
            Console.Clear();
        }
        return operation;
    }    

    private static string GetCounter(string operation){
        bool display = true;
        string userInput = "";
                
        while (display)
        {
            Console.Write("How many numbers do you want to {0}? ", operation);
            userInput = Console.ReadLine();
            if(Program.CheckNumber(0, userInput) > 0) display = false; 
            Program.CheckExitProgram(userInput); 
            Console.Clear();    
        } 
        return userInput;  
    }    

    private static int[] GetNumbers(int[] numbersArray){
        string userInput = "";

        for (int i = 0; i < numbersArray.Length; i++)
        {   
            bool display = true;
            while (display)
            {
                Console.Write("Please enter number {0}? ", i + 1);
                userInput = Console.ReadLine();
                if(Program.CheckNumber(0, userInput) > 0) display = false;
            }
                numbersArray[i] = int.Parse(userInput);        
        }
        return numbersArray;
    }

    private static double PerformCalculations(double result, int[] numbersArray, string operation){
        if (operation == "*"){
            result = 1;
        }

        for (int i = 0; i < numbersArray.Length; i++)
        {   
            if(operation == "+"){
                    result += numbersArray[i];
                } else if(operation == "-"){
                    if(i == 0){
                        result =  numbersArray[i];
                    } else {
                        result -= numbersArray[i];
                    }
                } else if(operation == "*"){
                    result *= numbersArray[i];
                } else if(operation == "/"){
                    if(i == 0){
                        result = numbersArray[i];
                    } else {
                        result /= numbersArray[i];
                    }
                }           
        }
        return result;
    }

    private static void DisplayNumbersResult(double result){
        Console.WriteLine("The answer is {0}", result);
        Console.WriteLine();
    }
}

class DatesCalculator {
    public static void DatesMode(){
        DateTime date;
        DateTime endDate;
        int daysToAdd;

        date = GetDate();  
        daysToAdd = GetDaysToAdd();
        endDate = CalculateDate(date, daysToAdd);
        DisplayDate(endDate);
    }

    private static DateTime GetDate(){
        DateTime date = DateTime.Today;
        string userInput;
        bool displayMessage = true;

        Console.WriteLine("Please enter a date: ");
        while (displayMessage)
        {
            userInput = Console.ReadLine();
            Program.CheckExitProgram(userInput); 
            if(DateTime.TryParse(userInput, out date)) displayMessage = false;
        }
        return date;
    }

    private static int GetDaysToAdd(){
        bool display = true;
        string userInput = "";

        while (display)
        {   
            Console.WriteLine("Plese enter the number of days to add: ");            
            userInput = Console.ReadLine();
            Program.CheckExitProgram(userInput);
            if(Program.CheckNumber(0, userInput) > 0) display = false;
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