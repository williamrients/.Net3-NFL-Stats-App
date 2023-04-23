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
using System.Windows.Shapes;
using DataObjects;
using LogicLayer;
using LogicLayerInterfaces;

namespace wpfPresentation
{
    /// <summary>
    /// Interaction logic for InsertNewUserAndRole.xaml
    /// </summary>
    public partial class InsertNewUserAndRole : Window
    {
        private Usermanager _userManager = new Usermanager();
        public InsertNewUserAndRole()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            string firstName = txtFirstName.Text;
            string lastName = txtLastName.Text;
            string phone = txtPhone.Text;
            string email = txtEmail.Text;
            string role = txtRole.Text;
            txtRole.IsEnabled = false;
            

            if (firstName.Any(char.IsDigit))
            {
                MessageBox.Show("Your first name cannot contain numbers.");
                txtFirstName.Focus();
                return;
            }

            if (firstName == "")
            {
                MessageBox.Show("Please enter your first name.");
                txtFirstName.Focus();
                return;
            }

            if (lastName.Any(char.IsDigit))
            {
                MessageBox.Show("Your last name cannot contain numbers.");
                txtLastName.Focus();
                return;
            }

            if (lastName == "")
            {
                MessageBox.Show("Please enter your last name.");
                txtLastName.Focus();
                return;
            }

            if (!phone.All(char.IsDigit))
            {
                MessageBox.Show("Your phone number cannot contain letters.");
                txtPhone.Focus();
                return;
            }

            if (phone == "")
            {
                MessageBox.Show("Please enter your phone number.");
                txtPhone.Focus();
                return;
            }

            if (email == "")
            {
                MessageBox.Show("Please enter your email.");
                txtEmail.Focus();
                return;
            }

            string newFirstName = UpperCaseFirstLetter(firstName);
            string newLastName = UpperCaseFirstLetter(lastName);

            try
            {
                if (_userManager.InsertNewUserAndRole(firstName, lastName, phone, email, role))
                {
                    this.DialogResult = true;
                }
                else
                {
                    MessageBox.Show("Adding user failed.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Insert Failed." + "\n\n" + ex.InnerException.Message);
            }

        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("All user information enterd will be lost.",
                                                "Cancel Insert?", MessageBoxButton.YesNo,
                                                MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                this.DialogResult = false;
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            btnSave.IsDefault = true;
            txtRole.IsEnabled = false;
        }

        private string UpperCaseFirstLetter(string str)
        {
            if (string.IsNullOrEmpty(str))
                return string.Empty;
            return char.ToUpper(str[0]) + str.Substring(1).ToLower();
        }

    }
}
