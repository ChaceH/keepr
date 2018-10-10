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
    public class KeepsController : Controller
    {
        KeepsRepository _repo;
        private readonly UserManager<User> manager;
        public KeepsController(KeepsRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IEnumerable<Keep> Get()
        {
            return _repo.GetAll();
        }

        [Authorize]
        [HttpPost]
       public Keep Post([FromBody] Keep rawKeep)
       {
           if (!ModelState.IsValid) throw new Exception("Not a valid Keep.");
           Keep keep = _repo.Create(rawKeep);
           if (keep == null) throw new Exception("Error inserting keep into the db.");
           return keep;
       }

        [Authorize]
       [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            return _repo.Delete(id);
        }
   }
};