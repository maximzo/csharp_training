using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using SimpleBrowser.WebDriver;
using System.Text.RegularExpressions;

namespace mantis_tests
{
    public class APIHelper : HelperBase
    {
        public APIHelper(AppManager manager) : base(manager) { }

        public void CreateNewIssue(AccountData account, ProjectData project, IssueData issueData)
        {
            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
            Mantis.IssueData issue = new Mantis.IssueData();
            issue.summary = issueData.Summary;
            issue.description = issueData.Description;
            issue.category = issueData.Category;
            issue.project = new Mantis.ObjectRef();
            issue.project.id = project.Id;
            client.mc_issue_add(account.Name, account.Password, issue);
        }

        public List<ProjectData> GetProjects(AccountData account)
        {
            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
            Mantis.ProjectData[] mantisProjects = client.mc_projects_get_user_accessible(account.Name, account.Password);
            
            List<ProjectData> projects = new List<ProjectData>();
            foreach(Mantis.ProjectData mantisProject in mantisProjects)
            {
                projects.Add(new ProjectData() { Name = mantisProject.name, Id = mantisProject.id });
            }
            return projects;
        }

        public void CreateNewProject(AccountData account, ProjectData project)
        {
            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
            Mantis.ProjectData projectData = new Mantis.ProjectData();
            projectData.name = project.Name;
            client.mc_project_add(account.Name, account.Password, projectData);
        }

        public void DeleteProject(AccountData account, ProjectData project)
        {
            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
            client.mc_project_delete(account.Name, account.Password, project.Id);
        }

        public void IsProjectExist(List<ProjectData> oldProjects, AccountData account, ProjectData project)
        {
            if (oldProjects.Count() == 0)
            {
                CreateNewProject(account, project);
            }
        }
    }
}
