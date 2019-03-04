using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_2v2
{
    class Program
    {
        static void Main(string[] args)
        {
            string line;
            var result = DoublyLinlkedListNumber.Parse("0");

            Console.WriteLine("Enter a number!");

            while ((line = Console.ReadLine()) != "exit")
            {
                DoublyLinlkedListNumber op;
                if (DoublyLinlkedListNumber.TryParse(line, out op))
                {
                    result += op;
                    Console.WriteLine(result.ToString());
                }
                else
                {
                    Console.WriteLine("Not a number. Enter a number!");
                }
            }

        }

        public class DoublyLinlkedListNumberItem
        {
            public byte Didgit { get; set; }
            public DoublyLinlkedListNumberItem Next { get; set; }
            public DoublyLinlkedListNumberItem Previous { get; set; }

            //constructor
            public DoublyLinlkedListNumberItem(byte didgit) { Didgit = didgit; }
        }

        public class DoublyLinlkedListNumber
        {
            DoublyLinlkedListNumberItem head;
            DoublyLinlkedListNumberItem tail;

            public static bool TryParse(string s, out DoublyLinlkedListNumber result)
            {
                try
                {
                    result = Parse(s);
                    return true;
                }
                catch (Exception)
                {
                    result = null;
                    return false;
                }
            }

            public static DoublyLinlkedListNumber Parse(string s)
            {
                if (s == null || s.Any(c => !char.IsDigit(c)))
                    throw new Exception("Not a number.");

                var result = new DoublyLinlkedListNumber();

                foreach (var c in s.Reverse())
                    result.AddDidgitToBack((byte)(c - '0'));

                return result;
            }


            private void AddDidgitToBack(byte didgit)
            {
                DoublyLinlkedListNumberItem item = new DoublyLinlkedListNumberItem(didgit);

                if (tail == null)
                    tail = item;
                else
                {
                    item.Next = head;
                    head.Previous = item;
                }

                head = item;
            }

            private IEnumerable<DoublyLinlkedListNumberItem> IterateFromBack()
            {
                if (tail == null)
                    yield return null;

                var curent = tail;
                while (curent != head)
                {
                    yield return curent;
                    curent = curent.Previous;
                }
                yield return curent;
            }

            public static DoublyLinlkedListNumber operator +(DoublyLinlkedListNumber op1, DoublyLinlkedListNumber op2)
            {
                DoublyLinlkedListNumber result = new DoublyLinlkedListNumber();

                byte oveflow = 0;

                var ds1 = op1.IterateFromBack().ToList();
                var ds2 = op2.IterateFromBack().ToList();

                var len = Math.Max(ds1.Count(), ds2.Count());

                for (int i = 0; i < len; i++)
                {
                    var item = new { D1 = ds1.ElementAtOrDefault(i), D2 = ds2.ElementAtOrDefault(i)};

                    var sum = (item.D1 != null ? item.D1.Didgit : 0)
                        + (item.D2 != null ? item.D2.Didgit : 0) + oveflow;
                    var newDidgit = (byte)(sum % 10);
                    result.AddDidgitToBack(newDidgit);
                    oveflow = (byte)(sum / 10);
                }

                if (oveflow != 0)
                    result.AddDidgitToBack((byte)oveflow);

                return result;
            }

            public override string ToString()
            {
                var result = "";

                foreach (var c in IterateFromBack().Reverse())
                    result += (char)(c.Didgit + (byte)'0');

                return result;
            }

           
        }


    }
}
