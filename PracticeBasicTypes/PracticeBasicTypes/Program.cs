using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeBasicTypes
{
    class Task1
    {
        static int[] ex1(int[] array)
        {
            int k = 0;
            for(int i = 0; i < array.Length; i++)
            {
                if (array[i] % 2 != 0)
                    k++;
            }
            int[] set = new int[k];
            k = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] % 2 != 0)
                    set[k++] = array[i];
            }
            return set;
        }

        static int[] ex2(int[] old, int[] _new, int digit)
        {
            int[] set = new int[old.Length + _new.Length];
            int position = -1;
            for (int i = 0; i < old.Length; i++)
            {
                if(old[i] == digit)
                {
                    position = i + 1;
                    break;
                }
            }
            if (position == -1) position = old.Length;
            int j = 0;
            int k = 0;
            for (int i = 0; i < old.Length + _new.Length; i++)
            {
                if (i < position || i > (position + _new.Length - 1)) set[i] = old[j++];
                else set[i] = _new[k++];

            }
            return set;
        }

        static int[] ex3(int[] array)
        {
            if (array == null) return array;
            int total = 1;
            for(int i = 1;i < array.Length; i++)            //or with lastindexof
            {
                int count = 0;
                for (int k = i - 1; k >= 0;k-- )
                    if (array[i] == array[k]) count++;
                if (count == 0) total++;
            }
            int[] set = new int[total];
            int index = 0;
            set[index++] = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                int count = 0;
                for (int k = i - 1; k >= 0; k--)
                    if (array[i] == array[k]) count++;
                if (count == 0) set[index++] = array[i];
            }
            return set;
        }

        static int[] ex4(int[] array, int element)
        {
            int number = 0 , k = 0;
            for (int i = 0; i < array.Length - 1; i++)
            {
                if ((array[i] < 0 && array[i + 1] > 0) || (array[i] > 0 && array[i + 1] < 0)) number++;
            }
            int[] set = new int[number + array.Length];

            set[k++] = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                if ((array[i] < 0 && array[i - 1] > 0) || (array[i] > 0 && array[i - 1] < 0))
                {
                    set[k++] = element;
                    set[k++] = array[i];
                }
                else set[k++] = array[i];
            }
            return set;
        }

        static int[] ex5(int[] array)
        {
            int zeros = 0, k = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == 0) zeros++;
            }
            int[] set = new int[array.Length - zeros];
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] != 0) set[k++] = array[i];
            }
            return set;
        }

        static void Show(int[] set)
        {
            foreach (var item in set)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }

        public static void Test()
        {
            int[] set = { 1, 0, 2, -2, 3, -3, 3,-2,0,0,0};
            Console.WriteLine("The initial array");
            Show(set);
            Console.WriteLine("\n   Delete all even numbers. ");
            Show(ex1(set));
            Console.WriteLine("\n   Insert new element after all elements beginning with the indicated digit. {0}",3);
            Show(ex2(set, new int[]{1,1,1 },3));
            Console.WriteLine("\n   Delete from array all repeating elements except of their first occurrence.");
            Show(ex3(set));
            Console.WriteLine("\n   Insert new element between all element pairs with different signs. ");
            Show(ex4(set,10));
            Console.WriteLine("\n   Compress array by deleting all zero-value elements.");
            Show(ex5(set));
            Console.WriteLine();
        }
    }

    class Task2
    {
        public static int[][] ex1(int[][] array)
        {
            int min = int.MaxValue;
            int x=0, y=0, k = 0;
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    if (array[i][j] < min)
                    {
                        min = array[i][j];
                        x = i;
                        y = j;
                    }
                }
            }

            int[][] set = new int[array.Length + 1][];
            for (int i = 0; i < array.Length; i++)
            {
                if (x != i)
                {
                    set[k++] = new int[array[i].Length];
                    array[i].CopyTo(set[k - 1], 0);
                }
                else
                {
                    set[k++] = new int[y + 1];
                    
                    for (int j = 0; j <= y; j++)
                    {
                        set[k - 1][j] = array[i][j];
                    }
                    set[k++] = new int[array.Length - y + 1];

                    for (int j = y + 1; j < array[i].Length; j++)
                    {
                        set[k - 1][j-y - 1 ] = array[i][j];
                    }
                }
            }
            return set;
        }

        public static int[,] ex2(int[,] array, int element)
        {
            int count = 0, k = 0;
            for (int i = 0; i < array.GetLength(1);i++)
            {
                for (int j = 0; j < array.GetLength(0); j++)
                {
                    if (array[j,i] == element)
                    {
                        count++;
                        break;
                    }
                }
            }
            int[,] set = new int[array.GetLength(0), array.GetLength(1) + count];
            
            for (int i = 0; i < array.GetLength(1); i++,k++)
            {
                count = 0;
                for (int j = 0; j < array.GetLength(0); j++)
                {
                    if (array[j, i] == element)
                    {
                        count = 1;
                        break;
                    }
                }

                if (count != 0) k++;
                for (int j = 0; j < array.GetLength(0); j++)
                {
                    set[j, k] = array[j, i];
                }           
            }
            return set;
        }

        public static int[,] ex3(int[,] array)
        {
            int total = 0,k = 0;
            for (int i = 0; i < array.GetLength(0); i++)
            {
                int count = 0;
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (array[i, j] % 2 == 0) count++;
                }
                if (count == array.GetLength(1)) total++;
            }

            int[,] set = new int[array.GetLength(0) - total, array.GetLength(1)];

            for (int i = 0; i < array.GetLength(0); i++)
            {
                int count = 0;
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (array[i,j] % 2 == 0) count++;
                }
                if (count != array.GetLength(1))
                {
                    for (int j = 0; j < array.GetLength(1); j++)
                    {
                        set[k, j] = array[i, j];
                    }
                    k++;
                }
            }
            return set;
        }

        public static int[,] ex4(int[,] array){
            int total = 0, k = 0;
            for (int i = 0; i < array.GetLength(1); i++)
            {
                int count = 0;
                for (int j = 0; j < array.GetLength(0); j++)
                {
                    if (array[j,i]> 0) count++;
                }
                if (count == array.GetLength(0)) total++;
            }

            int[,] set = new int[array.GetLength(0), array.GetLength(1) - total];

            for (int i = 0; i < array.GetLength(1); i++)
            {
                int count = 0;
                for (int j = 0; j < array.GetLength(0); j++)
                {
                    if (array[j,i] > 0) count++;
                }
                if (count != array.GetLength(0))
                {
                    for (int j = 0; j < array.GetLength(0); j++)
                    {
                        set[j,k] = array[j,i];
                    }
                    k++;
                }
            }
            return set;
        }

        public static int[,] ex5(int[,] array, int line, int col)
        {
            if (line != col) return array;
            int k = 0, l;
            int[,] set = new int[array.GetLength(0) - 1, array.GetLength(1) - 1];

            for (int i = 0; i < array.GetLength(0); i++)
            {
                if(i != line)
                {
                    l = 0;
                    for (int j = 0; j < array.GetLength(1); j++)
                    {
                        if(j != col)
                        {
                            set[k, l++] = array[i, j];
                        }
                    }
                    k++;
                }
            }
            return set;
        }

        public static int[,] ex6(int[,] array)
        {
            int count = 0, col = 0, rows = 0, current_row = 0, current_col = 0;
            for (int i = 0; i < array.GetLength(0); i++)
            {
                count = 0;
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (array[i, j] == 0) count++;
                }
                if (count == array.GetLength(1)) rows++;
            }       //parcurgere pe linie
            for (int i = 0; i < array.GetLength(1); i++)
            {
                count = 0;
                for (int j = 0; j < array.GetLength(0); j++)
                {
                    if (array[j, i] == 0) count++;
                }
                if (count == array.GetLength(0)) col++;
            }       //parcurgere pe diagonala

            int[,] set = new int[array.GetLength(0) - rows, array.GetLength(1) - col];

            for (int i = 0; i < array.GetLength(0); i++)
            {
                count = 0;
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (array[i, j] == 0) count++;
                }
                if (count != array.GetLength(1))  //finds the zero array
                {
                    current_col = 0;
                    for (int j = 0; j < array.GetLength(1); j++)                //copies the remaining rows and cols
                    {
                        if (array[i, j] != 0) set[current_row , current_col++] = array[i, j];
                    }
                    current_row++;
                }
            }
            return set;
        }

        public static void Test()
        {
            int[][] array = new int[3][];
            array[0] = new int[] { 1, 1, 0, 7, 9 };
            array[1] = new int[] { 2, 0, 4, 6 };
            array[2] = new int[] { 11, 22 };

            int[,] ar = new int[4, 3] { {0,0,0 }, {4,2,0 }, {2,8,0 }, {10,11,0 } };

            Console.WriteLine("The initial jagged array");
            Show(array);
            Console.WriteLine("\n   Insert new line after line containing the first occurrence of the minimal element. ");
            Show(ex1(array));
            Console.WriteLine("\nThe initial multidimensional array");
            Show(ar);
            Console.WriteLine("\n	Insert new column before all columns containing the indicated number. {0} ",2);
            Show(ex2(ar, 2));
            Console.WriteLine("\n	Delete all lines, containing only even number elements. ");
            Show(ex3(ar));
            Console.WriteLine("\n   Delete all columns, containing only positive elements");
            Show(ex4(ar));
            Console.WriteLine("\n   Delete from array the k-th line and the j-th column if their values coincide.--> {0} and {0}",1);
            Show(ex5(ar, 1, 1));
            Console.WriteLine("\n   Compress array by deleting all only zero-value lines and columns.");
            Show(ex6(ar));
        }

        static void Show(int[][] set)
        {
            foreach (var item in set)
            {
                foreach (var it in item)
                {
                    Console.Write(it + "\t");
                }
                Console.WriteLine();
            }
        }
        static void Show(int[,] set)
        {
            for (int i = 0; i < set.GetLength(0); i++)
            {
                for (int j = 0; j < set.GetLength(1); j++)
                {
                    Console.Write(set[i,j] + "\t");
                }
                Console.WriteLine();
            }
        }
    }

    class Task3
    {
        static string ex1(string str)
        {
            str = str.Replace('y'.ToString(), 'y'.ToString() + 'x'.ToString());
            return str;
        }

        static string ex2(string str)
        {
            int index = 0;
            foreach (char item in str)
            {    
                if (index % 2 != 0)
                {
                    str = str.Remove(index, 1).Insert(index-1, item.ToString());
                }
                index++;
            }
            return str;
        }

        static char ex3(string str, char first, char second)
        {
            int countFirst = str.Split(first).Length - 1;
            int countSecond = str.Split(second).Length - 1;

            return (countFirst > countSecond) ? first: second;
        }

        static void ex4(string str)
        {
            int countFirst = str.Split('x').Length - 1;
            int countSecond = str.Split('y').Length - 1;

            Console.WriteLine($"x -->> {countFirst}\ty -->> {countSecond}");
        }

        static void ex5(string str)
        {
            int count = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if ((str.Substring(i, str.Length - i).Split(str[i]).Length - 1) == 1)
                    count++;
            }
            Console.WriteLine("String-ul contine {0} caractere distincte",count);
        }                       

        static bool ex6(string str)
        {
            char[] array = str.ToArray();
            for(int i = 0; i < array.Length - 1; i++)
            {
                if (array[i] == array[i + 1]) return true;
            }
            return false;
        }

        static string ex7(string str)
        {
            var length = str.Length;
            Console.WriteLine("String-ul are {0} caracatere",length);
            if(length % 2 != 0)
            {
                str = str.Remove(length / 2, 1);
            }
            else
            {
                str = str.Remove(length / 2 - 1, 2);
            }
            return str;
        }

        static string ex8(string str)
        {
            var index = 0;
            foreach (char item in str)
            {
                index++;
                if (item == 'x') str = str.Insert(index++, 'x'.ToString());
            }
            return str;
        }

        static string ex9(string str)
        {
            var index = 0;
            foreach (char item in str)
            {
                index++;
                if (item == 'x') str = str.Remove(index-1, 1);
            }
            return str;
        }

        static string ex10(string str,string substr)
        {
            if (str.Contains(substr).Equals(false)) return str;
            var index = 0;
            while ((index = str.IndexOf(substr)) != -1)
            {
                str = str.Remove(index, substr.Length);
            }
            return str;
        }

        static string ex11(string str, string substr1, string substr2)
        {
            if (str.Contains(substr1).Equals(false)) return str;
            var index = 0;
            while ((index = str.IndexOf(substr1)) != -1)
            {
                str = str.Remove(index, substr1.Length).Insert(index, substr2);
            }
            return str;
        }

        static int ex12(string str)
        {
            int sum = 0;
            for(int i = 0; i < str.Length; i++)
            {
                int offset = 0;
                while (Char.IsDigit(str[i]).Equals(true))
                {
                    offset++;
                    i++;
                }
                   if (offset != 0)
                        sum += Int32.Parse(str.Substring(i - offset, offset)); 
            }
            return sum;
        }      

        static int ex13(string str)
        {
            int sum = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (Char.IsDigit(str[i]).Equals(true))
                {
                    sum += Int32.Parse(str[i].ToString());
                }
            }
            return sum;
        }

        static void ex14(string str)
        {
            Console.WriteLine($"The first and the last occurance of character x are {str.IndexOf('x')},{str.IndexOf('x')}");
        }

        static string ex15(string str)
        {
            for (int i = 0; i < str.Length; i++)
            {
                int offset = 0;
                while (str[i] == '.')
                {
                    offset++;
                    i++;
                }
                if (offset > 1)
                {
                    str = str.Replace(str.Substring(i - offset, offset), "...");
                    i = i - offset + 3;
                }
            }
            return str; 
        }

        static string ex16(string str)
        {
            if (str.IndexOf(':') == -1) return str;
            return str.Substring(0, str.IndexOf(':'));
        }

        static string ex17(string str)
        {
            var temp = str.IndexOf(':');
            if (temp == -1) return str;
            return str.Substring(temp + 1, str.Length - temp - 1);
        }

        static string ex18(string str)
        {
            for (int i = 0; i < str.Length; i++)
            {
                if(str[i] == '(')
                {
                    int offset = 0;
                    while ((str[i++] != ')') && (i < str.Length))   offset++;
                    str = str.Remove(i - offset,offset - 1);
                    i -= offset;
                }
            }
            return str;
        }

        static string ex19(string str)
        {
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == '{')
                {
                    int offset = 0;
                    while ((str[i++] != '}') && (i < str.Length)) offset++;
                    str = str.Remove(i - offset, offset - 1);
                    i -= offset;
                }
            }
            return str;
        }

        static void ex20(string str)
        {
            for (int i = 0; i < str.Length; i++)
            {
                if ((str.Substring(i, str.Length - i).Split(str[i]).Length - 1) == 1)
                    Console.WriteLine($"{str[i]} -->> {str.Split(str[i]).Length - 1}");
            }
        }

        public static void Test()
        {
            string set = "abc efx efy ab:c (z{ )1 (12 a.....5.......)56.qtry2}ee";
            Console.WriteLine("\tThe initial string");
            Console.WriteLine(set);
            Console.WriteLine("\n\tInsert  character <x> after every occurrence of character <y>; ");
            Console.WriteLine(ex1(set));
            Console.WriteLine("\n\tMix up the first character with the second one, the third character with the fourth one");
            Console.WriteLine(ex2(set));
            Console.WriteLine("\n\tFind, which of two indicated characters is occurred in the string more often ->> {0},{1}", '5', 'e');
            Console.WriteLine(ex3(set, '5', 'e'));
            Console.WriteLine("\n\tCount full number of occurrences of <x> and <y> characters; ");
            ex4(set);
            Console.WriteLine("\n\tCount number of different characters in the string");
            ex5(set);
            Console.WriteLine("\n\tFind out if the string has two adjacent identical characters;");
            Console.WriteLine(ex6(set));
            Console.WriteLine("\n\tDelete the middle character if string length is odd or two middle characters if string length is even; ");
            Console.WriteLine(ex7(set));
            Console.WriteLine("\n\tDouble every occurrence of the indicated character <x>");
            Console.WriteLine(ex8(set));
            Console.WriteLine("\n\tDelete all occurrences of  the character <x>");
            Console.WriteLine(ex9(set));
            Console.WriteLine("\n\tDelete all occurrences of the substring <substr>;");
            Console.WriteLine(ex10(set, "abc"));
            Console.WriteLine("\n\nReplace all occurrences of the substring <substr1> on the substring <substr2>;");
            Console.WriteLine(ex11(set, "abc", "xxx"));
            Console.WriteLine("\n\tCount the sum of all numbers occurred in the string");
            Console.WriteLine(ex12(set));
            Console.WriteLine("\n\tCount the sum of all digits occurred in the string");
            Console.WriteLine(ex13(set));
            Console.WriteLine("\n\tFind indexes of the first and the last occurrences of the character <x>");
            ex14(set);
            Console.WriteLine("\n\tReplace all groups of adjacent dots with ellipsis");
            Console.WriteLine(ex15(set));
            Console.WriteLine("\n\tDisplay all characters before the first colon occurrence in the string");
            Console.WriteLine(ex16(set));
            Console.WriteLine("\n\tDisplay all characters after the first colon occurrence in the string; ");
            Console.WriteLine(ex17(set));
            Console.WriteLine("\n\tDelete all characters inside the parenthesize");
            Console.WriteLine(ex18(set));
            Console.WriteLine("\n\tDelete all characters inside the curly braces");
            Console.WriteLine(ex19(set));
            Console.WriteLine("\n\tCount and display statistics of character occurrences in the string");
            ex20(set);
        }

}

    class Task4
    {
        
    }

    class Task5
    {

    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n\n Task 1");
            Task1.Test();
            Console.WriteLine("\n\n Task 2");
            Task2.Test();
            Console.WriteLine("\n\n Task 3");
            Task3.Test();
        }
    }
}
