﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VariacaoAtivo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VariacaoAtivoController : ControllerBase
    {
        // GET: api/<VariacaoAtivoController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<VariacaoAtivoController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<VariacaoAtivoController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
            //https://query2.finance.yahoo.com/v8/finance/chart/BTC-USD?interval=1d&period1=1653620400&period2=1679024934
        }

        // PUT api/<VariacaoAtivoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<VariacaoAtivoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
