using Application;
using Application.IService.Abstraction;
using Application.IService.Common;
using Application.Model.AccountSchedule;
using Domain.Entities;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class AccountScheduleService : IAccountScheduleService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IClaimService _claimService;

    public AccountScheduleService(IUnitOfWork unitOfWork, IClaimService claimService)
    {
        _unitOfWork = unitOfWork;
        _claimService = claimService;
    }

    public async Task AddAccountToScheduleAsync(AddAccountScheduleRequest addAccountScheduleRequest)
    {
        var account = await _unitOfWork.AccountRepository.GetByIdAsync(addAccountScheduleRequest.AccountId);
        if (account == null)
        {
            throw new Exception("Account not found.");
        }

        var workingSchedule = new WorkingSchedule
        {
            Id = Guid.NewGuid(),
            StartTime = addAccountScheduleRequest.StartTime.TimeOfDay,
            EndTime = addAccountScheduleRequest.EndTime.TimeOfDay,
            WorkingDay = addAccountScheduleRequest.WorkingDay.Date
        };

        await _unitOfWork.WorkingScheduleRepository.AddAsync(workingSchedule);

        var existingLink = await _unitOfWork.AccountScheduleRepository
                                .GetByAccountAndScheduleAsync(
                                    addAccountScheduleRequest.AccountId,
                                    workingSchedule.Id);

        if (existingLink != null)
        {
            throw new Exception("This account is already assigned to the schedule.");
        }

        var accountSchedule = new AccountSchedule
        {
            AccountId = addAccountScheduleRequest.AccountId,
            ScheduleId = workingSchedule.Id
        };

        await _unitOfWork.AccountScheduleRepository.AddAsync(accountSchedule);
        await _unitOfWork.SaveChangeAsync();
    }


    public async Task<IEnumerable<AccountScheduleResponse>> GetSchedulesByAccountIdAsync(Guid accountId)
    {
        var schedules = await _unitOfWork.AccountScheduleRepository.GetSchedulesByAccountIdAsync(accountId);

        if (!schedules.Any())
        {
            throw new Exception("No schedules found for this account.");
        }

        return schedules.Select(schedule => new AccountScheduleResponse
        {
            ScheduleId = schedule.WorkingSchedule.Id,
            AccountId = schedule.AccountId,
            StartTime = schedule.WorkingSchedule.StartTime,
            EndTime = schedule.WorkingSchedule.EndTime,
        });
    }

    public async Task<AccountScheduleResponse?> GetAccountScheduleByIdAsync(Guid accountId, Guid scheduleId)
    {
        var accountSchedule = await _unitOfWork.AccountScheduleRepository.GetByAccountAndScheduleAsync(accountId, scheduleId);
        if (accountSchedule == null) return null;

        if (accountSchedule.WorkingSchedule == null)
        {
            throw new Exception("WorkingSchedule not found for the specified AccountSchedule.");
        }

        return new AccountScheduleResponse
        {
            ScheduleId = accountSchedule.ScheduleId,
            AccountId = accountSchedule.AccountId,
            StartTime = accountSchedule.WorkingSchedule.StartTime,
            EndTime = accountSchedule.WorkingSchedule.EndTime,
        };
    }

    public async Task UpdateAccountScheduleAsync(Guid accountId, Guid scheduleId, UpdateAccountScheduleRequest request)
    {
        var accountSchedule = await _unitOfWork.AccountScheduleRepository.GetByAccountAndScheduleAsync(accountId, scheduleId);
        if (accountSchedule == null)
        {
            throw new Exception("AccountSchedule not found.");
        }

        // Cập nhật thông tin lịch
        accountSchedule.ScheduleId = accountId;
        accountSchedule.AccountId = scheduleId;

        if (accountSchedule.WorkingSchedule != null)
        {
            accountSchedule.WorkingSchedule.StartTime = request.StartTime.TimeOfDay;
            accountSchedule.WorkingSchedule.EndTime = request.EndTime.TimeOfDay;
        }
        else
        {
            throw new Exception("WorkingSchedule not found for the specified AccountSchedule.");
        }

        _unitOfWork.AccountScheduleRepository.Update(accountSchedule);
        await _unitOfWork.SaveChangeAsync();
    }

    public async Task DeleteAccountScheduleAsync(Guid accountId, Guid scheduleId)
    {
        var accountSchedule = await _unitOfWork.AccountScheduleRepository.GetByAccountAndScheduleAsync(accountId, scheduleId);
        if (accountSchedule == null)
        {
            throw new Exception("AccountSchedule not found.");
        }

        _unitOfWork.AccountScheduleRepository.SoftRemove(accountSchedule);
        await _unitOfWork.SaveChangeAsync();
    }

    public async Task<IEnumerable<AccountScheduleResponse>> GetAllAccountSchedulesAsync()
    {
        var accountSchedules = await _unitOfWork.AccountScheduleRepository.GetAllAsync();

        if (!accountSchedules.Any())
        {
            throw new Exception("No account schedules found.");
        }

        return accountSchedules.Select(accountSchedule => new AccountScheduleResponse
        {
            ScheduleId = accountSchedule.ScheduleId,
            AccountId = accountSchedule.AccountId,
            StartTime = accountSchedule.WorkingSchedule.StartTime,
            EndTime = accountSchedule.WorkingSchedule.EndTime,
        });
    }
}