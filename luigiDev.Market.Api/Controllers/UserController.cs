﻿using luigiDev.Market.Entities;
using luiguiDev.Market.Business.UserBusiness;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;

namespace luigiDev.Market.Api.Controllers
{
    /// <summary>
    /// This api allows to process transactions related to User
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        readonly IUserBusiness userBusiness;
        public UserController(IUserBusiness userBusiness)
        {
            this.userBusiness = userBusiness;
        }

        /// <summary>
        /// Creates the specified user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns></returns>
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create([FromBody]User user)
        {
            try
            {
                return Ok(await userBusiness.CreateUserAsync(user));
            }
            catch (Exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        /// <summary>
        /// Deletes the specified user identifier.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        [HttpPost]
        [Route("Delete/{userId}")]
        public async Task<IActionResult> Delete(Guid userId)
        {
            try
            {
                return Ok(await userBusiness.DeleteUserAsync(userId));
            }
            catch (Exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        /// <summary>
        /// Logins the specified email.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromHeader]string email, [FromHeader]string password)
        {
            try
            {
                return Ok(await userBusiness.LoginUserAsync(email, password));
            }
            catch (Exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }
    }
}
