using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectThree
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.Items.AddRange(new string[]
    {
        "Food & Dining",
        "Transportation",
        "Utilities",
        "Rent",
        "Entertainment",
        "Health & Fitness",
        "Shopping",
        "Education",
        "Travel",
        "Miscellaneous"
    });
            
        }
        List<Expense> expenseList = new List<Expense>();
        private void button1_Click(object sender, EventArgs e)
        {
            //  Get the selected date
            DateTime selectedDate = dateTimePicker1.Value;

            //  Validate description (TextBox1)
            string description = textBox1.Text.Trim();
            int wordCount = description.Split(new[] { ' ', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries).Length;

            if (string.IsNullOrWhiteSpace(description) || wordCount > 100 || !Regex.IsMatch(description, @"^[a-zA-Z\s]+$"))
            {
                MessageBox.Show("Please enter a valid alphabetical description (max 100 words).");
                return;
            }

            // Validate amount (TextBox2)
            if (!decimal.TryParse(textBox2.Text.Trim(), out decimal amount) || amount <= 0)

            // Validate category (ComboBox1)
            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Please select a category.");
                return;
            }

            string category = comboBox1.SelectedItem.ToString();

            // Create expense object
            Expense newExpense = new Expense(description, amount, selectedDate, category);

            // Add to list and refresh DataGridView
            expenseList.Add(newExpense); // expenseList is your List<Expense>
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = expenseList;
        }
    
    }
}
