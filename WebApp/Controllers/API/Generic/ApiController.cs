using AutoMapper;
using AutoMapper.Configuration;
using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
    public class ApiController<T, E, M> : ControllerBase
        where T : IDbRepository<E>
        where E : class, IDbEntity
        where M : class
    {
        Mapper _mapper;
        T _repository;
        public ApiController(T repository)
        {
            _repository = repository;
            var config = new MapperConfiguration(SetMapperConfiguration(new MapperConfigurationExpression()));
            _mapper = new Mapper(config);
        }

        virtual protected MapperConfigurationExpression SetMapperConfiguration(MapperConfigurationExpression mce)
        {
            mce.CreateMap<E, M>();
            mce.CreateMap<M, E>();
            return mce;
        }
        //[HttpGet]
        //virtual public async Task<IEnumerable<E>> Get()
        //{
        //    return await _repository.ToListAsync();
        //}
        virtual protected M MapSingleItem(E e)
        {
            return _mapper.Map<M>(e);
        }
        virtual protected async Task<List<M>> MapListItems(IQueryable<E> qurable)
        {
            //var tmp = await qurable.ToListAsync();
            return _mapper.Map<List<M>>(await qurable.ToListAsync());
            //return tmp2;
        }
        [HttpGet]
        virtual public async Task<PaginationAnswerModel<M>> Get([FromQuery] PaginatorModel paginator)
        {
            int total = await _repository.AllItems.CountAsync();
            return new PaginationAnswerModel<M> { Rows = await MapListItems(_repository.AllItems), Total = total };
        }

        [HttpGet("{id}")]
        virtual public async Task<M> Get(Guid id)
        {
            return MapSingleItem(await _repository.GetItemAsync(id));
        }
        [HttpPost]
        virtual public async Task<ActionResult> Post(M faculty)
        {
            if (await _repository.AddItemAsync(_mapper.Map<E>(faculty)) > 0)
            {
                return new StatusCodeResult(200);
            }
            else
                return new StatusCodeResult(500);
        }

        [HttpPut]
        virtual public async Task<ActionResult> Put(M faculty)
        {
            if (await _repository.UpdateItemAsync(_mapper.Map<E>(faculty)))
            {
                return new StatusCodeResult(200);
            }
            else
                return new StatusCodeResult(500);
        }

        [HttpDelete("{id}")]
        virtual public async Task<ActionResult> Delete(Guid id)
        {
            if (await _repository.DeleteItem(id))
            {
                return new StatusCodeResult(200);
            }
            else
                return new StatusCodeResult(500);
        }
    }
}

