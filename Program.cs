namespace Calculator;

class Program
{
    static void Main(string[] args)
    {   
        #nullable disable
        Console.WriteLine("Welcome to the calculator!");
        Console.WriteLine("==========================");
        Console.WriteLine("");

        Console.WriteLine("Please enter the operator: ");
        double firstNumber;
        double secondNumber;
        double result;
        string message = "";
        string operation = Console.ReadLine();
        
        if(operation != "+" & operation != "-" & operation != "*" & operation != "/")
            message = "Please enter either +, -, * or /.";
        else {
            Console.Write("Please type your first number: ");
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
        }        
        Console.WriteLine(message);
    }
}
