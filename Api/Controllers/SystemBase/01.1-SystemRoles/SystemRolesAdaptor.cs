﻿using Api.Controllers.SystemBase.BaseEntitys;
using App.Core.Models.SystemBase.Roles;
using App.Core.Models.SystemBase.Roles.ViewModel;
using System.Linq.Expressions;

namespace Api.Controllers.SystemBase.SystemRoles
{
    public static class SystemRolesAdaptor
    {
        public static Expression<Func<SystemRole, SystemRoleInfo>> SelectExpressionSystemRoleInfo()
        {
            return systemRole => new SystemRoleInfo
            {
                systemRoleToken = systemRole.systemRoleToken,
                systemRoleName = systemRole.systemRoleName,
                isDeleted = BaseEntitiesAdaptor.SelectExpressionBaseEntityInfo(systemRole).isDeleted,
                updatedDateTime = BaseEntitiesAdaptor.SelectExpressionBaseEntityInfo(systemRole).updatedDateTime,
                createdDateTime = BaseEntitiesAdaptor.SelectExpressionBaseEntityInfo(systemRole).createdDateTime
            };
        }

        public static Expression<Func<SystemRole, SystemRoleInfoDetails>> SelectExpressionSystemRoleDetails()
        {
            return systemRole => new SystemRoleInfoDetails
            {
                systemRoleToken = systemRole.systemRoleToken,
                systemRoleName = systemRole.systemRoleName,
                isDeleted = BaseEntitiesAdaptor.SelectExpressionBaseEntityInfo(systemRole).isDeleted,
                updatedDateTime = BaseEntitiesAdaptor.SelectExpressionBaseEntityInfo(systemRole).updatedDateTime,
                createdDateTime = BaseEntitiesAdaptor.SelectExpressionBaseEntityInfo(systemRole).createdDateTime
            };
        }

        public static SystemRoleInfo SelectExpressionSystemRoleInfo(SystemRole systemRole)
        {
            if (systemRole == null)
                return null;

            return new SystemRoleInfo
            {
                systemRoleToken = systemRole.systemRoleToken,
                systemRoleName = systemRole.systemRoleName,
                isDeleted = BaseEntitiesAdaptor.SelectExpressionBaseEntityInfo(systemRole).isDeleted,
                updatedDateTime = BaseEntitiesAdaptor.SelectExpressionBaseEntityInfo(systemRole).updatedDateTime,
                createdDateTime = BaseEntitiesAdaptor.SelectExpressionBaseEntityInfo(systemRole).createdDateTime
            };
        }

        public static SystemRoleInfoDetails SelectExpressionSystemRoleDetails(SystemRole systemRole)
        {
            if (systemRole == null)
                return null;

            return new SystemRoleInfoDetails
            {
                systemRoleToken = systemRole.systemRoleToken,
                systemRoleName = systemRole.systemRoleName,
                isDeleted = BaseEntitiesAdaptor.SelectExpressionBaseEntityInfo(systemRole).isDeleted,
                updatedDateTime = BaseEntitiesAdaptor.SelectExpressionBaseEntityInfo(systemRole).updatedDateTime,
                createdDateTime = BaseEntitiesAdaptor.SelectExpressionBaseEntityInfo(systemRole).createdDateTime
            };
        }
    }
}