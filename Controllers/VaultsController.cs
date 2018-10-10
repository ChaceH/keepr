using System;
using System.Collections.Generic;
using keepr.Models;
using keepr.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace keepr.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VaultsController : Controller
    {
        VaultsRepository _repo;
        private readonly UserManager<User> manager;
        public VaultsController(VaultsRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IEnumerable<Vault> Get()
        {
            return _repo.GetAll();
        }

        [Authorize]
        [HttpPost]
       public Vault Post([FromBody] Vault rawVault)
       {
           if (!ModelState.IsValid) throw new Exception("Invalid Vault.");
           Vault vault = _repo.Create(rawVault);
           if (vault == null) throw new Exception("Error inserting Vault into the db.");
           return vault;
       }

        [Authorize]
       [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            return _repo.Delete(id);
        }
   }
};