using System;
using System.Collections.Generic;
using System.Linq;

namespace Algoritmos
{
    //Main Class
    public class Algoritm
    {
        static List<int> numbersrandom = new List<int>();
        public static void Main(string[] args)
        {
            var numbersrandom = Utility.GenerateNumbers(1, 1000);
            var modification = new Modifications();
            var option = "";

            Console.WriteLine("------------------[Analisis y Diseño de Algoritmos]------------------");
            for (int i = 1; i < 5; i++)
            {
                Console.WriteLine($"{i}. Modificacion {i}");
            }
            Console.WriteLine("Digite una opcion: => ");
            option = Console.ReadLine();

            switch (option)
            {
                case "1" :
                    modification.ModificationOne(numbersrandom);
                    break;

                case "2":
                    modification.ModificationTwo(numbersrandom);
                    break;

                case "3":
                    modification.ModificationThree(numbersrandom);
                    break;

                case "4":
                    modification.ModificationFour(numbersrandom);
                    break;



                default:
                    Console.WriteLine("Option Out Range");
                    Console.ReadKey();
                    Console.Clear();
                    Algoritm.Main(null);
                    break;
            }
        }
    }

    //Contains method that be utility in the program
    public static class Utility
    {
        public static List<int> GenerateNumbers(int min, int max)
        {
            var random = new Random();
            List<int> numbers = new List<int>();
            for (int i = 1; i < 1000; i++)
            {
                var number = random.Next(min, max);
                numbers.Add(number);
            }
            return numbers;
        }

        public static int GetSum(List<int> values)
        {
            var sum = 0;
            for (int i = 0; i < values.Count; i++)
            {
                sum += values[i];
            }
            return sum;
        }

        public static double GetMultiplicaction(List<int> values)
        {
            double result = 1;
            for (int i = 0; i < values.Count; i++)
            {
                result *= values[i];
            }
            return result;
        }

        public static double GetMultiplicaction(List<double> values)
        {
            double result = 1;
            for (int i = 0; i < values.Count; i++)
            {
                result *= values[i];
            }
            return result;
        }

        public static int GetImparNumbers(List<int> values)
        {
            var count = 0;
            foreach (var item in values)
            {
                if (item % 2 == 1)
                {
                    //es impar
                    count++;
                }
            }
            return count;
        }

        public static double GetMedian(List<int> sourceNumbers)
        {
            var sorceArray = sourceNumbers.ToArray();
            if (sorceArray == null || sorceArray.Length == 0)
                throw new System.Exception("Median of empty array not defined.");

            //make sure the list is sorted, but use a new array
            int[] sortedPNumbers = (int[])sorceArray.Clone();
            Array.Sort(sortedPNumbers);

            //get the median
            int size = sortedPNumbers.Length;
            int mid = size / 2;
            double median = (size % 2 != 0) ? (double)sortedPNumbers[mid] : ((double)sortedPNumbers[mid] + (double)sortedPNumbers[mid - 1]) / 2;
            return median;
        }

        public static void ClearPromgram()
        {
            Console.ReadKey();
            Console.Clear();
            Algoritm.Main(null);
        }
    }

    public class Modifications
    {
        public void ModificationOne(List<int> values)
        {
            Console.Clear();
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine("Considerar que solo se desea mostrar la suma de los que sean pares \n y el producto de los múltiplos de 5.");
            double sumpair = 0;
            double multiplicationpair = 1;
            List<double> result = new List<double>();

            foreach (var item in values)
            {
                var x = item % 5;

                if (item % 2 == 0)
                {
                    sumpair += item;
                }
                if (item % 5 == 0)
                {
                    multiplicationpair *= item;
                }
            }
            Console.WriteLine($"\nEl total de la suma de los numeros pares es: {sumpair}");
            Console.WriteLine($"\nEl total del producto de los multiplos de 5 es: {multiplicationpair}");
            Console.ReadKey();
            Console.Clear();
            Algoritm.Main(null);

        }

        public void ModificationTwo(List<int> values)
        {
            Console.Clear();
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine("Considerar que se desea obtener y mostrar la suma de los que sean cuadrados perfectos\n y mostrar el logaritmo natural del producto de los que sean pares y múltiplos de 7.");
            var sum = 0;
            var multipication = 1;
            double lognatural = 0;
            foreach (var item in values)
            {
               
                var cuadrado = Math.Sqrt(item).ToString(); // es perfecto si el resultado de la raiz cuadrada da un numero entero
                var isPerfect = cuadrado.Contains(".") ? false : true; //si contiene puntos significa que es un decimal
                if (isPerfect)
                {
                    //sumando solo los cuadrados perfectos;
                    sum += item;
                }

                if (item % 2 == 0 && item % 7 == 0)
                {
                    // producto de los que sean pares y múltiplos de 7
                    multipication *= item;
                }
                //logaritmo natural del producto
                lognatural = Math.Log(multipication);

            }

            Console.WriteLine($"\nEl total de la suma de los cuadrados perfectos: {sum}");
            Console.WriteLine($"\nlogaritmo natural del producto de los que sean pares y múltiplos de 7: {lognatural}");
            Utility.ClearPromgram();

        }

        public void ModificationThree(List<int> values)
        {
            Console.Clear();
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine("Considerar que sea desea mostrar el total de los números impares\n si este resultado es mayor que el promedio de la primera mitad de los números introducidos");

            //obteniendo la cantidad de numeros impares
            var totalimpares = Utility.GetImparNumbers(values);
            //la mitad de los valores introducidos
            var mitad = values.Count + 1;
            mitad /= 2;

            //promedio de la mitad de valores
            var mitaddevalores = values.Take(mitad).ToList();
            var sum = Utility.GetSum(mitaddevalores); // obteniendo la mitad de la antidad de los valores 
            var promedio = sum / mitad;

            if (totalimpares > promedio)
            {
                Console.WriteLine($"\nEl total de numeros impares es: {totalimpares}");
            }
            else
            {
                Console.WriteLine("\nNo se pueuden mostrar los resultados de los numeros impares. \n es mayor que el promedio de la primera mitad de los números introducidos");
            }
            Utility.ClearPromgram();


        }

        public void ModificationFour(List<int> values)
        {
            Console.Clear();
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine("Considerar que se desea mostrar el producto de los logaritmos naturales de los 100 primeros números, \n si éste es mayor que la mediana de los 300 últimos números introducidos.");


            var valuestaked = values.Take(300).ToList(); //Tomando los 300 primeros numeros
            var logaritmos = new List<double>();
            var mediana = Utility.GetMedian(valuestaked); // obteniendo la mediana de los primeros 300

            //Obteniendo de los 100 primeros numeros
            var first_hundred = values.Take(100).ToList();
            //obteniendo el logaritmo de los primeros 100 y agregandolos a una lista;
            foreach (var item in first_hundred)
            {
                var log = Math.Log(item);
                logaritmos.Add(log);
            }

            //obteniendo el producto de los logaritmos
            var producto = Utility.GetMultiplicaction(logaritmos);

            if (producto > mediana)
            {
                Console.WriteLine($"\nEl prodcuto de los logaritmos naturales de los 100 primeros numeros es: {producto}");
            }
            else
            {
                Console.WriteLine($"\nEl prodcuto de los logaritmos naturales de los 100 primeros numeros es mayor que la mediana de los 300 últimos números introducidos");
            }

            Utility.ClearPromgram();

        }
    }
}
