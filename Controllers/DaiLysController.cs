using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using System.IdentityModel.Tokens.Jwt;
using veso_be.Helpers;
using Microsoft.Extensions.Options;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using veso_be.Repositories;
using veso_be.Dtos;
using veso_be.Entities;
using System.Linq;

namespace veso_be.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class DaiLysController : ControllerBase
    {
        private IDaiLyRepository _dailyRepository;
        private IMapper _mapper;
        private readonly AppSettings _appSettings;
 
        public DaiLysController(
            IDaiLyRepository dailyRepository,
            IMapper mapper,
            IOptions<AppSettings> appSettings)
        {
            _dailyRepository = dailyRepository;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }
 
        [AllowAnonymous]
        [HttpPost("register")]
        public IActionResult Register([FromBody]DaiLyDto dailyDto)
        {
            // map dto to entity
            var daily = _mapper.Map<DaiLy>(dailyDto);
 
            try
            {
                // save dai ly
                var flag=_dailyRepository.Create(daily);
                return Ok(new {success = flag});
            } 
            catch(AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }
 
        [HttpGet]
        public IActionResult GetAll()
        {
            // var users =  _userService.GetAll();
            // var userDtos = _mapper.Map<IList<UserDto>>(users);
            // return Ok(userDtos);
            return Ok();
        }
 
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            // var user =  _userService.GetById(id);
            // var userDto = _mapper.Map<UserDto>(user);
            // return Ok(userDto);
            return Ok();
        }
 
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody]DaiLyDto dailyDto)
        {
            // map dto to entity and set id
            var daily = _mapper.Map<DaiLy>(dailyDto);
            daily.Id = id;
 
            try
            {
                // save 
                // _userService.Update(user, userDto.Password);
                return Ok();
            } 
            catch(AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }
 
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            // _userService.Delete(id);
            return Ok();
        }
    }
}