﻿using Api.Controllers.UsersModules._01._2_UserAuthentications;
using Api.Controllers.UsersModules.Users.Interfaces;
using App.Core;
using App.Core.Consts.GeneralModels;
using App.Core.Consts.SystemBase;
using App.Core.Helper.Validations;
using App.Core.Interfaces.SystemBase.SystemRoles;
using App.Core.Interfaces.UsersModule.UserAuthentications;
using App.Core.Interfaces.UsersModule.UserTypes.UserProfiles;
using App.Core.Models.General.BaseRequstModules;
using App.Core.Models.General.LocalModels;
using App.Core.Models.Users;
using App.Core.Resources.General;
using App.Core.Resources.UsersModules.User;

namespace Api.Controllers.UsersModule.Users
{
    internal class UsersValid : IUsersValid
    {
        #region Members

        private readonly IUnitOfWork _unitOfWork;
        private readonly IAuthorized _authorized;
        private readonly ISystemRolesValid _systemRolesValid;
        private readonly IUserProfileValid _userProfileValid;

        private readonly string userView = $"{nameof(User)}_{nameof(EnumFunctionsType.view)}";
        private readonly string userAdd = $"{nameof(User)}_{nameof(EnumFunctionsType.add)}";
        private readonly string userUpdate = $"{nameof(User)}_{nameof(EnumFunctionsType.update)}";
        private readonly string userDelete = $"{nameof(User)}_{nameof(EnumFunctionsType.delete)}";

        #endregion Members

        #region Constructor

        public UsersValid(IUnitOfWork unitOfWork, IAuthorized authorized, ISystemRolesValid systemRolesValid, IUserProfileValid userProfileValid)
        {
            _unitOfWork = unitOfWork;
            _authorized = authorized;
            _systemRolesValid = systemRolesValid;
            _userProfileValid = userProfileValid;
        }

        #endregion Constructor

        #region Methods

        public BaseValid ValidGetAll(BaseSearchDto inputModel)
        {
            #region isAuthorizedUser *

            var isAuthorizedUser = _authorized.IsAuthorizedUser(userView);

            if (isAuthorizedUser.Status != EnumStatus.success)
                return isAuthorizedUser;

            #endregion isAuthorizedUser *

            if (inputModel is not null)
            {
                #region elemetId?

                if (inputModel.elementToken is not null)
                {
                    var isValidUserToken = IsValidUserToken((Guid)inputModel.elementToken);
                    if (isValidUserToken.Status != EnumStatus.success)
                        return isValidUserToken;
                }

                #endregion elemetId?

                return BaseValid.createBaseValid(GeneralMessagesAr.operationSuccess, EnumStatus.success);
            }
            else
                return BaseValid.createBaseValid(GeneralMessagesAr.errorNoData, EnumStatus.error);
        }

        public BaseValid ValidGetDetails(BaseGetDetailsDto inputModel)
        {
            #region isAuthorizedUser *

            var isAuthorizedUser = _authorized.IsAuthorizedUser(userView);

            if (isAuthorizedUser.Status != EnumStatus.success)
                return isAuthorizedUser;

            #endregion isAuthorizedUser *

            if (inputModel is not null)
            {
                var isValidUserToken = IsValidUserToken(inputModel.elementToken);
                if (isValidUserToken.Status != EnumStatus.success)
                    return isValidUserToken;

                return BaseValid.createBaseValid(GeneralMessagesAr.operationSuccess, EnumStatus.success);
            }
            else
                return BaseValid.createBaseValid(GeneralMessagesAr.errorNoData, EnumStatus.error);
        }

        public BaseValid ValidAddOrUpdate(UserAddOrUpdateDTO inputModel, bool isUpdate)
        {
            #region isAuthorizedUser *

            var isAuthorizedUser = _authorized.IsAuthorizedUser(userAdd);

            if (isAuthorizedUser.Status != EnumStatus.success)
                return isAuthorizedUser;

            #endregion isAuthorizedUser *

            if (inputModel is not null)
            {
                #region isAuthorizedUser *

                isAuthorizedUser = _authorized.IsAuthorizedUser(userUpdate);

                if (isAuthorizedUser.Status != EnumStatus.success)
                    return isAuthorizedUser;

                #endregion isAuthorizedUser *

                #region userId?

                if (isUpdate)
                {
                    var isValidUserToken = IsValidUserToken(inputModel.userToken);
                    if (isValidUserToken.Status != EnumStatus.success)
                        return isValidUserToken;
                }

                #endregion userId?

                #region ValidUserData*

                var isValidUserData = ValidUserData(inputModel);
                if (isValidUserData.Status != EnumStatus.success)
                    return isValidUserData;

                #endregion ValidUserData*

                return BaseValid.createBaseValid(GeneralMessagesAr.operationSuccess, EnumStatus.success);
            }
            else
                return BaseValid.createBaseValid(GeneralMessagesAr.errorNoData, EnumStatus.error);
        }

        public BaseValid ValidUserData(UserAddOrUpdateDTO inputModel)
        {
            #region userName &&  userLoginName && userEmail

            if (!ValidationClass.IsValidString(inputModel.userLoginName) && !ValidationClass.IsValidString(inputModel.userEmail) && !ValidationClass.IsValidString(inputModel.userPhone))
                return BaseValid.createBaseValidError(GeneralMessagesAr.errorSendLoginData);

            #endregion userName &&  userLoginName && userEmail

            #region userName ?

            if (!ValidationClass.IsValidString(inputModel.userName))
            {
                int nameMaxLength = (int)EnumMaxLength.nameMaxLength;
                if (!ValidationClass.IsValidStringLength(inputModel.userName, nameMaxLength))
                    return BaseValid.createBaseValid(string.Format(GeneralMessagesAr.errorNameLength, nameMaxLength), EnumStatus.error);
            }

            #endregion userName ?

            #region userEmail ?

            if (ValidationClass.IsValidString(inputModel.userEmail) && !ValidationClass.IsValidEmail(inputModel.userEmail))
                return BaseValid.createBaseValid(GeneralMessagesAr.errorInvalidEmail, EnumStatus.error);

            #endregion userEmail ?

            #region userPhoneNumber *

            if (ValidationClass.IsValidString(inputModel.userPhone) && !ValidationClass.IsValidPhoneNumber(inputModel.userPhoneCC, inputModel.userPhone))
                return BaseValid.createBaseValid(GeneralMessagesAr.ErrorInvalidPhoneNumber, EnumStatus.error);

            #endregion userPhoneNumber *

            #region userType *

            if (!ValidationClass.IsEnumValue(inputModel.userTypeToken))
                return BaseValid.createBaseValid(UsersMessagesAr.errorUserTypeInvalid, EnumStatus.error);

            #endregion userType *

            #region ValidSystemRoleId *

            if (inputModel.systemRoleToken.HasValue == true)
            {
                var isValidSystemRoleId = _systemRolesValid.ValidSystemRoleToken(inputModel.systemRoleToken);
                if (isValidSystemRoleId.Status != EnumStatus.success)
                    return isValidSystemRoleId;
            }
            else
            {
                var defaultSystemRole = _unitOfWork.SystemRoles.FirstOrDefault(x => x.systemRoleCanUseDefault == true && x.userTypeToken == inputModel.userTypeToken);
                if (defaultSystemRole == null) //TODO Change Message
                    return BaseValid.createBaseValid("لا يوجد صلاحية افتراضية الرجاء اضافة صلاحية", EnumStatus.error);
            }

            #endregion ValidSystemRoleId *

            #region validUserWasAddedBefore

            var existingUser = _unitOfWork.Users.FirstOrDefault(x => x.userName == inputModel.userName
                                || x.userEmail == inputModel.userEmail
                                || x.userPhone == inputModel.userPhone
                                || x.userLoginName == inputModel.userLoginName
                                || x.fullCode == inputModel.fullCode);

            if (existingUser is not null && existingUser.userToken != inputModel.userToken && existingUser.userName == inputModel.userName)
                return BaseValid.createBaseValid(UsersMessagesAr.errorUsernameWasAdded, EnumStatus.error);

            if (existingUser is not null && existingUser.userToken != inputModel.userToken && existingUser.userEmail == inputModel.userEmail)
                return BaseValid.createBaseValid(UsersMessagesAr.errorUserEmailWasAdded, EnumStatus.error);

            if (existingUser is not null && existingUser.userToken != inputModel.userToken && existingUser.userPhone == inputModel.userPhone)
                return BaseValid.createBaseValid(UsersMessagesAr.errorUserPhoneNumberWasAdded, EnumStatus.error);

            if (existingUser is not null && existingUser.userToken != inputModel.userToken && existingUser.userLoginName == inputModel.userLoginName)
                return BaseValid.createBaseValid(UsersMessagesAr.errorUserLoginNameWasAdded, EnumStatus.error);

            if (existingUser is not null && existingUser.userToken != inputModel.userToken && existingUser.fullCode == inputModel.fullCode)
                return BaseValid.createBaseValid(UsersMessagesAr.errorUserFullCodeWasAdded, EnumStatus.error);

            #endregion validUserWasAddedBefore

            #region validUserProfile

            if (inputModel.userProfileData != null)
            {
                var isValidUserProfile = _userProfileValid.IsValidUserProfile(inputModel.userProfileData);
                if (isValidUserProfile.Status != EnumStatus.success)
                    return isValidUserProfile;
            }

            #endregion validUserProfile

            return BaseValid.createBaseValid(GeneralMessagesAr.operationSuccess, EnumStatus.success);
        }

        public BaseValid ValidDelete(BaseDeleteDto inputModel)
        {
            #region isAuthorizedUser *

            var isAuthorizedUser = _authorized.IsAuthorizedUser(userDelete);
            if (isAuthorizedUser.Status != EnumStatus.success)
                return isAuthorizedUser;

            #endregion isAuthorizedUser *

            if (inputModel is not null)
            {
                var isValidUserToken = IsValidUserToken(inputModel.elementToken);
                if (isValidUserToken.Status != EnumStatus.success)
                    return isValidUserToken;

                return BaseValid.createBaseValid(GeneralMessagesAr.operationSuccess, EnumStatus.success);
            }
            else
                return BaseValid.createBaseValid(GeneralMessagesAr.errorNoData, EnumStatus.error);
        }

        public BaseValid IsValidUserToken(Guid userToken)
        {
            var user = _unitOfWork.Users.FirstOrDefault(x => x.userToken == userToken);
            if (user is not null)
                return BaseValid.createBaseValid(GeneralMessagesAr.operationSuccess, EnumStatus.success);
            else
                return BaseValid.createBaseValid(UsersMessagesAr.errorUserDoesNotExists, EnumStatus.error);
        }

        #endregion Methods
    }
}