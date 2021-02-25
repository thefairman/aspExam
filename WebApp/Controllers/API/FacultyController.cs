using AutoMapper.Configuration;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models;
using WebApp.Models.Helpers;

namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacultyController : ApiController<IFacultyRepository, Faculty, FacultyModel>
    {
        private readonly IFacultyRepository _repository;

        public FacultyController(IFacultyRepository repository) : base(repository)
        {
            this._repository = repository;
        }

        [HttpGet("WithGroups")]
        public async Task<PaginationAnswerModel<FacultyModel>> GetWithGroups([FromQuery] PaginatorModel paginator)
        {
            int total = await _repository.AllItems.CountAsync();
            IQueryable<Faculty> query = AbstractModel.GetModelsFromRepository(_repository.AllItems, paginator);
            query = FacultyModel.IncludeNavigations(query);
            return new PaginationAnswerModel<FacultyModel> { Rows = await MapListItems(query), Total = total };
        }

        protected override MapperConfigurationExpression SetMapperConfiguration(MapperConfigurationExpression mce)
        {
            var smc = base.SetMapperConfiguration(mce);
            smc.CreateMap<Group, GroupModel>().ForMember(x => x.Faculty, opt => opt.Ignore());
            return smc;
        }
    }
}
