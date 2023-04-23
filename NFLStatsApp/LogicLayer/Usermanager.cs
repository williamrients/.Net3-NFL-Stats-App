using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;
using LogicLayerInterfaces;
using DataAccessLayerInterfaces;
using DataAccessLayer;
using System.Security.Cryptography;

namespace LogicLayer
{
    public class Usermanager : IUsermanager
    {
        private IUseraccessor useraccessor = null;
        public Usermanager()
        {
            useraccessor = new Useraccessor();
        }

        public Usermanager(IUseraccessor ua)
        {
            useraccessor = ua;
        }

        public bool AddUser(Users User)
        {
            bool success = false;

            try
            {
                if (1 == useraccessor.InsertNewUser(User))
                {
                    success = true;
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Database Error", ex);
            }

            return success;
        }

        public bool FindUser(string email)
        {
            try
            {
                return useraccessor.SelectUsersByEmail(email) != null;
            }
            catch (ApplicationException ex)
            {
                if (ex.Message == "User not found.")
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Database Error", ex);
            }
        }

        public List<Users> GetAllUsersByActive(bool active)
        {
            List<Users> allUsers = null;

            try
            {
                allUsers = useraccessor.SelectUsersByActive(active);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Data not found.", ex);
            }

            return allUsers;
        }

        public string Hashsha256(string source)
        {
            string result = "";
            if (source == "" || source == null)
            {
                throw new ArgumentException("Missing input");
            }
            byte[] data;
            using (SHA256 sha256hasher = SHA256.Create())
            {
                data = sha256hasher.ComputeHash(Encoding.UTF8.GetBytes(source));
            }
            var s = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                s.Append(data[i].ToString("x2"));
            }
            result = s.ToString();
            result = result.ToLower();

            return result;
        }

        public bool InsertNewUserAndRole(string firstName, string lastName, string phone, string email, string roleID)
        {
            bool success = false;

            if (2 == useraccessor.InsertNewUserAndRole(firstName, lastName, phone, email, roleID))
            {
                success = true;
            }

            return success;
        }

        public Users Loginuser(string email, string password)
        {
            Users users = null;
            try
            {
                password = Hashsha256(password);
                if (1 == useraccessor.checkUserWithEmailAndPassword(email, password))
                {
                    users = useraccessor.SelectUsersByEmail(email);
                    users.Role = useraccessor.SelectRolesByUserID(users.UserID);
                }
                else
                {
                    throw new ApplicationException("User not found");
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Bad username or password", ex);
            }


            return users;
        }

        public bool DeleteFromRole(int userID, string role)
        {
            bool success = false;

            try
            {
                if (1 == useraccessor.DeleteUserRole(userID, role))
                {
                    success = true;
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Bad username or password", ex);
            }
            return success;
        }

        public bool Resetpassword(Users users, string email, string password, string oldPassword)
        {
            bool completed = false;
            password = Hashsha256(password);
            oldPassword = Hashsha256(oldPassword);

            if (users.Email != email)
            {
                completed = false;
            }
            else if (1 == useraccessor.UpdatePasswordHash(users.UserID, password, oldPassword))
            {
                completed = true;
            }
            return completed;
        }

        public List<string> RetrievAllRoles()
        {
            List<string> roles = null;

            try
            {
                roles = useraccessor.SelectAllRoles();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Data not found.", ex);
            }

            return roles;
        }

        public int RetrieveUserIDFromEmail(string email)
        {
            try
            {
                return useraccessor.SelectUsersByEmail(email).UserID;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Database Error", ex);
            }
        }

        public bool CreateUserRole(int userID, string role)
        {
            bool success = false;

            try
            {
                if (1 == useraccessor.InsertUserRole(userID, role))
                {
                    success = true;
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Bad username or password", ex);
            }
            return success;
        }
    }
}
