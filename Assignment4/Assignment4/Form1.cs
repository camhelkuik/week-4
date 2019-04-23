using System;
using System.Windows.Forms;

namespace Assignment4
{
    public partial class Form1 : Form
    {
        string[,] beverages = { { "Soda", "1.95" }, { "Tea", "1.50" }, { "Coffee", "1.25" }, { "Mineral Water", "2.95" }, { "Juice", "2.50" }, { "Milk", "1.50" } };
        string[,] appetizers = { { "Buffalo Wings", "5.95" }, { "Buffalo Fingers", "6.95" }, { "Potato Skins", "8.95" }, { "Nachos", "8.95" }, { "Mushroom Caps", "10.95" },
            { "Shrimp Cocktail", "12.95" }, { "Chips and Salsa", "6.95" } };
        string[,] mainCourse = { { "Seafood Alfredo", "15.95" }, { "Chicken Alfredo", "13.95" }, { "Chicken Picatta", "13.95" }, { "Turkey Club", "11.95" }, { "Lobster Pie", "19.95" },
            { "Prime Rib", "20.95" }, { "Shrimp Scampi", "18.95" }, { "Turkey Dinner", "13.95" }, { "Stuffed Chicken", "14.95" } };
        string[,] desserts = { { "Apple Pie", "5.95" }, { "Sundae", "3.95" }, { "Carrot Cake", "5.95" }, { "Mud Pie", "4.95" }, { "Apple Crisp", "5.95" } };

        decimal subtotal = 0M;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Text = "Restaurant Bill Calculator Cameron Helkuik";
            LoadCategory("Beverage", comboBeverage);
            LoadCategory("Appetizer", comboAppetizer);
            LoadCategory("Main Course", comboMain);
            LoadCategory("Dessert", comboDessert);
            lblSubtotal.Text = "$0.00";
            lblTax.Text = "$0.00";
            lblTotal.Text = "$0.00";
        }

        public void LoadCategory(string categoryString, ComboBox categoryCombo)
        {
            string[,] items;

            switch (categoryString)
            {
                case "Beverage":
                    items = beverages;
                    break;
                case "Appetizer":
                    items = appetizers;
                    break;
                case "Main Course":
                    items = mainCourse;
                    break;
                default:
                    items = desserts;
                    break;
            }

            for (int i = 0; i <= items.GetUpperBound(0); i++)
            {
                categoryCombo.Items.Add(items[i, 0]);
            }
        }

        private void comboBeverage_SelectedIndexChanged(object sender, EventArgs e)
        {
            AddToSubtotal("Beverage", Convert.ToString(comboBeverage.SelectedItem));
        }

        private void comboAppetizer_SelectedIndexChanged(object sender, EventArgs e)
        {
            AddToSubtotal("Appetizer", Convert.ToString(comboAppetizer.SelectedItem));
        }

        private void comboMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            AddToSubtotal("Main Course", Convert.ToString(comboMain.SelectedItem));
        }

        private void comboDessert_SelectedIndexChanged(object sender, EventArgs e)
        {
            AddToSubtotal("Dessert", Convert.ToString(comboDessert.SelectedItem));
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            comboBeverage.Text = "";
            comboAppetizer.Text = "";
            comboMain.Text = "";
            comboDessert.Text = "";
            subtotal = 0M;
            lblSubtotal.Text = "$0.00";
            lblTax.Text = "$0.00";
            lblTotal.Text = "$0.00";

        }

        private void AddToSubtotal (string category, string name)
        {
            string[,] items;

            switch (category)
            {
                case "Beverage":
                    items = beverages;
                    break;
                case "Appetizer":
                    items = appetizers;
                    break;
                case "Main Course":
                    items = mainCourse;
                    break;
                default:
                    items = desserts;
                    break;
            }

            for (int i = 0; i <= items.GetUpperBound(0); i++)
            {

                if (items[i, 0] == name)
                {
                    subtotal += Convert.ToDecimal(items[i, 1]);
                }

                lblSubtotal.Text = string.Format("{0:C}", subtotal);

                decimal decTax = subtotal * 0.05M;

                lblTax.Text = string.Format("{0:C}", decTax);

                lblTotal.Text = string.Format("{0:C}", (subtotal + decTax));
            }
        }
    }
}
