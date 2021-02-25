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

namespace WebApp.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ApiController<IStudentRepository, Student, StudentModel>
    {
        private readonly IStudentRepository _repository;

        public StudentController(IStudentRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public override async Task<PaginationAnswerModel<StudentModel>> Get([FromQuery] PaginatorModel paginator)
        {
            int total = await _repository.AllItems.CountAsync();
            IQueryable<Student> query = AbstractModel.GetModelsFromRepository(_repository.AllItems, paginator);
            query = StudentModel.IncludeNavigations(query);
            return new PaginationAnswerModel<StudentModel> { Rows = await MapListItems(query), Total = total };
        }

        protected override MapperConfigurationExpression SetMapperConfiguration(MapperConfigurationExpression mce)
        {
            var smc = base.SetMapperConfiguration(mce);
            smc.CreateMap<Faculty, FacultyModel>().ForMember(x => x.Groups, opt => opt.Ignore());
            smc.CreateMap<Group, GroupModel>().ForMember(x=>x.Students, opt=>opt.Ignore());
            return smc;
        }
    }
}
