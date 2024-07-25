﻿using App.Core.Models.Buyers;
using App.Core.Models.UsersModule._01._1_UserTypes._02_UserClientData.ViewModel;
using App.Core.Models.UsersModule._01_1_UserTypes._02_UserPatientData;
using System.Linq.Expressions;

namespace Api.Controllers.UsersModule.Users
{
    public static class UserPatientsAdaptor
    {
        public static Expression<Func<UserPatient, UserPatientInfo>> SelectExpressionUserClientInfo()
        {
            return user => new UserPatientInfo
            {
                //TODO: Add Whislist Adaptor
            };
        }

        public static UserPatientInfo SelectExpressionUserClientInfo(UserPatient user)
        {
            if (user == null)
                return null;

            return new UserPatientInfo
            {
                //TODO: Add Whislist Adaptor
            };
        }
    }
}