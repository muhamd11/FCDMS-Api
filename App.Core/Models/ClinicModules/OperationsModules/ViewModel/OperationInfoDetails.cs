﻿using App.Core.Models.Users;

namespace App.Core.Models.ClinicModules.VisitsModules
{
    public class OperationInfoDetails : OperationInfo
    {
        public UserInfo userPatientInfo { get; set; }
    }
}