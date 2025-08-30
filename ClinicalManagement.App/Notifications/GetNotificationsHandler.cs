using AutoMapper;
using ClinicalManagement.Application.Abstractions.DbContext;
using ClinicalManagement.Application.Common.Result;
using ClinicalManagement.Application.Dtos.NotificationsDto;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicalManagement.Application.Notifications
{
    public class GetNotificationsHandler : IRequestHandler<GetNotifications, Result<List<NotifyDto>>>
    {
        private readonly IAppDbContext appDbContext;
        private readonly IMapper mapper;

        public GetNotificationsHandler(IAppDbContext appDbContext, IMapper mapper)
        {
            this.appDbContext = appDbContext;
            this.mapper = mapper;
        }

        Task<Result<List<NotifyDto>>> IRequestHandler<GetNotifications, Result<List<NotifyDto>>>.Handle(GetNotifications request, CancellationToken cancellationToken)
        {
            var res =  appDbContext.Notifications.Where(x => x.UserId.Equals(request.Id));
            var notications = mapper.Map<List<NotifyDto>>(res);
            return Task.FromResult(Result<List<NotifyDto>>.Success(notications));
        }
    }
}
