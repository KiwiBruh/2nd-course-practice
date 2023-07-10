namespace lab4;

public interface IIntegralSolver
{
    double Solve(Func<double, double> function, double lowerBound, double upperBound, double accuracy);
    
    string MethodName { get; }
}
public class LeftRectangleSolver : IIntegralSolver
{
    public string MethodName => "Left Rectangles";

    public double Solve(Func<double, double> function, double lowerBound, double upperBound, double accuracy)
    {
        int iterations = 1000; // Максимальное количество итераций
        
        double interval = upperBound - lowerBound;
        double step = interval / iterations;
        
        double result = 0;

        for (int i = 0; i < iterations; i++)
        {
            double x = lowerBound + i * step;
            result += function(x) * step;
        }

        return result;
    }
}
public class RightRectangleSolver : IIntegralSolver
{
    public string MethodName => "Right Rectangles";

    public double Solve(Func<double, double> function, double lowerBound, double upperBound, double accuracy)
    {
        int iterations = 1000; // Максимальное количество итераций
        
        double interval = upperBound - lowerBound;
        double step = interval / iterations;
        
        double result = 0;

        for (int i = 1; i <= iterations; i++)
        {
            double x = lowerBound + i * step;
            result += function(x) * step;
        }

        return result;
    }
}

public class MiddleRectangleSolver : IIntegralSolver
{
    public string MethodName => "Middle Rectangles";

    public double Solve(Func<double, double> function, double lowerBound, double upperBound, double accuracy)
    {
        int iterations = 1000; // Максимальное количество итераций
        
        double interval = upperBound - lowerBound;
        double step = interval / iterations;
        
        double result = 0;

        for (int i = 0; i < iterations; i++)
        {
            double x = lowerBound + (i + 0.5) * step;
            result += function(x) * step;
        }

        return result;
    }
}

public class TrapezoidSolver : IIntegralSolver
{
    public string MethodName => "Trapezoids";

    public double Solve(Func<double, double> function, double lowerBound, double upperBound, double accuracy)
    {
        int iterations = 1000; // Максимальное количество итераций
        
        double interval = upperBound - lowerBound;
        double step = interval / iterations;
        
        double result = 0;

        for (int i = 1; i < iterations; i++)
        {
            double x = lowerBound + i * step;
            result += function(x);
        }

        result += (function(lowerBound) + function(upperBound)) / 2;
        result *= step;

        return result;
    }
}

public class SimpsonSolver : IIntegralSolver
{
    public string MethodName => "Simpson's Rule";

    public double Solve(Func<double, double> function, double lowerBound, double upperBound, double accuracy)
    {
        int iterations = 1000; // Максимальное количество итераций
        
        double interval = upperBound - lowerBound;
        double step = interval / iterations;
        
        double result = 0;

        for (int i = 0; i < iterations; i += 2)
        {
            double x0 = lowerBound + i * step;
            double x1 = x0 + step;
            double x2 = x1 + step;

            result += (function(x0) + 4 * function(x1) + function(x2)) * step / 3;
        }

        return result;
    }
}