using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;
using DataAccessLayerInterfaces;
using System.Data.SqlClient;
using System.Data;

namespace DataAccessLayer
{
    public class Useraccessor : IUseraccessor
    {
        public int checkUserWithEmailAndPassword(string email, string passwordHash)
        {
            int result = 0;
            DBconnection connectionFactory = new DBconnection();
            var conn = connectionFactory.GetConnection();

            var cmdText = "sp_check_user";

            var cmd = new SqlCommand(cmdText, conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@email", SqlDbType.NVarChar, 100);

            cmd.Parameters.Add("@PasswordHash", SqlDbType.NVarChar, 100);

            cmd.Parameters["@email"].Value = email;

            cmd.Parameters["@PasswordHash"].Value = passwordHash;

            try
            {
                conn.Open();
                result = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return result;
        }

        public int DeleteUserRole(int userID, string role)
        {
            int rows = 0;
            var connectionFactory = new DBconnection();
            var conn = connectionFactory.GetConnection();

            var cmdText = "sp_delete_user_role";

            var cmd = new SqlCommand(cmdText, conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@userid", userID);
            cmd.Parameters.AddWithValue("@roleID", role);

            try
            {
                conn.Open();

                rows = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return rows;

        }

        public int InsertNewUser(Users user)
        {
            int result = 0;
            var connectionFactory = new DBconnection();
            var conn = connectionFactory.GetConnection();

            var cmdText = "sp_insert_new_user";

            var cmd = new SqlCommand(cmdText, conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@givenName", SqlDbType.NVarChar, 50);
            cmd.Parameters.Add("@familyName", SqlDbType.NVarChar, 100);
            cmd.Parameters.Add("@phone", SqlDbType.NVarChar, 13);
            cmd.Parameters.Add("@email", SqlDbType.NVarChar, 100);

            cmd.Parameters["@givenName"].Value = user.GivenName;
            cmd.Parameters["@familyName"].Value = user.FamilyName;
            cmd.Parameters["@phone"].Value = user.Phone;
            cmd.Parameters["@email"].Value = user.Email;

            try
            {
                conn.Open();

                result = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return result;
        }

        public int InsertNewUserAndRole(string firstName, string lastName, string phone, string email, string roleID)
        {
            int result = 0;

            var connectionFactory = new DBconnection();
            var conn = connectionFactory.GetConnection();

            var cmdText = "sp_insert_new_user_and_role";

            var cmd = new SqlCommand(cmdText, conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@givenName", SqlDbType.NVarChar, 50);
            cmd.Parameters.Add("@familyName", SqlDbType.NVarChar, 100);
            cmd.Parameters.Add("@phone", SqlDbType.NVarChar, 13);
            cmd.Parameters.Add("@email", SqlDbType.NVarChar, 100);
            cmd.Parameters.Add("@roleID", SqlDbType.NVarChar, 50);

            cmd.Parameters["@givenName"].Value = firstName;
            cmd.Parameters["@familyName"].Value = lastName;
            cmd.Parameters["@phone"].Value = phone;
            cmd.Parameters["@email"].Value = email;
            cmd.Parameters["@roleID"].Value = roleID;

            try
            {
                conn.Open();

                result = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return result;
        }

        public int InsertUserRole(int userID, string role)
        {
            int result = 0;
            var connectionFactory = new DBconnection();
            var conn = connectionFactory.GetConnection();

            var cmdText = "sp_insert_user_role";

            var cmd = new SqlCommand(cmdText, conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@userid", userID);
            cmd.Parameters.AddWithValue("@roleID", role);

            try
            {
                conn.Open();

                result = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return result;
        }

        public List<string> SelectAllRoles()
        {
            List<string> roles = new List<string>();

            DBconnection connectionFactory = new DBconnection();
            var conn = connectionFactory.GetConnection();

            var cmdText = "sp_select_all_roles";

            var cmd = new SqlCommand(cmdText, conn);

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        roles.Add(reader.GetString(0));
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return roles;
        }

        public List<string> SelectRolesByUserID(int userID)
        {
            List<string> roles = new List<string>();

            DBconnection connectionFactory = new DBconnection();
            var conn = connectionFactory.GetConnection();

            var cmdText = "sp_select_roles_by_userID";

            var cmd = new SqlCommand(cmdText, conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@userID", SqlDbType.Int);

            cmd.Parameters["@userID"].Value = userID;

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        roles.Add(reader.GetString(0));
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return roles;
        }

        public List<Users> SelectUsersByActive(bool active)
        {
            List<Users> user = new List<Users>();

            DBconnection connectionFactory = new DBconnection();
            var conn = connectionFactory.GetConnection();

            var cmdText = "sp_select_users_by_active";

            var cmd = new SqlCommand(cmdText, conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@active", SqlDbType.Bit);

            cmd.Parameters["@active"].Value = active;

            try
            {
                conn.Open();

                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        // [userID], [givenName], [familyName], [phone], [email], [roleID]
                        var users = new Users();
                        users.UserID = reader.GetInt32(0);
                        users.GivenName = reader.GetString(1);
                        users.FamilyName = reader.GetString(2);
                        users.Phone = reader.GetString(3);
                        users.Email = reader.GetString(4);
                        users.UsersRole = reader.GetString(5);
                        user.Add(users);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return user;
        }

        public Users SelectUsersByEmail(string email)
        {
            Users user = null;
            DBconnection connectionFactory = new DBconnection();
            var conn = connectionFactory.GetConnection();

            var cmdText = "sp_select_users_by_email";

            var cmd = new SqlCommand(cmdText, conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@email", SqlDbType.NVarChar, 100);

            cmd.Parameters["@email"].Value = email;

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows) 
                {
                    reader.Read();
                    user = new Users();
                    user.UserID = reader.GetInt32(0);
                    user.GivenName = reader.GetString(1);
                    user.FamilyName = reader.GetString(2);
                    user.Phone = reader.GetString(3);
                    user.Email = reader.GetString(4);
                    user.Active = reader.GetBoolean(5);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return user;
        }

        public int UpdatePasswordHash(int userID, string passwordHash, string oldPasswordHash)
        {
            int rows = 0;

            DBconnection connectionFactory = new DBconnection();
            var conn = connectionFactory.GetConnection();

            var cmdText = "sp_update_passwordHash";

            var cmd = new SqlCommand(cmdText, conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@userID", userID);
            cmd.Parameters.AddWithValue("@PasswordHash", passwordHash);
            cmd.Parameters.AddWithValue("@OldPasswordHash", oldPasswordHash);

            try
            {
                conn.Open();

                rows = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return rows;
        }
    }
}
