namespace Calculator;

class Program
{
    static void Main(string[] args)
    {   
        #nullable disable
        Console.WriteLine("Welsome to the calculator!");
        
        Console.Write("Please type your first number: ");
        double firstNumber = Double.Parse(Console.ReadLine());

        Console.Write("Please type your second number: ");
        double secondNumber = Double.Parse(Console.ReadLine());

        double result = firstNumber * secondNumber;

        Console.WriteLine("The result of {0} * {1} is {2}", firstNumber, secondNumber, result);

    }
}
