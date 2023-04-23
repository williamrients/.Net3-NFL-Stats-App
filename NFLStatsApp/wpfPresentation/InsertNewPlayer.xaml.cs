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
    /// Interaction logic for InsertNewPlayer.xaml
    /// </summary>
    public partial class InsertNewPlayer : Window
    {
        private PlayerManager _playerManager = new PlayerManager();

        public InsertNewPlayer()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            string firstName = txtFirstName.Text;
            string lastName = txtLastName.Text;
            string yearDrafted = txtYearDrafted.Text;

            if (firstName == "")
            {
                MessageBox.Show("Please enter players first name.");
                txtFirstName.Focus();
                txtFirstName.SelectAll();
                return;
            }

            if (firstName.Length > 50)
            {
                MessageBox.Show("First name cannot be more than 50 characters.");
                txtFirstName.Focus();
                txtFirstName.SelectAll();
                return;
            }

            if (lastName == "")
            {
                MessageBox.Show("Please enter players last name.");
                txtLastName.Focus();
                txtLastName.SelectAll();
                return;
            }

            if (lastName.Length > 50)
            {
                MessageBox.Show("Last name cannot be more than 50 characters.");
                txtLastName.Focus();
                txtLastName.SelectAll();
                return;
            }

            if (yearDrafted == "")
            {
                MessageBox.Show("Please enter players year drafted.");
                txtYearDrafted.Focus();
                txtYearDrafted.SelectAll();
                return;
            }

            if (yearDrafted.Length != 4)
            {
                MessageBox.Show("Please enter a 4 digit year.");
                txtYearDrafted.Focus();
                txtYearDrafted.SelectAll();
                return;
            }

            string newFirstName = UpperCaseFirstLetter(firstName);
            string newLastName = UpperCaseFirstLetter(lastName);

            try
            {
                if (_playerManager.InsertNewPlayer(newFirstName, newLastName, yearDrafted))
                {
                    this.DialogResult = true;
                }
                else
                {
                    MessageBox.Show("Adding player failed.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Update Failed." + "\n\n" + ex.InnerException.Message);
            }

        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("All player information added will be lost.",
                                                "Cancel Insert?", MessageBoxButton.YesNo,
                                                MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                this.DialogResult = false;
            }
        }

        private void frmInsertNewPlayer_Loaded(object sender, RoutedEventArgs e)
        {
            txtFirstName.Focus();
            btnSave.IsDefault = true;
        }

       private string UpperCaseFirstLetter(string str)
        {
            if (string.IsNullOrEmpty(str))
                return string.Empty;
            return char.ToUpper(str[0]) + str.Substring(1).ToLower();
        }

    }
}
