﻿using App.Core.Models.Users;

namespace App.Core.Models.ClinicModules.OperationsModules
{
    public class OperationInfoDetails : OperationInfo
    {
        public UserInfo userPatientInfo { get; set; }
    }
}