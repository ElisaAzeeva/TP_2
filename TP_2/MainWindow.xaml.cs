using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TP_2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DoublyLinlkedList Operand1 = new DoublyLinlkedList();
        DoublyLinlkedList Operand2 = new DoublyLinlkedList();
        DoublyLinlkedList Result = new DoublyLinlkedList();
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void Button_click(object sender, RoutedEventArgs e)
        {
            //magic constant
            int digitPlace = 10;
            //sorry about this code
            String operand1 = (Op1.Text).ToString();
            String operand2 = (Op2.Text).ToString();
            String temp1;
            String temp2;
            while ((operand1.Length > 0) || (operand1.Length > 0))
            {
                if ((operand1.Length >= (digitPlace - 1)) && (operand2.Length >= (digitPlace - 1)))
                {
                    temp1 = operand1.Substring(0, digitPlace - 1);
                    temp2 = operand2.Substring(0, digitPlace - 1);

                    Operand1.Add(Int64.Parse(temp1));
                    Operand2.Add(Int64.Parse(temp2));

                    operand1 = operand1.Remove(0, digitPlace - 1);
                    operand2 = operand2.Remove(0, digitPlace - 1);
                }
                
                else if (operand1.Length < (digitPlace - 1))
                {

                    Operand1.Add(Int64.Parse(operand1));
                    operand1=operand1.Remove(0, operand1.Length);

                }
                if (operand2.Length < (digitPlace - 1))
                {
                    Operand2.Add(Int64.Parse(operand2));
                    operand2=operand2.Remove(0, operand2.Length);
                }
            }


        }
    }


    public class DoublyLinlkedListItem
    {
        public long Data { get; set; }
        public DoublyLinlkedListItem Next { get; set; }
        public DoublyLinlkedListItem Previous { get; set; }
        //constructor
        public DoublyLinlkedListItem( long data)
        { Data = data; }
    }

    public class DoublyLinlkedList
    {
        DoublyLinlkedListItem head;
        DoublyLinlkedListItem tail;


        public void Add(long data)
        {
            DoublyLinlkedListItem item = new DoublyLinlkedListItem(data);
            if (head == null)
            {
                head = item;
            }
            else
            {
                item.Previous = tail;
                tail.Next = item;
                //
                
                //item.Next = tail;
            }
            tail = item;
        }

        public DoublyLinlkedList Sum(DoublyLinlkedList list1, DoublyLinlkedList list2)
        {
            DoublyLinlkedList result= new DoublyLinlkedList();
            long temp;
            //while(tail!=)
            //temp = list1.tail.Data + list2.tail.Data;
            //result.Add(temp);


            return result;
        }

    }


        /*
        unsafe struct DoublyLinlkedList
        {
            int data;
            long* next;
            long* prev;

        }


        unsafe public class DoublyLinlkedList
        {
            long* Next;
            long* Prev;
            long Data { get; set; }


            public DoublyLinlkedList(long data)
            {
                DoublyLinlkedList firstItem = new DoublyLinlkedList(data);
                firstItem.Data = data;
                firstItem.Next = null;
                firstItem.Prev = null;
            }

            public DoublyLinlkedList Add(long data)
            {
                DoublyLinlkedList currentItem = new DoublyLinlkedList(data);
                currentItem = Next;
                return (currentItem);
            }
        }
        */
    }
