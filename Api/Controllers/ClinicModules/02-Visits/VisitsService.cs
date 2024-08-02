﻿using App.Core;
using App.Core.Interfaces.SystemBase.Visits;
using App.Core.Models.ClinicModules.VisitsModules;
using App.Core.Models.ClinicModules.VisitsModules.DTO;
using App.Core.Models.General.BaseRequstModules;
using App.Core.Models.General.LocalModels;
using App.Core.Models.General.PaginationModule;
using AutoMapper;
using System.Linq.Expressions;

namespace Api.Controllers.SystemBase.Visits
{
    internal class VisitService : IVisitsServices
    {
        #region Members

        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        #endregion Members

        #region Constructor

        public VisitService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        #endregion Constructor

        #region Methods

        public async Task<VisitInfoDetails> GetDetails(VisitGetDetailsDTO inputModel)
        {
            var select = VisitsAdaptor.SelectExpressionVisitInfoDetails();

            Expression<Func<Visit, bool>> criteria = (x) => x.visitToken == inputModel.elementToken;

            var visitInfo = await _unitOfWork.Visits.FirstOrDefaultAsync(criteria, select);

            return visitInfo;
        }

        public async Task<BaseGetDataWithPagnation<VisitInfo>> GetAllAsync(VisitSearchDTO inputModel)
        {
            var select = VisitsAdaptor.SelectExpressionVisitInfo(inputModel.includeUserPatientInfoData);

            var criteria = GenrateCriteria(inputModel);

            PaginationRequest paginationRequest = inputModel;

            return await _unitOfWork.Visits.GetAllAsync(select, criteria, paginationRequest);
        }

        private List<Expression<Func<Visit, bool>>> GenrateCriteria(VisitSearchDTO inputModel)
        {
            List<Expression<Func<Visit, bool>>> criteria = [];

            if (inputModel.elementToken is not null)
                criteria.Add(x => x.visitToken == inputModel.elementToken);

            if (inputModel.userPatientToken is not null)
                criteria.Add(x => x.userPatientToken == inputModel.userPatientToken);

            if (inputModel.fullCode is not null)
                criteria.Add(x => x.fullCode == inputModel.fullCode);

            return criteria;
        }

        public async Task<BaseActionDone<VisitInfo>> AddOrUpdate(VisitAddOrUpdateDTO inputModel, bool isUpdate)
        {
            var visit = _mapper.Map<Visit>(inputModel);

            if (isUpdate)
                _unitOfWork.Visits.Update(visit);
            else
                await _unitOfWork.Visits.AddAsync(visit);

            var isDone = await _unitOfWork.CommitAsync();

            var visitInfo = await _unitOfWork.Visits.FirstOrDefaultAsync(x => x.visitToken == visit.visitToken, VisitsAdaptor.SelectExpressionVisitInfo());

            return BaseActionDone<VisitInfo>.GenrateBaseActionDone(isDone, visitInfo);
        }

        public async Task<BaseActionDone<VisitInfo>> DeleteAsync(BaseDeleteDto inputModel)
        {
            var visit = await _unitOfWork.Visits.FirstOrDefaultAsync(x => x.visitToken == inputModel.elementToken);

            _unitOfWork.Visits.Delete(visit);

            var isDone = await _unitOfWork.CommitAsync();

            return BaseActionDone<VisitInfo>.GenrateBaseActionDone(isDone, VisitsAdaptor.SelectExpressionVisitInfo(visit));
        }

        #endregion Methods
    }
}