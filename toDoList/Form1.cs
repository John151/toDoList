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
                    //Use Add to add new item to end of items collection
                    DateTime todoCreated = DateTime.Now;
                    bool urgent = chkUrgent.Checked;

                    // Format the text, date/time created and urgent into one string
                    string todoText = $"{newItem} - Created at {todoCreated:g}";
                    if (urgent)
                    {
                        todoText += " URGENT!";
                    }
                    // add to the ListBox items
                    clsToDo.Items.Add(todoText);
                    txtNewToDo.Text = "";

                    //clear inputs
                    txtNewToDo.Text = "";
                    chkUrgent.Checked = false;
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
