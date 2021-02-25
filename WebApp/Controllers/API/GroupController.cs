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
    public class GroupController : ApiController<IGroupRepository, Group, GroupModel>
    {
        private readonly IGroupRepository _repository;
        public GroupController(IGroupRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public override async Task<PaginationAnswerModel<GroupModel>> Get([FromQuery] PaginatorModel paginator)
        {
            int total = await _repository.AllItems.CountAsync();
            IQueryable<Group> query = AbstractModel.GetModelsFromRepository(_repository.AllItems, paginator);
            query = GroupModel.IncludeNavigations(query);
            return new PaginationAnswerModel<GroupModel> { Rows = await MapListItems(query), Total = total };
        }

        protected override MapperConfigurationExpression SetMapperConfiguration(MapperConfigurationExpression mce)
        {
            var smc = base.SetMapperConfiguration(mce);
            smc.CreateMap<Faculty, FacultyModel>().ForMember(x => x.Groups, opt => opt.Ignore());
            return smc;
        }
    }
}
