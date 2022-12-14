using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
     [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class UsersController : BaseApiController
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;
        public UsersController(IUserRepository repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }
        [HttpGet]
       
        public async Task<IEnumerable<MemberDto>> GetUsers(){
            var users = await _repository.GetMembersAsync();
             return users; //Ok()
        }

           [HttpGet("{username}")]
          
        public async Task<MemberDto> GetUser(string username){
             return await _repository.GetMemberAsync(username);

          
        }

    
    }
}