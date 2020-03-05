using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace toDoList
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAddToDo_Click(object sender, EventArgs e)
        {
            string newItem = txtNewToDo.Text.Trim();

            if (!String.IsNullOrWhiteSpace(newItem))
            {
                if (clsToDo.Items.Contains(newItem))
                {
                    MessageBox.Show("You already added that item", "Error");
                }
                else
                {
                    clsToDo.Items.Add(newItem);
                    txtNewToDo.Text = "";
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {//make a new list
            List<string> doneItems = new List<string>();

            //copy all checked items to new list
            foreach (string item in clsToDo.CheckedItems)
            {
                doneItems.Add(item);
            }
            foreach (string item in doneItems)
            {
                clsToDo.Items.Remove(item);
                lstDone.Items.Add(item);
            }
        }
    }
}
