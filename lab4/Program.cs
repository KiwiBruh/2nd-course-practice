using lab4;
public class Program
{
    public static void Main(string[] args)
    {
        Func<double, double> function = x => x * x; // Подынтегральное выражение
        double lowerBound = 0; // Нижняя граница интегрирования
        double upperBound = 1; // Верхняя граница интегрирования
        double accuracy = 0.0000000001; // Точность решения

        IIntegralSolver leftRectangleSolver = new LeftRectangleSolver();
        IIntegralSolver rightRectangleSolver = new RightRectangleSolver();
        IIntegralSolver middleRectangleSolver = new MiddleRectangleSolver();
        IIntegralSolver trapezoidSolver = new TrapezoidSolver();
        IIntegralSolver simpsonSolver = new SimpsonSolver();

        // Решение интеграла с использованием разных методов
        double resultLeftRectangle = leftRectangleSolver.Solve(function, lowerBound, upperBound, accuracy);
        double resultRightRectangle = rightRectangleSolver.Solve(function, lowerBound, upperBound, accuracy);
        double resultMiddleRectangle = middleRectangleSolver.Solve(function, lowerBound, upperBound, accuracy);
        double resultTrapezoid = trapezoidSolver.Solve(function, lowerBound, upperBound, accuracy);
        double resultSimpson = simpsonSolver.Solve(function, lowerBound, upperBound, accuracy);
                                 
                                         // Вывод результатов
        Console.WriteLine("Left Rectangles: " + resultLeftRectangle);
        Console.WriteLine("Right Rectangles: " + resultRightRectangle);
        Console.WriteLine("Middle Rectangles: " + resultMiddleRectangle);
        Console.WriteLine("Trapezoids: " + resultTrapezoid); 
        Console.WriteLine("Simpson's Rule: " + resultSimpson);
    }
}
