using HomeBudget.API.Data;
using HomeBudget.API.Models.Domain.Users;
using HomeBudget.API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HomeBudget.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserTypeController : ControllerBase
    {
        //private readonly IRepository<UserType> repository;

        //public UserTypeController(IRepository<UserType> repository)
        //{
        //    this.repository = repository;
        //}
        //// GET UserType
        //// GET: api/UserType
        //[HttpGet]
        //public async Task<IActionResult> GetAllUserTypes()
        //{
        //    return Ok(await repository.GetAllAsync());
        //}
        //// GET UserType/5
        //// GET: api/UserType/5
        //[HttpGet]
        //[Route("{id:guid}")]
        //public async Task<IActionResult> GetUserTypeById(Guid id)
        //{
        //    try
        //    {
        //        var userType = await repository.GetByIdAsync(id);
        //        return Ok(userType);
        //    }
        //    catch (KeyNotFoundException ex)
        //    {
        //        return NotFound(ex.Message);
        //    }
        //}
        //// POST UserType
        //// POST: api/UserType
        //[HttpPost]
        //public async Task<IActionResult> CreateUserType([FromBody] UserType userType)
        //{
        //    if (userType == null)
        //    {
        //        return BadRequest("UserType cannot be null.");
        //    }
        //    await repository.CreateAsync(userType);
        //    return Ok();
        //}
        //// PUT UserType
        //// PUT: api/UserType/5
        //[HttpPut]
        //[Route("{id:guid}")]
    }
}
