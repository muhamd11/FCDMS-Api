﻿using App.Core.Models.General.BaseRequstModules;
using System;

namespace App.Core.Models.UsersModule.LogActionsModel.DTO
{
    public class LogActionSearchDto : BaseSearchDto
    {
        public string modelName { get; set; }
        public Guid? userToken { get; set; }
    }
}