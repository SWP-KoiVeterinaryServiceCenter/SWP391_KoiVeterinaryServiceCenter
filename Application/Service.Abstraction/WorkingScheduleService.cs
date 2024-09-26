﻿using Application;
using Application.IService.Abstraction;
using Application.Model.WorkingScheduleModel;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class WorkingScheduleService : IWorkingScheduleService
{
    private readonly IUnitOfWork _unitOfWork;

    public WorkingScheduleService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<WorkingScheduleResponse>> GetAllAsync()
    {
        var schedules = await _unitOfWork.WorkingScheduleRepository.GetAllAsync();
        return schedules.Select(ws => new WorkingScheduleResponse
        {
            Id = ws.Id,
            StartTime = ws.StartTime,
            EndTime = ws.EndTime,
            DayOfWeek = ws.DayOfWeek
        });
    }

    public async Task<WorkingScheduleResponse> GetByIdAsync(Guid id)
    {
        var workingSchedule = await _unitOfWork.WorkingScheduleRepository.GetByIdAsync(id);
        if (workingSchedule == null) return null;

        return new WorkingScheduleResponse
        {
            Id = workingSchedule.Id,
            StartTime = workingSchedule.StartTime,
            EndTime = workingSchedule.EndTime,
            DayOfWeek = workingSchedule.DayOfWeek
        };
    }

    public async Task<WorkingScheduleResponse> CreateAsync(AddWorkingScheduleRequest request)
    {
        var workingSchedule = new WorkingSchedule
        {
            StartTime = request.StartTime,
            EndTime = request.EndTime,
            DayOfWeek = request.DayOfWeek
        };

        await _unitOfWork.WorkingScheduleRepository.AddAsync(workingSchedule);
        await _unitOfWork.SaveChangeAsync();

        return new WorkingScheduleResponse
        {
            Id = workingSchedule.Id,
            StartTime = workingSchedule.StartTime,
            EndTime = workingSchedule.EndTime,
            DayOfWeek = workingSchedule.DayOfWeek
        };
    }

    public async Task UpdateAsync(UpdateWorkingScheduleRequest request)
    {
        var workingSchedule = await _unitOfWork.WorkingScheduleRepository.GetByIdAsync(request.Id);
        if (workingSchedule != null)
        {
            workingSchedule.StartTime = request.StartTime;
            workingSchedule.EndTime = request.EndTime;
            workingSchedule.DayOfWeek = request.DayOfWeek;

            _unitOfWork.WorkingScheduleRepository.Update(workingSchedule);
            await _unitOfWork.SaveChangeAsync();
        }
    }

    public async Task DeleteAsync(Guid id)
    {
        var workingSchedule = await _unitOfWork.WorkingScheduleRepository.GetByIdAsync(id);
        if (workingSchedule != null)
        {
            _unitOfWork.WorkingScheduleRepository.SoftRemove(workingSchedule);
            await _unitOfWork.SaveChangeAsync();
        }
    }

    public async Task<IEnumerable<WorkingScheduleResponse>> GetAllByAccountIdAsync(Guid accountId)
    {
        var schedules = await _unitOfWork.WorkingScheduleRepository.FindAsync(ws => ws.Accounts.Any(a => a.Id == accountId));
        return schedules.Select(ws => new WorkingScheduleResponse
        {
            Id = ws.Id,
            StartTime = ws.StartTime,
            EndTime = ws.EndTime,
            DayOfWeek = ws.DayOfWeek
        });
    }
}