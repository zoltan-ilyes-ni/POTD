using System;
using System.Collections.Generic;
using System.Linq;
using POTD.DataService.DAL;
using POTD.DataService.Models;

namespace POTD.DataService
{
    public class DataService
    {
        private readonly DateTime _backlogDate;
        private DayModel _backlog;
        private UnitOfWork _unitOfWork;

        public DataService()
        {
            _unitOfWork = new UnitOfWork();
            _backlogDate = new DateTime(2099, 12, 31);
        }

        public string SourcePath { get; private set; }

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
                    ProjectId = project.Id,
                    Rank = rank,
                    Done = done,
                    Time = time,
                });
        }

        public List<DayModel> GetAllDays() => _unitOfWork.DayRepository.All.Where(d => d.Date != _backlogDate).ToList();

        public List<TaskModel> GetTasksByDay(DayModel day) => _unitOfWork.TaskRepository.All.Where(t => t.DayId == day.Id).ToList();

        public void Load(string sourcePath)
        {
            _unitOfWork = new UnitOfWork(sourcePath);
            SourcePath = sourcePath;

            // Add Backlog, if not present
            if ((_backlog = _unitOfWork.DayRepository.All.FirstOrDefault(d => d.Date == _backlogDate)) == null)
            {
                _backlog = _unitOfWork.DayRepository.Add(
                    new DayModel(_unitOfWork.DayRepository.GetNextId())
                    {
                        Date = _backlogDate
                    });
            }
        }

        public void Save() => SaveAs(SourcePath);

        public void SaveAs(string sourcePath)
        {
            // Todo: trim empty days

            _unitOfWork.Save(sourcePath);
            SourcePath = sourcePath;
        }
    }
}