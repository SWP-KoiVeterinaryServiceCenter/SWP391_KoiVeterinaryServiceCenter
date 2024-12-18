﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Application;
using Application.IRepository;
using Application.IService.Abstraction;
using Infrastructure.Repository;
namespace Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _dbContext;
        private readonly IAccountRepository _accountRepository;
        private readonly IKoiRepository _koiRepository;
        private readonly IServiceTypeRepository _serviceTypeRepository;
        private readonly ICenterTankRepository _centerTankRepository;
        private readonly ICenterServiceRepository _centerServiceRepository;
        private readonly IWorkingScheduleRepository _workingScheduleRepository;
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IRatingRepository _ratingRepository;
        private readonly ITravelExpenseRepository _travelExpenseRepository;
        private readonly IMedicalRecordRepository _medicalRecordRepository;
        private readonly IMedicalPrescriptionRepository _medicalPrescriptionRepository;
        private readonly IAccountScheduleRepository _accountScheduleRepository;
        private readonly IFeedbackRepository _feedbackRepository;
        private readonly ITransactionRepository _transactionRepository;

        public UnitOfWork(AppDbContext dbContext, IAccountRepository accountRepository,
            IKoiRepository koiRepository, IServiceTypeRepository serviceTypeRepository,
            ICenterTankRepository centerTankRepository, ICenterServiceRepository centerServiceRepository,
            IWorkingScheduleRepository workingScheduleRepository, IAppointmentRepository appointmentRepository,
            IRatingRepository ratingRepository, ITravelExpenseRepository travelExpenseRepository,
            IMedicalPrescriptionRepository medicalPrescriptionRepository, IMedicalRecordRepository medicalRecordRepository,
            IAccountScheduleRepository accountScheduleRepository,IFeedbackRepository feedbackRepository,ITransactionRepository transactionRepository)
        {
            _dbContext = dbContext;
            _accountRepository = accountRepository;
            _koiRepository = koiRepository;
            _serviceTypeRepository = serviceTypeRepository;
            _centerTankRepository = centerTankRepository;
            _centerServiceRepository = centerServiceRepository;
            _workingScheduleRepository = workingScheduleRepository;
            _appointmentRepository = appointmentRepository;
            _ratingRepository = ratingRepository;
            _feedbackRepository= feedbackRepository;    
            _travelExpenseRepository = travelExpenseRepository;
            _medicalPrescriptionRepository = medicalPrescriptionRepository;
            _medicalRecordRepository = medicalRecordRepository;
            _accountScheduleRepository = accountScheduleRepository;
            _transactionRepository = transactionRepository;
        }

        public IAccountRepository AccountRepository => _accountRepository;
        public IKoiRepository KoiRepository => _koiRepository;

        public ICenterTankRepository CenterTankRepository => _centerTankRepository;
        public ICenterServiceRepository CenterServiceRepository => _centerServiceRepository;

        public IServiceTypeRepository ServiceTypeRepository => _serviceTypeRepository;
        public IWorkingScheduleRepository WorkingScheduleRepository => _workingScheduleRepository;

        public IAppointmentRepository AppointmentRepository => _appointmentRepository;
        public IRatingRepository RatingRepository => _ratingRepository;

        public ITravelExpenseRepository TravelExpenseRepository => _travelExpenseRepository;

        public IMedicalRecordRepository MedicalRecordRepository => _medicalRecordRepository;

        public IMedicalPrescriptionRepository MedicalPrescriptionRepository => _medicalPrescriptionRepository;

        public IAccountScheduleRepository AccountScheduleRepository => _accountScheduleRepository;
        public IFeedbackRepository FeedbackRepository => _feedbackRepository;

        public ITransactionRepository TransactionRepository => _transactionRepository;

        public async Task<int> SaveChangeAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }
    }
}