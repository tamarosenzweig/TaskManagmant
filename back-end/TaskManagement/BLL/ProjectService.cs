using BOL;
using DAL;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public static class ProjectService
    {
        public static bool AddProject(Project newProject)
        {
            try
            {
                string query = "START TRANSACTION;";
                //string query = "";
                query += $"INSERT INTO task_management.project(project_name,manager_id,customer_id,team_leader_id,total_hours,start_date,end_date) VALUES('{newProject.ProjectName}',{newProject.ManagerId},{newProject.CustomerId},{newProject.TeamLeaderId},{newProject.TotalHours},{BaseService.FormatDate(newProject.StartDate)},{BaseService.FormatDate(newProject.EndDate)});";
                //take id of the inserted project
                query += $"SELECT project_id INTO @project_id FROM task_management.project WHERE project_name='{newProject.ProjectName}';";
                //add the divided hours for each department
                foreach (DepartmentHours departmentHour in newProject.DepartmentsHours)
                {
                    query += $"INSERT INTO task_management.department_hours(project_id,department_id,num_hours) VALUES(@project_id,{departmentHour.DepartmentId},{departmentHour.NumHours});";
                }
                //add permission to extra workers if exists
                if (newProject.Permissions != null)
                    foreach (Permission permission in newProject.Permissions)
                    {
                        query += $"INSERT INTO task_management.permission(worker_id,project_id) VALUES({permission.WorkerId},@project_id);";
                    }
                query += "COMMIT;";
                int? x = DBAccess.RunNonQuery(query);
                return x >= 4;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static bool EditProject(Project project)
        {
            try
            {
                string query = "UPDATE task_management.project SET is_complete=1 WHERE project_id=1;";
                return DBAccess.RunNonQuery(query) == 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<Project> GetAllProjects()
        {
            try
            {
                string query = $"{GetAllProjectsQuery()};";
                try
                {
                    List<Project> projectsList = GetAllProjects(query);
                    return projectsList;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<Project> GetAllProjects(DateTime date)
        {
            try
            {
                string query = $"{GetAllProjectsQuery()} WHERE end_date={BaseService.FormatDate(date.AddDays(1))} AND is_complete=false;";
                try
                {
                    List<Project> projectsList = GetAllProjects(query);
                    return projectsList;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static List<Project> getProjectsByTeamLeaderId(int teamLeaderId)
        {
            try
            {
                string query = $"{GetProjectsQuery()} WHERE p.team_leader_id={teamLeaderId}";
                List<Project> projectList = GetProjects(query);
                return projectList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static Project getProjectById(int projectId)
        {
            try
            {
                string query = $"{GetAllProjects()} WHERE project_id={projectId}";
                Func<MySqlDataReader, Project> InitProject = (reader) =>
                {
                    Project project = null;
                    if (reader.Read())
                    {
                        project = BaseService.InitProject(reader);
                    }
                    return project;
                };

                Project foundProject = DBAccess.RunReader(query, InitProject);
                return foundProject;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<Project> GetProjectsReports()
        {
            string query = $"{GetProjectsQuery()};";
            List<Project> projectList = GetProjects(query);
            return projectList;
        }
        private static string GetProjectsQuery()
        {
            string query =
                "SELECT " +
                "p.project_id,project_name,p.manager_id,p.customer_id," +
                "p.team_leader_id,total_hours,start_date,end_date,is_complete," +
                "customer_name,user_name,email " +
                "FROM task_management.project p " +
                "JOIN task_management.customer c " +
                "ON p.customer_id = c.customer_id " +
                "JOIN task_management.user u " +
                "ON p.team_leader_id = u.user_id";
            return query;
        }

        public static void updateProjectStatus(int projectId)
        {
            Project project = getProjectById(projectId);
            List<WorkerHours> workerHoursList = WorkerHoursService.GetAllWorkerHoursPerProject(projectId);
            bool isComplete = workerHoursList.All(workerHours => workerHours.IsComplete == true);
            int projectNumHours = workerHoursList.Sum(workerHours => workerHours.NumHours);
            if (isComplete && projectNumHours >= project.TotalHours)
            {
                EditProject(project);
            }
        }

        private static string GetAllProjectsQuery()
        {
            string query = "SELECT * FROM task_management.project";
            return query;
        }
        private static List<Project> GetProjects(string query)
        {
            try
            {
                Func<MySqlDataReader, List<Project>> func = (reader) =>
             {

                 List<Project> projects = new List<Project>();
                 while (reader.Read())
                 {
                     projects.Add(BaseService.InitProject(reader));
                 }
                 return projects;
             };

                List<Project> projectsList = DBAccess.RunReader(query, func);
                projectsList.ForEach(project =>
                {
                    project.DepartmentsHours = DepartmentHoursService.getDepartmentsHours(project.ProjectId);
                    project.DepartmentsHours.ForEach(departmentHours =>
                    {
                        departmentHours.Department.workers = UserService.GetAllUsers(departmentHours.DepartmentId, project.TeamLeaderId);
                        departmentHours.Department.workers.AddRange(UserService.GetAllUsersWithProjectPermission(departmentHours.DepartmentId, project.ProjectId));
                        departmentHours.Department.workers.ForEach(worker =>
                        {
                            worker.WorkerHours = WorkerHoursService.GetWorkerHoursPerProject(worker.UserId, project.ProjectId);
                            worker.PresenceHours = PresenceHoursService.GetPresenceHours(worker.UserId, project.ProjectId);

                        });
                    });
                });

                return projectsList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static List<Project> GetAllProjects(string query)
        {
            try
            {
                try
                {
                    Func<MySqlDataReader, List<Project>> func = (reader) =>
                    {
                        List<Project> projects = new List<Project>();
                        while (reader.Read())
                        {
                            projects.Add(BaseService.InitProject(reader));
                        }
                        return projects;
                    };

                    List<Project> projectsList = DBAccess.RunReader(query, func);

                    return projectsList;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
