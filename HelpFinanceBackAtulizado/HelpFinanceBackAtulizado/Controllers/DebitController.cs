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
        // [ValidateAntiForgeryToken]
        public async Task<ActionResult> Post([FromBody] Debit debit)
        {
            if (debit != null)
            {
                try
                {
                    var debitDb = _context.Debit.Find(debit.id);
                    if (debitDb != null)
                    {
                        _context.Debit.Remove(debitDb);
                        await _context.SaveChangesAsync();
                        return StatusCode(200);


                    }
                    else
                    {
                        _context.Debit.Add(debit);
                        await _context.SaveChangesAsync();
                        return StatusCode(200);
                    }
                }
                catch (Exception ex)
                {
                    return StatusCode(500);
                }


            }
            else
            {
                return StatusCode(400);
            }


        }



        [HttpPut]
        public async Task<Debit> Edit(int id, Debit debit)
        {
            Debit debitdb = default(Debit);
            if (id == 0)
            {
                debitdb = _context.Debit.Find(id);
            }
            debitdb.category = debit.category;
            debitdb.description = debit.description;
            debitdb.value = debit.value;

            await _context.SaveChangesAsync();

            return debit;
        }

    }
}