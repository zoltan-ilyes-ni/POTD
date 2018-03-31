using System;
using System.Collections.Generic;
using System.Linq;
using POTD.DataService.DAL;
using POTD.DataService.Models;

namespace POTD.DataService
{
    public class DataService
    {
        public string SourcePath { get; private set; }

        private UnitOfWork _unitOfWork;
        private readonly DateTime _today, _tomorrow, _backlogDate;

        public DataService()
        {
            _unitOfWork = new UnitOfWork();
            _today = DateTime.Today;
            _tomorrow = DateTime.Today.AddDays(1);
            _backlogDate = new DateTime(2099, 12, 31);
        }

        public void Save() => SaveAs(SourcePath);

        public void SaveAs(string sourcePath)
        {
            // Todo: trim empty days

            _unitOfWork.Save(sourcePath);
            SourcePath = sourcePath;
        }

        public void Load(string sourcePath)
        {
            _unitOfWork = new UnitOfWork(sourcePath);
            SourcePath = sourcePath;

            // Add Today if not present
            if (_unitOfWork.DayRepository.All.FirstOrDefault(d => d.Date == _today) == null)
            {
                _unitOfWork.DayRepository.Add(_today);
            }

            // Add Tomorrow, if not present
            if (_unitOfWork.DayRepository.All.FirstOrDefault(d => d.Date == _tomorrow) == null)
            {
                _unitOfWork.DayRepository.Add(_tomorrow);
            }

            // Add Backlog, if not present
            if (_unitOfWork.DayRepository.All.FirstOrDefault(d => d.Date == _backlogDate) == null)
            {
                _unitOfWork.DayRepository.Add(_backlogDate);
            }
        }

        public List<DayModel> GetAllDays() => _unitOfWork.DayRepository.All.Where(d => d.Date != _backlogDate).ToList();
    }
}