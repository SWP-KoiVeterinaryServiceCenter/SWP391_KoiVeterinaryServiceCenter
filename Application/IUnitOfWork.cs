﻿using Application.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public interface IUnitOfWork
    {
        public IAccountRepository AccountRepository { get; }
        public IKoiRepository KoiRepository { get; }
        public ICenterTankRepository CenterTankRepository { get; }
        public ICenterServiceRepository CenterServiceRepository { get; }
        public IServiceTypeRepository ServiceTypeRepository { get; }
        public IWorkingScheduleRepository WorkingScheduleRepository { get; }
        public IAppointmentRepository AppointmentRepository { get; }
        public IRatingRepository RatingRepository { get; }
        public ITravelExpenseRepository TravelExpenseRepository { get; }
        public IMedicalRecordRepository MedicalRecordRepository { get; }
        public IMedicalPrescriptionRepository MedicalPrescriptionRepository { get; }
        public IAccountScheduleRepository AccountScheduleRepository { get; }
        public IFeedbackRepository FeedbackRepository { get; }
        public ITransactionRepository TransactionRepository { get; }
        public Task<int> SaveChangeAsync();
    }
}
