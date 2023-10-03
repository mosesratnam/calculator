namespace Calculator;

class Program
{
    static void Main(string[] args)
    {   
        #nullable disable
        Console.WriteLine("");
        Console.WriteLine("Welcome to the calculator!");
        Console.WriteLine("==========================");
        Console.WriteLine("");

        Console.Write("Please enter the operator: ");
        double counter = 0;
        double sumNumbers = 0;
        string message;
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
                    sumNumbers -= Double.Parse(Console.ReadLine());
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

/* Console.Write("Please type your first number: ");
            firstNumber = Double.Parse(Console.ReadLine());

            Console.Write("Please type your second number: ");
            secondNumber = Double.Parse(Console.ReadLine());

            if(operation == "+")
                result = firstNumber + secondNumber;
             else if(operation == "-")
                result = firstNumber - secondNumber;
             else if(operation == "*")
                result = firstNumber * secondNumber;
             else {
                result = firstNumber / secondNumber;
             }
            message = String.Format("The result of {0} {1} {2} is {3}", firstNumber, operation, secondNumber, result);
 */