﻿using App.Core.Models.GeneralModels.BaseRequstModules;
using Microsoft.AspNetCore.Mvc;
using System;

namespace App.Core.Models.General.BaseRequstModules
{
    public class BaseDeleteDto : GeneralOperation
    {
        [FromQuery] public Guid elementToken { get; set; }
    }
}