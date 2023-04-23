using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;

namespace LogicLayerInterfaces
{
    public interface IUsermanager
    {
        bool FindUser(string email);
        List<string> RetrievAllRoles();
        Users Loginuser(string email, string password);
        string Hashsha256(string source);
        bool Resetpassword(Users users, string email, string password, string oldPassword);
        List<Users> GetAllUsersByActive(bool active);
        bool InsertNewUserAndRole(string firstName, string lastName, string phone, string email, string roleID);
        int RetrieveUserIDFromEmail(string email);
        bool AddUser(Users User);
        bool DeleteFromRole(int userID, string role);
        bool CreateUserRole(int userID, string role);
    }
}
