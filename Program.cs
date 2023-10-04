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
            displayMessage = CheckNumber(valid, userInput);
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
                Console.Write("Please enter number {0}? ", i + 1);
                userInput = Console.ReadLine();
                displayMessage = CheckNumber(valid, userInput); 
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
    } 

    private static void CheckExitProgram(string operation){
        if(operation == "E"){
            Environment.Exit(0);
        }
    }

    private static bool CheckNumber(bool valid, string num){
        int answer;
        if(int.TryParse(num, out answer)){
            return false;
        }else {
            return true;
        }
    } 
}