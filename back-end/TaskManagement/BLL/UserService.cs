using System;
using System.Collections.Generic;
using BOL;
using DAL;
using MySql.Data.MySqlClient;
using System.Linq;
using BOL.Help;
using System.Runtime.InteropServices;

namespace BLL
{
    public static class UserService
    {
        public static User Login(string email, string password)
        {
            try
            {
                string query = $"{GetSimpleUsersQuery()} WHERE email = '{email}' AND password = '{password}' AND is_active=1;";
                Func<MySqlDataReader, User> func = (reader) =>
                {
                    User user = null;
                    if (reader.Read())
                    {
                        user = BaseService.InitUser(reader);
                        user.Password = string.Empty;
                    }
                    return user;
                };
                return DBAccess.RunReader(query, func);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<User> GetAllUsers()
        {
            try
            {
                string query = $"{GetUsersQuery()} AND u.is_manager=0;";
                List<User> userList = GetUsers(query);
                //join permission of project for each user 
                userList.ForEach(user =>
                {
                    user.Permissions = PermissionService.GetPermissions(user.UserId);
                });

                return userList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static List<User> GetAllUsers(int teamLeaderId)
        {
            try
            {
                string query = $"{GetUsersQuery()} AND u.team_leader_id={teamLeaderId};";
                List<User> userList = GetUsers(query);
                //join permission of project for each user 
                userList.ForEach(user =>
                {
                    user.Permissions = PermissionService.GetPermissions(user.UserId);
                });

                return userList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static List<User> GetAllUsers(int departmentId, int teamLeaderId)
        {
            try
            {
                string query = $"{GetUsersQuery()} AND u.department_id={departmentId} AND u.team_leader_id={teamLeaderId};";
                List<User> userList = GetUsers(query);
                return userList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<User> GetAllUsersWithProjectPermission(int departmentId, int projectId)
        {
            try
            {
                string query = $"{GetUsersQuery()} AND u.department_id ={ departmentId} AND u.user_id IN(SELECT worker_id FROM task_management.permission WHERE project_id={projectId});";               
                List<User> userList = GetUsers(query);
                return userList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static List<User> GetAllUsersWithProjectPermission(int projectId)
        {
            try
            {
                string query = $"{GetSimpleUsersQuery()} AND user_id IN(SELECT worker_id FROM task_management.permission WHERE project_id={projectId});";
                List<User> userList = GetUsers(query);
                return userList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static List<User> GetAllTeamLeaders()
        {
            try
            {
                string query = $"{GetUsersQuery()} AND u.team_leader_id IS NULL AND u.is_manager=0;";
                List<User> teamLeaders= GetUsers(query);
                return teamLeaders;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static User GetUserById(int userId)
        {
            try
            {
                string query = $"{GetUsersQuery()} AND u.user_id={userId};";
                Func<MySqlDataReader, User> InitUser = (reader) =>
                {
                    User user = null;
                    if (reader.Read())
                    {
                        user = BaseService.InitUser(reader);
                        user.Password = string.Empty;
                    }
                    return user;
                };

                User foundUser = DBAccess.RunReader(query, InitUser);
                return foundUser;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static bool AddUser(User user)
        {
            try
            {
                string query = $"INSERT INTO task_management.user(user_name, email, password, profile_image_name, is_manager, department_id, team_leader_id,manager_id) VALUES('{user.UserName}', '{user.Email}', '{user.Password}', {BaseService.GetStringValueOrNull(user.ProfileImageName)}, {Convert.ToByte(user.IsManager)}, {BaseService.GetIntValueOrNull(user.DepartmentId)}, {BaseService.GetIntValueOrNull(user.TeamLeaderId)}, {BaseService.GetIntValueOrNull(user.ManagerId)});";
                return DBAccess.RunNonQuery(query) == 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static bool EditUser(User user)
        {
            try
            {
                string query = $"UPDATE task_management.user SET user_name='{user.UserName}',email='{user.Email}',profile_image_name={BaseService.GetStringValueOrNull(user.ProfileImageName)},department_id={BaseService.GetIntValueOrNull(user.DepartmentId)},team_leader_id={BaseService.GetIntValueOrNull(user.TeamLeaderId)} where user_id={user.UserId};";
                return DBAccess.RunNonQuery(query) == 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool DeleteUser(int userId)
        {
            try
            {
                string query = $"UPDATE task_management.user SET is_active=0 where user_id={userId} AND is_active=1;";
                return DBAccess.RunNonQuery(query) == 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static bool SendEmail(Email email,User user)
        {
            try
            {
                User manager = GetUserById((int)user.ManagerId);
                email.ToAddress.Add(manager.Email);
                email.Body += $"\nFrom {user.UserName}";
                return BaseService.SendEmail(email);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private static string GetSimpleUsersQuery()
        {
            string query ="SELECT * FROM task_management.user";
            return query;
        }
        private static string GetUsersQuery()
        {
            string query =
                "SELECT u.*,department_name,tl.user_name FROM task_management.user u " +
               "LEFT JOIN task_management.department d on u.department_id=d.department_id " +
               "LEFT JOIN task_management.user tl ON u.team_leader_id=tl.user_id " +
               "WHERE u.is_active=1";
            return query;
        }

        private static List<User> GetUsers(string query)
        {
            try
            {
                Func<MySqlDataReader, List<User>> InitUserList = (reader) =>
                {
                    List<User> users = new List<User>();
                    while (reader.Read())
                    {
                        User user = BaseService.InitUser(reader);
                        user.Password = string.Empty;
                        users.Add(user);
                    }
                    return users;
                };

                List<User> userList = DBAccess.RunReader(query, InitUserList);               
                return userList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
