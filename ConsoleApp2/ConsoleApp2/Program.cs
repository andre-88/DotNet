﻿using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Solution
{

    // Complete the divisibleSumPairs function below.
    static string encryption(string s)
    {
        s =  s.Replace("  ", string.Empty);

        var lenght = s.Length;
        var root = Math.Pow(Convert.ToDouble(lenght), 0.5);
        var floor = Math.Floor(root);
        var ceil =(int) Math.Ceiling(root);

        if ((ceil * floor) < lenght)
            floor += 1;

        string result = "";
        var c = 0;

        for (int i = 0; i < ceil; i++)
        {
            var count = 0;
            while (i + (count * ceil) < lenght)
            {
                result += s[i + (count * ceil)];
                count++;
            }
            result += " ";


        }

        return result;
    }


    static int birthday(List<int> s, int d, int m)
    {
        //d: somatorio
        //m:  casas consecutivas
        int occurences = 0;

        var totalWays = 0;

        var choclateBarValues = s.ToArray();

        if (choclateBarValues.Length >= m)
        {
            var barPartSum = 0;
            for (int i = 0; i < m; i++)
                barPartSum += choclateBarValues[i];

            if (barPartSum == d)
                totalWays++;

            for (int i = 0; i < choclateBarValues.Length - m; i++)
            {
                barPartSum = barPartSum - choclateBarValues[i] + choclateBarValues[i + m];

                if (barPartSum == d)
                    totalWays++;
            }
        }
        return totalWays;

    }

    static int migratoryBirds(List<int> arr)
    {
        int result = 0;
        var occurrences = new Dictionary<int, int>();
        var distinct = arr.Distinct().ToList();
        var max = 0;
        var minElement = int.MaxValue;

        foreach(var element in distinct)
        {
            var occurrenceByElement = arr.Count(x => x == element);

            if (max < occurrenceByElement)
                max = occurrenceByElement;
           
            occurrences.Add(element, occurrenceByElement);
        }

        var maxElemnts = occurrences.Where(y => y.Value == max).Select(x => x.Key);


        result = maxElemnts.Min();
        return result;
    }


    static string appendAndDelete(string wordA, string wordB, int operations)
    {
        var lenghA = wordA.Length;
        var lenghB = wordB.Length;
        var lenghtVariation = lenghA - lenghB;

        if (Math.Abs(lenghtVariation) > operations)
            return "No";



        return "";
    }


    static int sockMerchant(int n, int[] ar)
    {
        // n:   number of socks
        // arr: the colors of each sock

        int pairCount = 0;
        var occurrences = ar.Distinct().ToList().ToDictionary(x => x, x => 0);

        for (int i = 0; i < ar.Length; i++)
        {
            occurrences[ar[i]] += 1;
        }


        foreach(var item in occurrences)
        {
            var valor = item.Value;
            while ((valor - 2) >= 0)
            {
                pairCount += 1;
                valor = (valor) - 2;
            }
      
        }
        
        return pairCount;
    }

    // Complete the hurdleRace function below.
    static int hurdleRace(int k, int[] height)
    {
        //k: maximum height
        var higherHurdle = height.Max();
                
        return (higherHurdle <= k) ? 0 : (higherHurdle - k);
    }

    static int countingValleys(int n, string s)
    {
        int valleys = 0;
        int up = 0;
        int down = 0;
        int terrain = 0;

        for(int i = 0; i < n; i++)
        {
            if (s[i] == 'U')
            {
                terrain += 1;
            }
            if (s[i] == 'D')
            {
                terrain -= 1;
            }
            if (terrain == 0)
            {
                valleys += 1;
            }
        }

        return valleys;
    }


    static void insertionSort1(int n, int[] arr)
    {
        //for (int i = 1; i < arr.Length; i++)
        //{
        //    int aux = arr[i];
        //    int j = i;

        //    while ((j > 0) && (arr[j - 1] > aux))
        //    {
        //        arr[j] = arr[j - 1];
        //        j -= 1;
        //    }
        //    arr[j] = aux;
        //    printArray(arr);
        //}
        var i = arr.Length - 1;
        var currElement = arr[i];
        var j = i - 1;
        for (; j >= 0; j--)
        {
            if (currElement < arr[j])
            {
                arr[j + 1] = arr[j];
                Console.WriteLine(String.Join(" ", arr));
            }
            else
                break;
        }

        arr[j + 1] = currElement;
        Console.WriteLine(String.Join(" ", arr));


    }


    static int findDigits(int n)
    {
        int isDivisor = 0;
        string stringNumber = n.ToString();

        foreach (char c in stringNumber)
        {
            var intValue = Char.GetNumericValue(c);

            if(n % intValue == 0)
            {
                isDivisor += 1;
            }
        }
 
        return isDivisor;
    }


    static int designerPdfViewer(int[] h, string word)
    {
        int maxHeight = 0;

        for (int i = 0; i < word.Length; i++)
        {
            var character = word[i];
            var numericValue = Convert.ToInt32(character);

            int position = numericValue - 97;

            if (h[position] > maxHeight)
                maxHeight = h[position];

        }

        return word.Length * maxHeight;
    }


    static string angryProfessor(int k, int[] arr)
    {
        //k: cancellation threshold
        //Return YES if class is cancelled
        int onTime = 0;
        int late = 0;

        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] <= 0)
                onTime += 1;
            else late += 1;
        }

            return onTime >= k ? "NO" : "YES";

    }

    static int squares(int a, int b)
    {
        var first = Math.Ceiling(Math.Sqrt(a));
        var last = Math.Floor(Math.Sqrt(b));
        return Convert.ToInt32((last - first)) + 1;
    }

    static int utopianTree(int n)
    {
        int intial = 1;
        int cycleCount = 0;
        bool shouldDouble = true;


        while(cycleCount < (n))
        {
            if (shouldDouble)
            {
                intial = intial * 2;
            }
            else intial = intial + 1;

            shouldDouble = !shouldDouble;
            cycleCount++;
        }


        return intial;
    }


    static int[] circularArrayRotation(int[] a, int k, int[] queries)
    {
        //a: initial array
        //k: number of rotations
        // queries: positon of the elements

        var afterRotation = new List<int>();

        //Step 1: perform rotation
        int counter = 0;
        while (counter < k)
        {
            var elementIndex = a.Length - counter - 1;
            afterRotation.Insert(0, a.ElementAt(elementIndex));
            counter++;
        }


        var remain = a.Where(e => !afterRotation.Contains(e)).ToList();
        afterRotation.AddRange(remain);


        //Step 2: find the elements query
        var result = new List<int>();

        foreach(int i in queries)
          result.Add(afterRotation[i]);
        
               
        return result.ToArray();
    }

    static string catAndMouse(int x, int y, int z)
    {
        //X: cat A
        //Y: Cat B
        //Z: Mouse

        var distanceXZ = Math.Abs((Math.Abs(x) - Math.Abs(z)));
        var distanceYZ = Math.Abs((Math.Abs(y) - Math.Abs(z)));

        var result = "Mouse C";

        if (distanceXZ < distanceYZ)
            result = "Cat A";

        if(distanceYZ < distanceXZ)
            result = "Cat B";

        return result;

    }

    static int findMedian(int[] arr)
    {

        var lenght = arr.Length;

        var list = arr.ToList();

        list.Sort();

        var medianPosition = Math.Floor((decimal)lenght / 2);

        return list[(int)medianPosition];
    }

    static int introTutorial(int V, int[] arr)
    {
        int position = 0;
        var searchElementfound = false;

        while ((position < arr.Length) && !searchElementfound)
        {
            if (arr[position] == V)
                searchElementfound = true;

            position++;
        }



        return position-1;
    }


    static void Main(string[] args)
    {
        int k = 4;
        var str = "0 1 2 4 6 5 3";
        int[] arr = Array.ConvertAll(str.Split(' '), arTemp => Convert.ToInt32(arTemp));
        var s = new List<int>() {0,1,2 };


        //var result = squares(100,1000);
        var result = introTutorial(k, arr);       
        Console.WriteLine(result);


        //var str = "10 20 20 10 10 30 50 10 20";
        //int[] ar = Array.ConvertAll(str.Split(' '), arTemp => Convert.ToInt32(arTemp));

        //var s = new List<int>() { 1, 2, 1, 3, 2, };
        //var d = 3;
        //var m = 2;

        //var s = new List<int>() { 4 };
        //var d = 4;
        //var m = 1;

        //var list = new List<int>() { 2, 4, 6, 8, 3 };
        //var n = 8;

        //insertionSort1(n, list.ToArray());

        //var result = insertionSort1(n, list.ToArray());
        //Console.WriteLine(result);     

        var key = Console.ReadKey();
    }
}
