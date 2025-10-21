﻿using BusTicketReservationSystem.Application.Contracts.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTicketReservationSystem.Application.Contracts.Interfaces
{
    public interface IBookingService
    {
        Task<SeatPlanDto> GetSeatPlanAsync(Guid busScheduleId);
        Task<BookSeatResultDto> BookSeatAsync(BookSeatInputDto input);
    }
}
