using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for InsertNewPlayerStat.xaml
    /// </summary>
    public partial class InsertNewPlayerStat : Window
    {
        private int _selectedPlayerStat;
        private Stats _stats;
        private PlayerStatManager _playerStatManager = new PlayerStatManager();

        public InsertNewPlayerStat(PlayerStatManager playerStatManager, int selectedPlayerStats)
        {
            InitializeComponent();
            _selectedPlayerStat = selectedPlayerStats;
            _playerStatManager = playerStatManager;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txtPlayerID.Text = _selectedPlayerStat.ToString();
            txtPlayerID.IsEnabled = false;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            string playerID = txtPlayerID.Text;
            string statName = cmbStat.Text;
            string seasonID = cmbSeason.Text;
            string statAmount = txtStatAmount.Text;


            if (!playerID.All(char.IsDigit))
            {
                MessageBox.Show("Player ID can only contain numbers.");
                txtPlayerID.Focus();
                return;
            }

            if (playerID == "")
            {
                MessageBox.Show("Player ID is required.");
                txtPlayerID.Focus();
                return;
            }

            if (string.IsNullOrEmpty(statName))
            {
                MessageBox.Show("Please select a type of stat.");
                return;
            }

            if (string.IsNullOrEmpty(seasonID))
            {
                MessageBox.Show("Please select a season.");
                return;
            }

            if (!statAmount.All(char.IsDigit))
            {
                MessageBox.Show("Stat amount can only contain numbers.");
                txtStatAmount.Focus();
                return;
            }

            if (statAmount == "")
            {
                MessageBox.Show("Stat amount is required.");
                txtStatAmount.Focus();
                return;
            }

            int newPlayerID = Int32.Parse(playerID);
            double newStatAmount = Double.Parse(statAmount);

           

            try
            {
                _stats.PlayerID = newPlayerID;
                _stats.StatName = statName;
                _stats.SeasonID = seasonID;
                _stats.StatAmount = newStatAmount;

                if (_playerStatManager.InsertNewPlayerStat(_stats))
                {
                    this.DialogResult = true;
                }
                else
                {
                    MessageBox.Show("Adding players stat failed.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Insert Failed." + "\n\n" + ex.InnerException.Message);
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
    }
}
