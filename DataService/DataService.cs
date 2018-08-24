using System;
using System.Collections.Generic;
using System.Linq;
using PlanYourDay.DataService.DAL;
using PlanYourDay.DataService.Models;
using PlanYourDay.DateTimeHelper;

namespace PlanYourDay.DataService
{
    public class DataService
    {
        private DayModel _backlog;
        private UnitOfWork _unitOfWork;

        public DataService()
        {
            _unitOfWork = new UnitOfWork();
            Load();
        }

        public DataService(string sourcePath)
        {
            Load(sourcePath);
        }

        public string SourcePath { get; private set; }

        private void Load()
        {
            // Add today if not present
            if (_unitOfWork.DayRepository.GetByDate(DateHelper.Today) == null)
            {
                _unitOfWork.DayRepository.Add(
                    new DayModel(_unitOfWork.DayRepository.GetNextId())
                    {
                        Date = DateHelper.Today,
                    });
            }

            // Add tomorrow/next business day if not present
            if (_unitOfWork.DayRepository.GetByDate(DateHelper.NextBusinessDay) == null)
            {
                _unitOfWork.DayRepository.Add(
                    new DayModel(_unitOfWork.DayRepository.GetNextId())
                    {
                        Date = DateHelper.NextBusinessDay,
                    });
            }

            // Add Backlog, if not present
            if ((_backlog = _unitOfWork.DayRepository.GetByDate(DateHelper.BacklogDate)) == null)
            {
                _backlog = _unitOfWork.DayRepository.Add(
                    new DayModel(_unitOfWork.DayRepository.GetNextId())
                    {
                        Date = DateHelper.BacklogDate,
                    });
            }
        }

        public DayModel AddDay(DateTime date)
        {
            return _unitOfWork.DayRepository.Add(
                new DayModel(_unitOfWork.DayRepository.GetNextId())
                {
                    Date = date,
                });
        }

        public ProjectModel AddProject(string name, string color)
        {
            return _unitOfWork.ProjectRepository.Add(
                new ProjectModel(_unitOfWork.ProjectRepository.GetNextId())
                {
                    Name = name,
                    Color = color,
                });
        }

        public TaskModel AddTaskToBacklog(string name, string notes, int priority, ProjectModel project, int rank, bool done, int time)
        {
            return AddTaskToDay(_backlog, name, notes, priority, project, rank, done, time);
        }

        public TaskModel AddTaskToDay(DayModel day, string name, string notes, int priority, ProjectModel project, int rank, bool done, int time)
        {
            return _unitOfWork.TaskRepository.Add(
                new TaskModel(_unitOfWork.TaskRepository.GetNextId())
                {
                    DayId = day.Id,
                    Name = name,
                    Notes = notes,
                    Priority = priority,
                    ProjectId = project?.Id ?? -1,
                    Rank = rank,
                    Done = done,
                    Time = time,
                });
        }

        public List<DayModel> GetAllDays() => _unitOfWork.DayRepository.All.Where(d => d.Date != DateHelper.BacklogDate).ToList();

        public List<TaskModel> GetTasksByDay(DayModel day) => _unitOfWork.TaskRepository.All.Where(t => t.DayId == day.Id).ToList();

        public void Load(string sourcePath)
        {
            _unitOfWork = new UnitOfWork(sourcePath);
            SourcePath = sourcePath;

            Load();
        }

        public void Save() => SaveAs(SourcePath);

        public void SaveAs(string sourcePath)
        {
            _unitOfWork.Save(sourcePath);
            SourcePath = sourcePath;
        }
    }
}