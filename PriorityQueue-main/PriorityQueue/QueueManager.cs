﻿using System;
using System.Windows.Forms;

namespace PriorityQueue
{
    public partial class QueueManager : Form
    {
        PriorityQueue<Person> queue;

        public QueueManager()
        {
            InitializeComponent();

            // Hide control panels until an interface is selected
            Panel_Add.Visible = false;
            Panel_Actions.Visible = false;
            Panel_Output.Visible = false;            
        }

        private void CB_Implementation_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            Panel_Add.Visible = true;
            Panel_Actions.Visible = true;
            Panel_Output.Visible = true;

            switch (CB_Implementation.SelectedIndex)
            {
                case 0:
                    InitSortedArrayQueue();
                    break;
                case 1:
                    InitUnorderedArrayQueue();
                    break;
                case 2:
                    InitUnorderedLinkedQueue();
                    break;
                case 3:
                    InitSortedLinkedQueue();
                    break;
                case 4:
                    InitHeapQueue();
                    break;
            }

        }
        
        private void InitSortedArrayQueue()
        {
            queue = new SortedArrayPriorityQueue<Person>(8);
            Lbl_Output.Text = "New sorted array priority queue created";
        }

        private void InitUnorderedArrayQueue()
        {
            queue = new UnorderedArrayPriorityQueue<Person>(8);
            Lbl_Output.Text = "New unordered array priority queue created";
        }

        private void InitUnorderedLinkedQueue()
        {
            queue = new UnorderedLinkedPriorityQueue<Person>();
            Lbl_Output.Text = "New unordered linked priority queue created";
        }

        private void InitSortedLinkedQueue()
        {
            queue = new SortedLinkedPriorityQueue<Person>();
            Lbl_Output.Text = "New sorted linked priority queue created";
        }
        private void InitHeapQueue()
        {
            queue = new HeapPriorityQueue<Person>(8);
            Lbl_Output.Text = "New heap priority queue created";
        }


        private void Btn_AddQueue_Click(object sender, System.EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(Txt_Person.Text) == false)
            {
                Person person = new Person(Txt_Person.Text);
                int priority = (int)Num_Priority.Value;
                try
                {
                    queue.Add(person, priority);
                    Lbl_Output.Text = "Added " + person.ToString();
                } 
                catch(QueueOverflowException exception)
                {
                    Lbl_Output.Text = exception.Message;
                }

                return;
            }
            Lbl_Output.Text = "Please include name for new priority queue item";
        }

        private void Btn_Peek_Click(object sender, EventArgs e)
        {
            try
            {
                string name = queue.Head().ToString();
                Lbl_Output.Text = "The person at the head of the queue is " + name;
            }
            catch (QueueUnderflowException exception)
            {
                Lbl_Output.Text = exception.Message;
            }
        }

        private void Btn_Remove_Click(object sender, EventArgs e)
        {
            try
            {
                string name = queue.Head().ToString();
                queue.Remove();
                Lbl_Output.Text = $"Removed {name} from queue";
            }
            catch (QueueUnderflowException exception)
            {
                Lbl_Output.Text = exception.Message;
            }
        }

        private void Btn_IsEmpty_Click(object sender, EventArgs e)
        {
            Lbl_Output.Text = queue.IsEmpty() ? "The queue is empty" : "The queue is NOT empty";
        }

        private void Btn_Print_Click(object sender, EventArgs e)
        {
            try
            {
                Lbl_Output.Text = queue.ToString();
            }
            catch (QueueUnderflowException exception)
            {
                Lbl_Output.Text = exception.Message;
            }
        }
    }
}
