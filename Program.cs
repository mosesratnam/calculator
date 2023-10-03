namespace Calculator;

class Program
{
    static void Main(string[] args)
    {   
        #nullable disable
        
        PrintWelcomeMessage();        
        PerformCalculations();        
    }

    private static void PrintWelcomeMessage()
    {
        Console.WriteLine("");
        Console.WriteLine("Welcome to the calculator!");
        Console.WriteLine("==========================");
        Console.WriteLine("");
    }

    private static void PerformCalculations(){
        double counter = 0;
        double sumNumbers = 0;
        string message;

        Console.Write("Please enter the operator: ");
        string operation = Console.ReadLine();
        
        if(operation != "+" & operation != "-" & operation != "*" & operation != "/")
            message = "Please enter either +, -, * or /.";
        else {
            if (operation == "*"){
                sumNumbers = 1;
            }
            Console.Write("How many numbers do you want to {0}? ", operation);
            counter = Double.Parse(Console.ReadLine());
            for (int i = 1; i <= counter; i++)
            {                
                Console.Write("Please enter number {0}? ", i);
                if(operation == "+"){
                    sumNumbers += Double.Parse(Console.ReadLine());
                } else if(operation == "-"){
                    if(i == 1){
                        sumNumbers =  Double.Parse(Console.ReadLine());
                    } else {
                        sumNumbers -= Double.Parse(Console.ReadLine());
                    }
                } else if(operation == "*"){
                    sumNumbers *= Double.Parse(Console.ReadLine());
                } else if(operation == "/"){
                    if(i == 1){
                        sumNumbers = Double.Parse(Console.ReadLine());
                    } else {
                        sumNumbers /= Double.Parse(Console.ReadLine());
                    }
                }
            }
            Console.WriteLine("The answer is {0}", sumNumbers);
        }        
    }
}