using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BOL;
using MySql.Data.MySqlClient;
using DAL;

namespace BLL
{
    public static class PermissionService
    {
        public static List<Permission> GetPermissions(int userId)
        {
            string query = $"SELECT per.*, u.user_name,pro.project_name FROM task_management.permission per JOIN task_management.user u ON per.worker_id = u.user_id JOIN task_management.project pro ON per.project_id = pro.project_id WHERE per.is_active = 1 and per.worker_id = {userId};";
            Func<MySqlDataReader, List<Permission>> InitPermissionList = (internalReader) =>
            {

                List<Permission> permissions = new List<Permission>();
                while (internalReader.Read())
                {
                    permissions.Add(BaseService.InitPermission(internalReader));
                }
                return permissions;

            };
            List<Permission> permissionList = DBAccess.RunReader(query, InitPermissionList);
            return permissionList;
        }

        public static int AddPemission(Permission permission)
        {
            try
            {
                string query;
                query = $"INSERT INTO task_management.permission(worker_id,project_id) VALUES({permission.WorkerId},{permission.ProjectId});";
                if(DBAccess.RunNonQuery(query) == 1)
                {
                    return GetPermissionId();
                }
                return 0;    
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool DeletePemission(int permissionId)
        {
            try
            {
                string query = $"UPDATE task_management.permission SET is_active=0 WHERE permission_id={permissionId} AND is_active=1;";
                return DBAccess.RunNonQuery(query) == 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private static int GetPermissionId()
        {
            try
            {
                string query = $"SELECT permission_id FROM task_management.permission  ORDER BY permission_id DESC LIMIT 1;";
                return Convert.ToInt32(DBAccess.RunScalar(query));


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
      
    }
}
