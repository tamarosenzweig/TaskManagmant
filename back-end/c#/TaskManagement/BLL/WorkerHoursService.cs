using BOL;
using DAL;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public static class WorkerHoursService
    {

        public static List<WorkerHours> GetAllWorkerHours(int workerId)
        {
            string query;
            query = $"{GetWorkerHoursQuery()} AND worker_id ={workerId};";
            List<WorkerHours> workerHoursList = GetWorkersHours(query);
            return workerHoursList;
        }

        public static List<WorkerHours> GetAllWorkerHoursPerProject(int projectId)
        {
            string query = $"{GetWorkerHoursQuery()} AND project_id ={projectId};";
            List<WorkerHours> workerHoursList = GetWorkersHours(query);
            return workerHoursList;
        }

        public static List<WorkerHours> GetUncompletedWorkerHours(int projectId)
        {
            string query = $"{GetWorkerHoursQuery()} AND w.is_complete=false AND w.project_id ={projectId};";
            List<WorkerHours> workerHoursList = GetWorkersHours(query);
            return workerHoursList;
        }
        public static List<WorkerHours> GetWorkerHoursPerProject(int workerId, int projectId)
        {
            string query;
            query = $"{GetWorkerHoursQuery()} AND worker_id ={workerId} AND w.project_id={projectId};";
            List<WorkerHours> workerHoursList = GetWorkersHours(query);
            return workerHoursList;
        }

        public static bool AddWorkerHours(WorkerHours workerHours)
        {
            try
            {
                string query = $"INSERT INTO task_management.worker_hours(project_id,worker_id,num_hours) VALUES ({workerHours.ProjectId},{workerHours.WorkerId},{workerHours.NumHours});";
                return DBAccess.RunNonQuery(query) == 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool EditWorkerHours(WorkerHours workerHours)
        {
            try
            {
                int presenceHoursSum = PresenceHoursService.GetPresenceHoursSum(workerHours.ProjectId, workerHours.WorkerId);
                if (presenceHoursSum < workerHours.NumHours)
                    workerHours.IsComplete = false;
                string query = $"UPDATE task_management.worker_hours SET num_hours={workerHours.NumHours},is_complete={workerHours.IsComplete} WHERE worker_hours_id={workerHours.WorkerHoursId} AND is_active=1;";
                //check if you have to change iscomplete
                return DBAccess.RunNonQuery(query) == 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool DeleteWorkerHours(int workerHoursId)
        {
            try
            {
                string query = $"UPDATE task_management.worker_hours SET is_active=0 WHERE worker_hours_id={workerHoursId} AND is_active=1;";
                return DBAccess.RunNonQuery(query) == 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static string GetWorkerHoursQuery()
        {
            string query = $"SELECT w.*,project_name,user_name,email,department_name FROM task_management.worker_hours w JOIN task_management.project p ON w.project_id=p.project_id JOIN task_management.user u ON w.worker_id=u.user_id JOIN task_management.department d ON u.department_id=d.department_id WHERE w.is_active=1";
            return query;
        }

        private static List<WorkerHours> GetWorkersHours(string query)
        {
            try
            {
                Func<MySqlDataReader, List<WorkerHours>> InitWorkerHoursList = (reader) =>
                {
                    List<WorkerHours> workersHours = new List<WorkerHours>();
                    while (reader.Read())
                    {
                        WorkerHours workerHours = BaseService.InitWorkerHours(reader);
                        workersHours.Add(workerHours);
                    }
                    return workersHours;
                };

                List<WorkerHours> workerHoursList = DBAccess.RunReader(query, InitWorkerHoursList);

                return workerHoursList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
