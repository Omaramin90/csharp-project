using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
using MySql.Data;
using MySql.Data.MySqlClient;

namespace PIZZAAPP3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        double size_price = 0.00;
        double crust_price = 0.00;
        double toppings_price = 0.00;
        double sides_price = 0.00;
        int selected_toppings = 0;
        string Size = "";
        string Crust = "";
        string Toppings = "";
        string Sides = "";
       

        

        public MainWindow()
        {
            InitializeComponent();
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void rbSmall_Checked(object sender, RoutedEventArgs e)
        {

            if (rbSmall.IsChecked == true)
            {
                size_price = 4.99;
                Size = "small";
            }
            taxes();
        }


        private void rbMed_Checked(object sender, RoutedEventArgs e)
        {
            if (rbMed.IsChecked == true)
            {
                size_price = 9.99;
                Size = "Medium";
            }
            taxes();
        }

        private void rbLarge_Checked(object sender, RoutedEventArgs e)
        {
            if (rbLarge.IsChecked == true)
            {
                size_price = 14.99;
                Size = "Large";
            }
            taxes();
        }

        private void rbXL_Checked(object sender, RoutedEventArgs e)
        {
            if (rbXL.IsChecked == true)
            {
                size_price = 19.99;
                Size = "Extra Large";
            }
            taxes();
        }

        private void rbThin_Checked(object sender, RoutedEventArgs e)
        {
            if (rbThin.IsChecked == true)
            {
                crust_price = 0.99;
                Crust = "Thin";
            }
            taxes();
        }

        private void rbThick_Checked(object sender, RoutedEventArgs e)
        {
            if (rbThick.IsChecked == true)
            {
                crust_price = 1.99;
                Crust = "Thick";
            }
            taxes();
        }

        private void cbPop_Checked(object sender, RoutedEventArgs e)
        {
            if (cbPop.IsChecked == true)
            {
                sides_price += 1.50;
                Sides = string.Concat(Sides, "Pop, ");
            }
            else
            {
                sides_price -= 1.50;
            }
            taxes();
        }

        private void cbChickenWings_Checked(object sender, RoutedEventArgs e)
        {
            if (cbChickenWings.IsChecked == true)
            {
                sides_price += 7.99;
                Sides = string.Concat(Sides, "ChickenWings, ");
            }
            else
            {
                sides_price -= 7.99;
            }
            taxes();
        }

        private void cbGarlicBread_Checked(object sender, RoutedEventArgs e)
        {
            if (cbGarlicBread.IsChecked == true)
            {
                sides_price += 4.99;
                Sides = string.Concat(Sides, "GarlicBread, ");
            }
            else
            {
                sides_price -= 4.99;
            }
            taxes();
        }

        private void cbFries_Checked(object sender, RoutedEventArgs e)
        {
            if (cbFries.IsChecked == true)
            {
                sides_price += 3.99;
                Sides = string.Concat(Sides, "Fries, ");
            }
            else
            {
                sides_price -= 3.99;
            }
            taxes();
        }

        private void cbWedges_Checked(object sender, RoutedEventArgs e)
        {
            if (cbWedges.IsChecked == true)
            {
                sides_price += 6.99;
                Sides = string.Concat(Sides, "Wedges, ");
            }
            else
            {
                sides_price -= 6.99;
            }
            taxes();
        }


        private void cbPineapple_Checked(object sender, RoutedEventArgs e)
        {
            if (cbPineapple.IsChecked == true)
            {
                selected_toppings++;
                if (selected_toppings > 3)
                {
                    toppings_price += 0.50;
                    Toppings = string.Concat(Toppings, "Pineapple, ");
                }

            }
            else
            {
                selected_toppings--;
                if (selected_toppings >= 3)
                {
                    toppings_price -= 0.50;
                }
            }
            taxes();
        }

        private void cbChicken_Checked(object sender, RoutedEventArgs e)
        {
            if (cbChicken.IsChecked == true)
            {
                selected_toppings++;
                if (selected_toppings > 3)
                {
                    toppings_price += 0.50;
                    Toppings = string.Concat(Toppings, "Chicken, ");
                }

            }
            else
            {
                selected_toppings--;
                if (selected_toppings >= 3)
                {
                    toppings_price -= 0.50;
                }
            }
            taxes();
        }

        private void cbBeef_Checked(object sender, RoutedEventArgs e)
        {
            if (cbBeef.IsChecked == true)
            {
                selected_toppings++;
                if (selected_toppings > 3)
                {
                    toppings_price = 0.50;
                    Toppings = string.Concat(Toppings, "Beef, ");
                }

            }
            else
            {
                selected_toppings--;
                if (selected_toppings >= 3)
                {
                    toppings_price -= 0.50;
                }
            }
            taxes();
        }

        private void cbOnion_Checked(object sender, RoutedEventArgs e)
        {
            if (cbOnion.IsChecked == true)
            {
                selected_toppings++;
                if (selected_toppings > 3)
                {
                    toppings_price += 0.50;
                    Toppings = string.Concat(Toppings, "Onions, ");
                }
            }
            else
            {
                selected_toppings--;
                if (selected_toppings >= 3)
                {
                    toppings_price -= 0.50;
                }
            }
            taxes();
        }

        private void cbGreenPepper_Checked(object sender, RoutedEventArgs e)
        {
            if (cbGreenPepper.IsChecked == true)
            {
                selected_toppings++;
                if (selected_toppings > 3)
                {
                    toppings_price += 0.50;
                    Toppings = string.Concat(Toppings, "GreenPepper, ");
                }
            }
            else
            {
                selected_toppings--;
                if (selected_toppings >= 3)
                {
                    toppings_price -= 0.50;
                }
            }
            taxes();
        }


        private void cbTomato_Checked(object sender, RoutedEventArgs e)
        {
            if (cbTomato.IsChecked == true)
            {
                selected_toppings++;
                if (selected_toppings > 3)
                {
                    toppings_price += 0.50;
                    Toppings = string.Concat(Toppings, "Tomato, ");
                }

            }
            else
            {
                selected_toppings--;
                if (selected_toppings >= 3)
                {
                    toppings_price -= 0.50;
                }
            }
            taxes();
        }


        public double calculate_total()
        {

            return size_price + crust_price + toppings_price + sides_price;
        }

        public void taxes()
        {
            double tax = 0.13 * Math.Round(calculate_total(), 2);

            lblTotal1.Content = Math.Round(calculate_total(), 2);

            lblTax.Content = "Tax $" + Math.Round(tax, 2);

            lblGrandTotal.Content = "Grand Total $" + (Math.Round(calculate_total() + tax, 2));
        }

        private void placeorder_Click(object sender, RoutedEventArgs e)
        {
            double Tax = 0.13 * Math.Round(calculate_total(), 2);

            double Total = Math.Round(calculate_total(), 2);

            double GrandTotal = (Math.Round(calculate_total() + Tax, 2));

            string connectionString = "datasource=localhost;port=3306;username=root;password=password;database=assignment;";
            string query = "INSERT INTO orders(`idOrders`,`Size`, `Crust`, `Toppings`, `Sides`, `Total`, `Tax`, `GrandTotal`) VALUES (NULL,'" + Size + "' , '" + Crust + "', '" + Toppings + "', '" + Sides + "', '" + Total + "', '" + Tax + "', '" + GrandTotal + "')";

                MySqlConnection databaseConnection = new MySqlConnection(connectionString);
                MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
                commandDatabase.CommandTimeout = 60;

                try
                {
                    databaseConnection.Open();
                    MySqlDataReader myReader = commandDatabase.ExecuteReader();

                    MessageBox.Show("Order successfully placed. Thank you for your business!");

                    databaseConnection.Close();
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);

                }
            }
        }
    }












