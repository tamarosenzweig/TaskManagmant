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
    public static class PresenceHoursService
    {
        public static List<PresenceHours> GetPresenceHours(int workerId, int projectId)
        {
            try
            {
                string query = $"SELECT p.*,u.user_name FROM task_management.presence_hours p JOIN task_management.user u ON p.worker_id=u.user_id WHERE end_hour IS NOT NULL AND worker_id={workerId} AND project_id={projectId};";

                Func<MySqlDataReader, List<PresenceHours>> InitPresenceHoursList = (reader) =>
                {
                    List<PresenceHours> presencesHours = new List<PresenceHours>();
                    while (reader.Read())
                    {
                        PresenceHours presenceHours = BaseService.initPresenceHours(reader);
                        presencesHours.Add(presenceHours);
                    }
                    return presencesHours;
                };

                List<PresenceHours> presenceHoursList = DBAccess.RunReader(query, InitPresenceHoursList);
                return presenceHoursList.Where(presenceHours => presenceHours.StartHour.Month == DateTime.Today.Month).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int GetPresenceHoursSum(int projectId, int workerId)
        {
            string query = "SELECT SUM(TIMESTAMPDIFF(HOUR, start_hour, end_hour)) " +
                           "FROM task_management.presence_hours " +
                           $"WHERE project_id = {projectId} AND worker_id = {workerId}";
            int sum = (int)DBAccess.RunScalar(query);
            return sum;
        }
        //public static List<PresenceHours> GetPresenceHoursByProjectId(int projectId)
        //{
        //    try
        //    {
        //        List<PresenceHours> presenceHoursList = GetPresenceHours().Where(presenceHour => presenceHour.ProjectId == projectId).ToList();
        //        return presenceHoursList;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}


        public static int AddPresenceHours(PresenceHours newPresenceHours)
        {
            try
            {
                newPresenceHours.StartHour = newPresenceHours.StartHour.ToLocalTime();
                string query = $"INSERT INTO task_management.presence_hours(worker_id,project_id,start_hour) VALUES({newPresenceHours.WorkerId}, {newPresenceHours.ProjectId}, {BaseService.FormatDate(newPresenceHours.StartHour, "yyyy-MM-dd HH:mm:ss")});";
                if (DBAccess.RunNonQuery(query) == 1)
                {
                    query = $"SELECT * FROM task_management.presence_hours ORDER BY presence_hours_id  DESC LIMIT 1;";
                    int id = Convert.ToInt32(DBAccess.RunScalar(query));
                    return id;
                }
                return -1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool EditPresenceHours(PresenceHours presenceHours)
        {
            try
            {
                string query = $"UPDATE task_management.presence_hours SET end_hour={BaseService.FormatDate(((DateTime)presenceHours.EndHour).ToLocalTime(), "yyyy-MM-dd HH:mm:ss")} WHERE presence_hours_id={presenceHours.PresenceHoursId};";
                bool created = DBAccess.RunNonQuery(query) == 1;
                if (created)
                {
                    WorkerHours workerHours = WorkerHoursService.GetWorkerHoursPerProject(presenceHours.WorkerId, presenceHours.ProjectId)[0];
                    int presenceHoursSum = GetPresenceHoursSum(presenceHours.WorkerId, presenceHours.ProjectId);
                    if (presenceHoursSum >= workerHours.NumHours)
                    {
                        workerHours.IsComplete = true;
                        WorkerHoursService.EditWorkerHours(workerHours);
                        ProjectService.updateProjectStatus(presenceHours.ProjectId);
                    }

                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<dynamic> GetPresenceStatusPerWorkers(int teamLeaderId)
        {
            string query =
            "SELECT user_name, SUM(TIMESTAMPDIFF(HOUR, start_hour, end_hour)) " +
            "FROM task_management.user u " +
            "JOIN task_management.presence_hours p " +
            "ON u.user_id = p.worker_id " +
            $"WHERE team_leader_id={teamLeaderId} " +
            "GROUP BY user_id;";
            Func<MySqlDataReader, List<dynamic>> InitPresenceStatusList = (reader) =>
            {
                List<dynamic> presenceStatusList = new List<dynamic>();
                while (reader.Read())
                {
                    var presenceStatus = new { userName = reader.GetString(0), presenceHours = reader.GetInt32(1) };
                    presenceStatusList.Add(presenceStatus);
                }
                return presenceStatusList;
            };
            return DBAccess.RunReader(query, InitPresenceStatusList);
        }
        public static List<dynamic> GetPresenceStatusPerProjects(int workerId)
        {
            //todo
            string query =
                //pre.project_id
                "SELECT pro.project_name,SUM(TIMESTAMPDIFF(HOUR, start_hour, end_hour)),num_hours " +
                "FROM task_management.presence_hours pre " +
                "JOIN task_management.project pro " +
                "ON pro.project_id = pre.project_id " +
                "JOIN task_management.worker_hours w " +
                "ON pro.project_id = w.project_id " +
                $"WHERE pre.worker_id = {workerId} AND w.worker_id = {workerId} " +
                "GROUP BY pre.project_id;";
            Func<MySqlDataReader, List<dynamic>> InitPresenceStatusList = (reader) =>
            {
                List<dynamic> presenceStatusList = new List<dynamic>();
                while (reader.Read())
                {
                    var presenceStatus = new { projectName = reader.GetString(0), presenceHours = reader.GetInt32(1), projectHours = reader.GetInt32(2) };
                    presenceStatusList.Add(presenceStatus);
                }
                return presenceStatusList;
            };
            return DBAccess.RunReader(query, InitPresenceStatusList);
        }
    }
}
