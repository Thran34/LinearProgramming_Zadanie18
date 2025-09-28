using System.Diagnostics;
using System.Numerics;
using Google.OrTools.LinearSolver;

namespace LinearProgramming_Zadanie18
{
    public class LinearProgramming_Zadanie18
    {
        /* (5 punktów) Dany jest zbiór liczb {641, 4112, 3296, 3146, 1716,
         1521, 5566, 6600, 831875, 6318, 1242, 2827, 324, 250, 17303, 
         1782, 345, 352, 4950, 3125, 28561, 5175, 3300, 3399, 12167, 
         1170, 2369, 3312, 330, 1542, 5070, 515, 164737, 3042, 6210, 
         2340, 5769, 288, 1285, 744769, 23}. Czy z tego zbioru da 
         się wybrać podzbiór liczb, których iloczyn wyniesie 
         58503359928829676889083701609993243500000? */
        
        public static (BigInteger product, int[] selectedNumbers)? Solve(BigInteger expectedResult, int[] integers)
        {
            double target = BigInteger.Log(expectedResult);

            // Próbowałem uzyć SCIP ale działa bardzo wolno.
            Solver solver = Solver.CreateSolver("SAT");

            if (solver == null)
                throw new Exception("Nie mozna stworzyć solvera!.");

            var x = new Variable[integers.Length];
            for (int i = 0; i < integers.Length; i++)
                x[i] = solver.MakeBoolVar($"x[{i}]");

            Constraint constraint = solver.MakeConstraint(target, target, "product_constraint");
            for (int i = 0; i < integers.Length; i++)
                constraint.SetCoefficient(x[i], Math.Log(integers[i]));

            Objective objective = solver.Objective();
            for (int i = 0; i < integers.Length; i++)
                objective.SetCoefficient(x[i], 0);
            objective.SetMinimization();

            Stopwatch sw = Stopwatch.StartNew();
            Solver.ResultStatus resultStatus = solver.Solve();
            sw.Stop();
            Console.WriteLine($"Czas rozwiązania: {sw.Elapsed}");

            if (resultStatus == Solver.ResultStatus.OPTIMAL)
            {
                BigInteger product = 1;
                var selectedNumbers = new List<int>();
                for (int i = 0; i < integers.Length; i++)
                {
                    if (x[i].SolutionValue() > 0.5)
                    {
                        selectedNumbers.Add(integers[i]);
                        product *= integers[i];
                    }
                }
                return (product, selectedNumbers.ToArray());
            }

            return null;
        }
         
        static void Main(string[] args)
        {
            Console.WriteLine("Podaj oczekiwany wynik:");
            string? expectedInput = Console.ReadLine();
            if (!BigInteger.TryParse(expectedInput, out BigInteger expectedResult))
            {
                Console.WriteLine("Niepoprawna wartość.");
                return;
            }

            Console.WriteLine("Podaj listę liczb oddzielonych przecinkami:");
            string? numbersInput = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(numbersInput))
            {
                Console.WriteLine("Brak liczb.");
                return;
            }

            int[] numbers = numbersInput
                .Split(',', StringSplitOptions.RemoveEmptyEntries)
                .Select(s => int.Parse(s.Trim()))
                .ToArray();

            var result = Solve(expectedResult, numbers);

            if (result != null)
            {
                Console.WriteLine("Znaleziono rozwiązanie:");
                Console.WriteLine(string.Join(" ", result.Value.selectedNumbers));
                Console.WriteLine("Iloczyn = " + result.Value.product);
            }
            else
            {
                Console.WriteLine("Nie znaleziono rozwiązania.");
            }
        }
    }
}
