using Azure.Core;
using ClinicalManagement.Application.Abstractions.Caching;
using ClinicalManagement.Domain.Models;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicalManagement.Infrastructure.Services.Caching
{
    public class RedisCaching : ICachingServices
    {
        private readonly IDistributedCache _cache;

        public RedisCaching(IDistributedCache cache)
        {
            _cache = cache;
        }

        public async Task<bool> AcquireLockAsync(Appointment appointment, string lockValue)
        {
            var slot = NormalizeToSlot(appointment.AppointmentDate, 15);
            var lockKey = $"appointment:doctor:{appointment.DoctorId}:slot:{slot:yyyyMMddHHmm}";
            var expiry = TimeSpan.FromSeconds(30);

            var existing = await _cache.GetStringAsync(lockKey);
            if (existing != null)
                return false; 

            var options = new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = expiry
            };

            await _cache.SetStringAsync(lockKey, lockValue, options);
            return true;
        }

        public async Task ReleaseLockAsync(string key)
        {
           await  _cache.RemoveAsync(key);
        }
        public  DateTime NormalizeToSlot(DateTime utcDateTime, int minutes = 15)
        {
            if (utcDateTime.Kind != DateTimeKind.Utc) utcDateTime = utcDateTime.ToUniversalTime();
            var ticksPerSlot = TimeSpan.FromMinutes(minutes).Ticks;
            var normalizedTicks = (utcDateTime.Ticks / ticksPerSlot) * ticksPerSlot;
            return new DateTime(normalizedTicks, DateTimeKind.Utc);
        }
    }
}
