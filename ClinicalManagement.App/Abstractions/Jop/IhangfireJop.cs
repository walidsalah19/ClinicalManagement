﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicalManagement.Application.Abstractions.Jop
{
    public interface IhangfireJop
    {
        public Task CreateScheduleJop();
    }
}
