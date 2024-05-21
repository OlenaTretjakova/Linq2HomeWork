using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static Linq2HomeWork.Devise;

namespace Linq2HomeWork
{
    class Program
    {
        static void Main()
        {
            //Task 1.

            int[] array1 = { 1234, 2654, 39876, 8, 0, 2 };

            Console.WriteLine("Array 1:");
            ShowEnumerable(array1);
            Console.WriteLine();

            var ArraySumOfNum = new List<int>();

            foreach (var item in array1)
            {
                ArraySumOfNum.Add(GetDigitSum(item));
            }


            Console.WriteLine("Array sum of numbers:");
            ShowEnumerable(ArraySumOfNum);
            Console.WriteLine();

            var sortedByDigitSum = new List<int>();

            sortedByDigitSum = ArraySumOfNum.OrderBy(item=> item).ToList();

            Console.WriteLine();
            Console.WriteLine("Sort Array 1:");

            ShowEnumerable(sortedByDigitSum);

            //Task 2.

            string[] countries1 = {
            "Ukraine", "United States", "Germany", "France", "China","India", "Australia", "Canada"
             };

            string[] countries2 = {
            "Japan", "Brazil", "India","Germany", "Australia", "Canada"
            };

            Console.WriteLine("Array 1:");
            ShowEnumerable(countries1);

            Console.WriteLine();

            Console.WriteLine("Array 2:");
            ShowEnumerable(countries2);

            var UtionContriesArray = countries1.Union(countries2);

            Console.WriteLine();

            Console.WriteLine("UtionContries Array :");
       
            ShowEnumerable(UtionContriesArray);

            Console.WriteLine();
            var diferentArrayes = countries1.Except(countries2);

            Console.WriteLine();

            Console.WriteLine("Diferents of countries1 and countries1:");
            ShowEnumerable(diferentArrayes);

            Console.WriteLine();

            var coincidence = countries1.Intersect(countries2);
            Console.WriteLine("Coincidence of countries1 and countries1:");
            ShowEnumerable(coincidence);

            Console.WriteLine();

            Device[] devices1 = {
            new Device("Laptop", "HP", 1200),
            new Device("Smartphone", "Apple", 900),
            new Device("Tablet", "Samsung", 600)
        };

            Device[] devices2 = {
            new Device("Laptop", "Dell", 1100),
            new Device("Smartwatch", "Apple", 400),
            new Device("Smartphone", "Samsung", 750)
        };

            ShowEnumerable(devices1);
            Console.WriteLine();
            ShowEnumerable(devices2);
            Console.WriteLine();

            Console.WriteLine("Difference of arrays by manufacturer:");
            ShowEnumerable(DifferenceByManufacturer(devices1, devices2));

            Console.WriteLine("\nIntersection of arrays by manufacturer:");
            ShowEnumerable(IntersectionByManufacturer(devices1, devices2));

            Console.WriteLine("\nUnion of arrays by manufacturer:");
            ShowEnumerable(UnionByManufacturer(devices1, devices2));


            Console.ReadLine();
        }

        static List<Device> UnionByManufacturer(Device[] arr1, Device[] arr2)
        {
            var union = arr1.Where(dev1 => arr2.Any(dev2 => dev1.CompareByManufacturer(dev1, dev2))).ToList();
            return union;
        }
        static List<Device> IntersectionByManufacturer(Device[] arr1, Device[] arr2)
        {
            var intersection =arr1.Where(dev1 => arr2.Any(dev2=> dev1.Manufacturer == dev2.Manufacturer)).ToList();
            return intersection;
        }
        static List<Device> DifferenceByManufacturer(Device[] arr1, Device[] arr2)
        {
            var diff = arr1.Where(dev1 =>!arr2.Any(dev2 => dev1.Manufacturer == dev2.Manufacturer)).ToList();
            return diff;
        }

        static int GetDigitSum(int number)
        {
            string numStr = number.ToString();
            int sum = 0;

            foreach (char ch in numStr)
            {
                int digit = int.Parse(ch.ToString());
                sum += digit;
            }

            if (sum >= 10)
            {
                return GetDigitSum(sum);
            }

            return sum;
        }
        static void ShowEnumerable<T>(IEnumerable<T> enumerable)
        {
            foreach (var item in enumerable)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();

        }

    }
}
