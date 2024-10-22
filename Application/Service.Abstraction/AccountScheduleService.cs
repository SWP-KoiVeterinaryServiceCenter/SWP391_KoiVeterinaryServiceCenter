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

    public async Task<AccountScheduleResponse> AddAccountToScheduleAsync(AddAccountScheduleRequest addAccountScheduleRequest)
    {
        var account = await _unitOfWork.AccountRepository.GetByIdAsync(addAccountScheduleRequest.VeterinarianId);
        if (account == null)
        {
            throw new Exception("Account not found.");
        }

        TimeSpan startTime;
        TimeSpan endTime;

        try
        {
            startTime = ConvertStringToTimeSpan(addAccountScheduleRequest.StartTime);
            endTime = ConvertStringToTimeSpan(addAccountScheduleRequest.EndTime);
        }
        catch (FormatException ex)
        {
            throw new Exception(ex.Message);
        }

        var workingSchedule = new WorkingSchedule
        {
            Id = Guid.NewGuid(),
            StartTime = startTime,
            EndTime = endTime,
            WorkingDay = ConvertStringToDateTime(addAccountScheduleRequest.WorkingDay)
        };

        await _unitOfWork.WorkingScheduleRepository.AddAsync(workingSchedule);

        var existingLink = await _unitOfWork.AccountScheduleRepository
            .GetByAccountAndScheduleAsync(
                addAccountScheduleRequest.VeterinarianId,
                workingSchedule.Id);

        if (existingLink != null)
        {
            throw new Exception("This account is already assigned to the schedule.");
        }

        var accountSchedule = new AccountSchedule
        {
            AccountId = addAccountScheduleRequest.VeterinarianId,
            ScheduleId = workingSchedule.Id
        };

        await _unitOfWork.AccountScheduleRepository.AddAsync(accountSchedule);
        await _unitOfWork.SaveChangeAsync();

        var response = new AccountScheduleResponse
        {
            VeterinarianId = addAccountScheduleRequest.VeterinarianId,
            StartTime = addAccountScheduleRequest.StartTime,
            EndTime = addAccountScheduleRequest.EndTime,
            WorkingDay = addAccountScheduleRequest.WorkingDay
        };

        return response;
    }



    public async Task<IEnumerable<AccountScheduleResponse>> GetSchedulesByAccountIdAsync(Guid accountId)
    {
        var schedules = await _unitOfWork.AccountScheduleRepository.GetSchedulesByAccountIdAsync(accountId);

        if (schedules == null || !schedules.Any())
        {
            throw new Exception("No schedules found for this account.");
        }

        return schedules.Select(schedule => new AccountScheduleResponse
        {
            VeterinarianId = schedule.AccountId,
            StartTime = ConvertTimeSpanToString(schedule.WorkingSchedule.StartTime),
            EndTime = ConvertTimeSpanToString(schedule.WorkingSchedule.EndTime),
            WorkingDay = schedule.WorkingSchedule.WorkingDay.Date.ToString("yyyy-MM-dd")
        });
    }


    public async Task<AccountScheduleResponse?> GetAccountScheduleByIdAsync(Guid accountId, Guid scheduleId)
    {
        var accountSchedule = await _unitOfWork.AccountScheduleRepository
            .GetByAccountAndScheduleAsync(accountId, scheduleId);

        if (accountSchedule == null)
        {
            return null;
        }

        if (accountSchedule.WorkingSchedule == null)
        {
            throw new Exception("Working schedule not found for the specified account schedule.");
        }

        return new AccountScheduleResponse
        {
            VeterinarianId = accountSchedule.AccountId,
            StartTime = ConvertTimeSpanToString(accountSchedule.WorkingSchedule.StartTime),
            EndTime = ConvertTimeSpanToString(accountSchedule.WorkingSchedule.EndTime),
            WorkingDay = accountSchedule.WorkingSchedule.WorkingDay.ToString("yyyy-MM-dd"),
        };
    }


    public async Task UpdateAccountScheduleAsync(Guid accountId, Guid scheduleId, UpdateAccountScheduleRequest request)
    {
        var accountSchedule = await _unitOfWork.AccountScheduleRepository
            .GetByAccountAndScheduleAsync(accountId, scheduleId);

        if (accountSchedule == null)
        {
            throw new Exception("Account schedule not found.");
        }

        if (accountSchedule.WorkingSchedule == null)
        {
            throw new Exception("Working schedule not found for the specified account schedule.");
        }

        accountSchedule.WorkingSchedule.StartTime = ConvertStringToTimeSpan(request.StartTime);
        accountSchedule.WorkingSchedule.EndTime = ConvertStringToTimeSpan(request.EndTime);
        accountSchedule.WorkingSchedule.WorkingDay = ConvertStringToDateTime(request.WorkingDay);

        _unitOfWork.AccountScheduleRepository.Update(accountSchedule);
        await _unitOfWork.SaveChangeAsync();
    }

    public async Task DeleteAccountScheduleAsync(Guid accountId, Guid scheduleId)
    {
        var accountSchedule = await _unitOfWork.AccountScheduleRepository
            .GetByAccountAndScheduleAsync(accountId, scheduleId);

        if (accountSchedule == null)
        {
            throw new Exception("Account schedule not found.");
        }

        _unitOfWork.AccountScheduleRepository.SoftRemove(accountSchedule);
        await _unitOfWork.SaveChangeAsync();
    }

    public async Task<IEnumerable<AccountScheduleResponse>> GetAllAccountSchedulesAsync()
    {
        var accountSchedules = await _unitOfWork.AccountScheduleRepository.GetAllAsync();

        if (accountSchedules == null || !accountSchedules.Any())
        {
            throw new Exception("No account schedules found.");
        }

        return accountSchedules.Select(accountSchedule => new AccountScheduleResponse
        {
            VeterinarianId = accountSchedule.AccountId,
            StartTime = ConvertTimeSpanToString(accountSchedule.WorkingSchedule.StartTime),
            EndTime = ConvertTimeSpanToString(accountSchedule.WorkingSchedule.EndTime),
            WorkingDay = accountSchedule.WorkingSchedule.WorkingDay.Date.ToString("yyyy-MM-dd")
        });
    }

    public static TimeSpan ConvertStringToTimeSpan(string timeString)
    {
        if (TimeSpan.TryParse(timeString, out TimeSpan timeSpan))
        {
            return timeSpan;
        }
        else
        {
            throw new FormatException("Invalid TimeSpan format.");
        }
    }

    public static string ConvertTimeSpanToString(TimeSpan timeSpan)
    {
        return string.Format("{0:D2}:{1:D2}", (int)timeSpan.TotalHours, timeSpan.Minutes);
    }

    public static DateTime ConvertStringToDateTime(string dateString)
    {
        DateTime result;
        if (DateTime.TryParseExact(dateString, "yyyy-MM-dd",
                                    System.Globalization.CultureInfo.InvariantCulture,
                                    System.Globalization.DateTimeStyles.None,
                                    out result))
        {
            return result;
        }
        else
        {
            throw new FormatException("Invalid date format. Please use 'yyyy-MM-dd'.");
        }
    }


}

