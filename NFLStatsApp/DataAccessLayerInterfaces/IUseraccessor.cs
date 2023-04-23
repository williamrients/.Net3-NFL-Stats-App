using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;

namespace DataAccessLayerInterfaces
{
    public interface IUseraccessor
    {
        List<string> SelectAllRoles();
        int checkUserWithEmailAndPassword(string email, string passwordHash);
        Users SelectUsersByEmail(string email);
        List<string> SelectRolesByUserID(int userID);
        int UpdatePasswordHash(int userID, string passwordHash, string oldPasswordHash);
        List<Users> SelectUsersByActive(bool active);
        int InsertNewUserAndRole(string firstName, string lastName, string phone, string email, string roleID);
        int InsertNewUser(Users user);
        int DeleteUserRole(int userID, string role);
        int InsertUserRole(int userID, string role);
    }
}
