using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using helpFinanceDotNet.Data;
using helpFinanceDotNet.Models;
using Microsoft.AspNetCore.Mvc;

namespace helpFinanceDotNet.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DebitController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public DebitController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Debit> Get()
        {
            var lista = _context.Debit.ToList();
            return lista;
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task< IActionResult>  post(Debit debit)
        {
            if (debit != null)
            {
                _context.Debit.Add(debit);
                await _context.SaveChangesAsync();
            }
            return StatusCode(200);
        }

        [HttpDelete]
        public  IActionResult  delete(int id)
        {
            var debit = _context.Debit.Find(id);
            _context.Debit.Remove(debit);
            return StatusCode(200);
        }

        [HttpPut]
        public async Task<Debit> edit(int id, Debit debit ){
            Debit debitdb = default(Debit);
            if(id == 0){
                debitdb = _context.Debit.Find(id);
            }
            debitdb.category = debit.category;
            debitdb.description = debit.description;
            debitdb.value = debit.value;

            await  _context.SaveChangesAsync();

            return debit;
        }
       
    }
}