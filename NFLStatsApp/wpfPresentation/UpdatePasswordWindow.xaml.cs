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

namespace wpfPresentation
{
    /// <summary>
    /// Interaction logic for UpdatePasswordWindow.xaml
    /// </summary>
    public partial class UpdatePasswordWindow : Window
    {
        Users _users = null;
        Usermanager _userManager = null;
        bool _newUser = false;
        public UpdatePasswordWindow(Users users, Usermanager userManager, bool newUser = false)
        {
            _users = users;
            _userManager = userManager;
            _newUser = newUser;

            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            btnSubmit.IsDefault = true;

            if (_newUser)
            {
                txtInstructions.Text = "This is your first login You must update your password\nor be logged out.";
                txtEmail.Text = _users.Email;
                txtEmail.IsEnabled = false;
                txtOldPassword.Password = "newuser";
                txtOldPassword.IsEnabled = false;
                txtNewPassword.Focus();
            }
            else
            {
                txtInstructions.Text = "Please fill out all fields to change your password.";
                txtEmail.Focus();
            }
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            string email = txtEmail.Text;
            string oldPassword = txtOldPassword.Password;
            string newPassword = txtNewPassword.Password;
            string confirmPassword = txtConfirmPassword.Password;

            if (email == "")
            {
                MessageBox.Show("Please enter your email.");
                txtEmail.Focus();
                txtEmail.SelectAll();
                return;
            }

            if (oldPassword == "")
            {
                MessageBox.Show("Please enter your current password.");
                txtOldPassword.Focus();
                txtOldPassword.SelectAll();
                return;
            }

            if (newPassword == "")
            {
                MessageBox.Show("Please enter your new password.");
                txtNewPassword.Focus();
                txtNewPassword.SelectAll();
                return;
            }

            if (newPassword == "newuser" || newPassword == oldPassword)
            {
                MessageBox.Show("Your new password cannot be a past password.\nPick a new password.");
                txtNewPassword.Clear();
                txtConfirmPassword.Clear();
                txtNewPassword.Focus();
                return;
            }

            if (newPassword != confirmPassword)
            {
                MessageBox.Show("Your new password and confirm password do not match.");
                txtNewPassword.Clear();
                txtConfirmPassword.Clear();
                txtNewPassword.Focus();
                return;
            }

            try
            {
                if (_userManager.Resetpassword(_users, email, newPassword, oldPassword))
                {
                    this.DialogResult = true;
                }
                else
                {
                    MessageBox.Show("Invalid email or password.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Update Failed." + "\n\n" + ex.InnerException.Message);
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            if (_newUser)
            {
                var result = MessageBox.Show("If you do not set a new passowrd you will be logged out.",
                                                "Cancel Update?", MessageBoxButton.YesNo,
                                                MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                    this.DialogResult = false;
                }
            }
            else
            {
                this.DialogResult = false;
            }
        }
    }
}
