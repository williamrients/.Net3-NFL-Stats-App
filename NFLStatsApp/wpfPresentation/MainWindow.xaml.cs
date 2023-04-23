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
using System.Windows.Navigation;
using System.Windows.Shapes;
using DataObjects;
using LogicLayer;
using LogicLayerInterfaces;

namespace wpfPresentation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Users _users = null;
        private List<Users> _user = null;
        private List<Players> _players = null;
        private List<Teams> _teams = null;
        private List<Stats> _stats = null;
        private TeamManager _teamManager = new TeamManager();
        private PlayerManager _playerManager = new PlayerManager();
        private PlayerStatManager _playerStatManager = new PlayerStatManager();
        private Usermanager _userManager = new Usermanager();
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (btnLogin.Content.ToString() == "Log Out")
            {
                _users = null;
                updateUIforlogout();
                return;
            }
            Usermanager usermanager = new Usermanager();
            string email = txtEmail.Text;
            string password = txtPassword.Password;
            if (email.Length < 6)
            {
                MessageBox.Show("Invalid email address.");
                txtEmail.Text = "";
                txtEmail.Focus();
                return;
            }
            if (password == "")
            {
                MessageBox.Show("You must enter a password.");
                txtPassword.Focus();
                return;
            }
            try
            {
                _users = usermanager.Loginuser(email, password);

                if (txtPassword.Password == "newuser")
                {
                    var passworWindow = new UpdatePasswordWindow(_users, usermanager, true);

                    if ((bool)passworWindow.ShowDialog())
                    {
                        MessageBox.Show("Password Updated.");
                    }
                    else
                    {
                        MessageBox.Show("Update failed. Goodbye");
                        _users = null;
                        txtEmail.Clear();
                        txtPassword.Clear();
                        updateUIforlogout();
                        return;
                    }
                }

                showTabsForUsers();

                updateUIforUsers();
                btnNewUser.Visibility = Visibility.Hidden;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\n" + ex.InnerException.Message);
            }
            //btnAddPlayer.Visibility = Visibility.Visible;
            //btnAddPlayerStat.Visibility = Visibility.Visible;
        }

        private void updateUIforUsers()
        {
            string rolesList = "";
            for (int i = 0; i < _users.Role.Count; i++)
            {
                rolesList += " " + _users.Role[i];
                if (i == _users.Role.Count - 2)
                {
                    if (_users.Role.Count > 2)
                    {
                        rolesList += ",";
                    }
                    rolesList += " and";
                }
                else if (i < _users.Role.Count - 2)
                {
                    rolesList += ",";
                }
            }
            lblGreeting.Content = "Welcom, " + _users.GivenName + " " + _users.FamilyName + " You are logged in as: " + rolesList + ".";
            statMessage.Content = "Logged in on " + DateTime.Now.ToLongDateString() + ", at " + DateTime.Now.ToShortTimeString() + 
                ". Please remember to log out before you leave.";
            txtEmail.Text = "";
            txtPassword.Password = "";
            txtEmail.Visibility = Visibility.Hidden;
            txtPassword.Visibility = Visibility.Hidden;
            lblEmail.Visibility = Visibility.Hidden;
            lblPassword.Visibility = Visibility.Hidden;
            btnLogin.Content = "Log Out";
            btnLogin.IsDefault = false;
        }

        private void showTabsForUsers()
        {
            foreach (var role in _users.Role)
            {
                switch (role)
                {
                    case "Admin":
                        tabHome.Visibility = Visibility.Visible;
                        tabAllPlayers.Visibility = Visibility.Visible;
                        tabAllTeams.Visibility = Visibility.Visible;
                        tabPlayerStats.Visibility = Visibility.Visible;
                        tabAllUsers.Visibility = Visibility.Visible;
                        break;
                    case "StatAdjuster":
                        tabHome.Visibility = Visibility.Visible;
                        tabAllPlayers.Visibility = Visibility.Visible;
                        tabAllTeams.Visibility = Visibility.Visible;
                        tabPlayerStats.Visibility = Visibility.Visible;
                        btnAddPlayer.Visibility = Visibility.Visible;
                        btnAddPlayerStat.Visibility = Visibility.Visible;
                        break;
                    case "GeneralUser":
                        tabHome.Visibility = Visibility.Visible;
                        tabAllPlayers.Visibility = Visibility.Visible;
                        tabAllTeams.Visibility = Visibility.Visible;
                        tabPlayerStats.Visibility = Visibility.Visible;
                        break;
                }
                pnlTabs.Visibility = Visibility.Visible;
            }
        }

        private void updateUIforlogout()
        {
            hideAllUserTabs();
            btnLogin.IsDefault = true;

            lblGreeting.Content = "You are not logged in";
            statMessage.Content = "Welcome. Please log in to continue";

            txtEmail.Visibility = Visibility.Visible;
            txtPassword.Visibility = Visibility.Visible;
            lblEmail.Visibility = Visibility.Visible;
            lblPassword.Visibility = Visibility.Visible;

            btnLogin.Content = "Login";
            btnLogin.IsDefault = true;

            txtEmail.Focus();

            btnAddPlayer.Visibility = Visibility.Hidden;
            btnAddPlayerStat.Visibility = Visibility.Hidden;
            btnNewUser.Visibility = Visibility.Visible;
        }

        private void hideAllUserTabs()
        {
            pnlTabs.Visibility = Visibility.Hidden;
            foreach (var tab in tabsetMain.Items)
            {
                ((TabItem)tab).Visibility = Visibility.Collapsed;
            }
            btnAddPlayer.Visibility = Visibility.Hidden;
            btnAddPlayerStat.Visibility = Visibility.Hidden;
        }

        private void frmMain_Loaded(object sender, RoutedEventArgs e)
        {
            updateUIforlogout();

            try
            {
                _players = _playerManager.GetAllPlayersByActive(true);
                _teams = _teamManager.GetAllTeamsByActive(true);
                _stats = _playerStatManager.GetAllPlayerStatsByActive(true);
                _user = _userManager.GetAllUsersByActive(true);
            }
            catch (Exception)
            {

                throw;
            }

        }

        private void tabAllPlayers_GotFocus(object sender, RoutedEventArgs e)
        {

            datAllPlayers.ItemsSource = _players;
            playerHeaders();

            if (_players == null)
            {
                try
                {
                    _players = _playerManager.GetAllPlayersByActive(IsActive);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + "\n\n" + ex.InnerException.Message);
                }
            }
        }

        private void playerHeaders()
        {
            try
            {
                datAllPlayers.Columns[0].Header = "Player ID";
                datAllPlayers.Columns[1].Header = "First Name";
                datAllPlayers.Columns[2].Header = "Last Name";
                datAllPlayers.Columns[3].Header = "Year Drafted";
                datAllPlayers.Columns[4].Header = "Active";
            }
            catch (ArgumentOutOfRangeException) { }
        }

        private void tabAllTeams_GotFocus(object sender, RoutedEventArgs e)
        {
            datAllTeams.ItemsSource = _teams;
            teamHeaders();

            if (_teams == null)
            {
                try
                {
                    _teams = _teamManager.GetAllTeamsByActive(IsActive);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + "\n\n" + ex.InnerException.Message);
                }
            }
        }

        private void teamHeaders()
        {
            try
            {
                datAllTeams.Columns[0].Header = "Team Name";
                datAllTeams.Columns[1].Header = "Mascot";
                datAllTeams.Columns[2].Header = "City";
                datAllTeams.Columns[3].Header = "State";
                datAllTeams.Columns[4].Header = "Active";
            }
            catch (ArgumentOutOfRangeException) { }
        }

        private void tabPlayerStats_GotFocus(object sender, RoutedEventArgs e)
        {
            datAllPlayerStats.ItemsSource = _stats;
            playerStatHeaders();

            if (_stats == null)
            {
                try
                {
                    _stats = _playerStatManager.GetAllPlayerStatsByActive(IsActive);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + "\n\n" + ex.InnerException.Message);
                }
            }
        }

        private void playerStatHeaders()
        {
            try
            {
                datAllPlayerStats.Columns[0].Header = "Player ID";
                datAllPlayerStats.Columns[1].Header = "First Name";
                datAllPlayerStats.Columns[2].Header = "Last Name";
                datAllPlayerStats.Columns[3].Header = "Active";
                datAllPlayerStats.Columns[4].Header = "Stat Name";
                datAllPlayerStats.Columns[5].Header = "Stat Amount";
            }
            catch (ArgumentOutOfRangeException) { }
        }

        private void mnuChangePassword_Click(object sender, RoutedEventArgs e)
        {
            if (_users == null)
            {
                return;
            }

            var userManager = new Usermanager();
            var passwordWindow = new UpdatePasswordWindow(_users, userManager);

            if ((bool)passwordWindow.ShowDialog())
            {
                MessageBox.Show("Password Updated.");
            }
            else
            {
                MessageBox.Show("Update failed");
            }

        }

        private void tabAllPlayers_LostFocus(object sender, RoutedEventArgs e)
        {
            //btnAddPlayer.Visibility = Visibility.Hidden;
            //btnAddPlayerStat.Visibility = Visibility.Hidden;
        }

        private void btnAddPlayer_Click(object sender, RoutedEventArgs e)
        {
            var insertNewPlayerWindow = new InsertNewPlayer();
           
            if ((bool)insertNewPlayerWindow.ShowDialog())
            {
                MessageBox.Show("Player Added");

                try
                {
                    _players = _playerManager.GetAllPlayersByActive(IsActive);
                    datAllPlayers.ItemsSource = _players;
                    playerHeaders();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + "\n\n" + ex.InnerException.Message);
                }
            }
            else
            {
                MessageBox.Show("Adding player failed.");
            }

        }

        private void btnAddPlayerStat_Click(object sender, RoutedEventArgs e)
        {
            if (datAllPlayers.SelectedItems.Count > 0)
            {
                Players selectedPlayer = (Players)datAllPlayers.SelectedItem as Players;
                int _playerID = selectedPlayer.PlayerID;
                var insertNewPlayerStatWindow = new InsertNewPlayerStat(_playerStatManager, _playerID);
                if ((bool)insertNewPlayerStatWindow.ShowDialog())
                {
                    MessageBox.Show("Players stat added.");

                    try
                    {
                        _stats = _playerStatManager.GetAllPlayerStatsByActive(IsActive);
                        datAllPlayerStats.ItemsSource = _stats;
                        playerStatHeaders();
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message + "\n\n" + ex.InnerException.Message);
                    }

                }
                else
                {
                    MessageBox.Show("Adding player stat failed.");
                }
            }
            else
            {
                MessageBox.Show("Please select a player first.", "Select someone", MessageBoxButton.OK);
            }
            
        }

        private void tabAllUsers_GotFocus(object sender, RoutedEventArgs e)
        {
            datAllUsers.ItemsSource = _user;
            userHeader();

            if (_user == null)
            {
                try
                {
                    _user = _userManager.GetAllUsersByActive(IsActive);
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + "\n\n" + ex.InnerException.Message);
                }
            }
        }

        private void userHeader()
        {
            try
            {
                datAllUsers.Columns[5].Visibility = Visibility.Hidden;
                datAllUsers.Columns[7].Visibility = Visibility.Hidden;
                datAllUsers.Columns[0].Header = "User ID";
                datAllUsers.Columns[1].Header = "First Name";
                datAllUsers.Columns[2].Header = "Last Name";
                datAllUsers.Columns[3].Header = "Phone Number";
                datAllUsers.Columns[4].Header = "Email";
                datAllUsers.Columns[6].Header = "Role";
            }
            catch (ArgumentOutOfRangeException) { }
        }

        private void btnNewUser_Click(object sender, RoutedEventArgs e)
        {
            var insertNewUserAndRole = new InsertNewUserAndRole();

            if ((bool)insertNewUserAndRole.ShowDialog())
            {
                MessageBox.Show("Success! Please login, your default password is 'newuser'");
                _user = _userManager.GetAllUsersByActive(IsActive);
                datAllUsers.ItemsSource = _user;
                userHeader();
            }
            else
            {
                MessageBox.Show("Failed to add new user.");
            }
        }

        private void mnuExit_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("End the program?",
                                                "Leave?", MessageBoxButton.YesNo,
                                                MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                this.Close();
            }
        }

        private void mnuAbout_Click(object sender, RoutedEventArgs e)
        {
            var aboutPage = new AboutWindow();
            aboutPage.ShowDialog();
        }
    }
}
