using System;
using System.Collections.Generic;
using System.Linq;

namespace Algoritmos
{
    //Main Class
    public class Algoritm
    {
        public static void Main(string[] args)
        {
            var numbersrandom = Utility.GenerateNumbers(1, 1000);
            var modification = new Modifications();
            var option = "";

            Console.WriteLine("------------------[Analisis y Diseño de Algoritmos]------------------");
            for (int i = 1; i < 7; i++)
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

                case "5":
                    modification.ModificationFive(numbersrandom);
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

        public static List<int> GetLastItems (List<int> values, int count, int range)
        {
            List<int> ultimoscien = new List<int>();

            for (int i = 998; i >= 900; i--)
            {
                var item = values[i];
                ultimoscien.Add(item);
            }
            var x = ultimoscien;
            return x;
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


            var valuestaked = values.OrderByDescending(x=>x).ToList(); // Ordenado de forma descendente
            valuestaked = valuestaked.Take(300).ToList();//Tomando los 300 ultimos numeros
            var logaritmos = new List<double>(); // lista donde se guardaran los resultados de los logaritmos
            var mediana = Utility.GetMedian(valuestaked); // obteniendo la mediana de los ultimos 300

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

        public void ModificationFive(List<int> values)
        {
            Console.Clear();
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine("Considerar que se desea mostrar la raíz cúbica de la suma de los 100 primeros números introducidos,\n si esta es mayor que la raíz cuadrada del producto de los últimos 100 números introducidos.");
            Console.WriteLine("\n");
            //Tomando los  100 primeros de la lista
            var valuestaked = values.Take(100).ToList();
            //sumando los 100 numeros tomados
            var suma = Utility.GetSum(valuestaked);
            //obteniendo la raiz cubica del resultado de la suma
            var raizcubica = Math.Pow(suma, (double)1 / 3);
            //obteniendo los 100 ultimos numeros intriducidos
            var ultimoscien = Utility.GetLastItems(values, values.Count, 900);
            //obteniendo el producto de los 100 ultimos
            var resultproducto = Utility.GetMultiplicaction(ultimoscien);
            //obteniendo la raiz cuadrada del resultado del producto
            var raizcuadrada = Math.Sqrt(resultproducto);

            if (raizcubica > raizcuadrada)
            {
                Console.WriteLine($"\nLa raiz cubica de los 100 primeros numeros es: {raizcubica}");
            }

            else
            {
                Console.WriteLine("\nLa raiz cubica de la suma no es mayor que el de la raiz cubica del producto");
            }

            Utility.ClearPromgram();


        }

        public void ModificationSix(List<int> values)
        {
            Console.Clear();
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine("Considerar que se desea mostrar el promedio de los números pares y cuadrados perfectos,\n si este promedio es igual a la mediana de los 100 primeros números pares y múltiplos de 5");
            Console.WriteLine("\n");

            foreach (var item in values)
            {
                var sum = 0;
                var promedio = 0;
                var cantidad = 0;

                var cuadrado = Math.Sqrt(item).ToString(); // es perfecto si el resultado de la raiz cuadrada da un numero entero
                var isPerfect = cuadrado.Contains(".") ? false : true; //si contiene puntos significa que es un decimal
                if (isPerfect && item%2==0)
                {
                    cantidad++;
                    //sumando solo los cuadrados perfectos y pares;
                    sum += item;
                }

                promedio = sum / cantidad;

                //tomando los 100 primeros pares y multiplos de 5;
                var paresymultiplos = new List<int>();

                for (int i = 0; i < values.Count; i++)
                {
                    if (paresymultiplos.Count < 100)
                    {
                        //pares y multiplos de 5
                        if(values[i]%2==0 && values[i] % 5 == 0)
                        {
                            paresymultiplos.Add(values[i]);
                        }
                    }
                }

                //Obtener la mediana de los 100 primeros numeros multiplos de 5 y pares
                var mediana = Utility.GetMedian(paresymultiplos);

                if (promedio == mediana)
                {
                    Console.WriteLine($"El promedio es: {promedio}");
                }
                else
                {
                    Console.WriteLine($"No se puede mostrar el proomedio, no es igual a la mediana");
                }
            }


            Utility.ClearPromgram();


        }
    }
}
