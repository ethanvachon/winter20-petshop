using petshop.Models;
using petshop.db;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace petshop.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class DogsController : ControllerBase
  {
    [HttpGet]
    public ActionResult<IEnumerable<Dog>> Get()
    {
      try
      {
        return Ok(FAKEDB.Dogs);
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }
    }

    [HttpGet("{id}")]
    public ActionResult<Dog> GetDogById(string id)
    {
      try
      {
        Dog dogToReturn = FAKEDB.Dogs.Find(d => d.Id == id);
        return Ok(dogToReturn);
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }
    }

    [HttpPost]
    public ActionResult<Dog> Create([FromBody] Dog newDog)
    {
      try
      {
        FAKEDB.Dogs.Add(newDog);
        return Ok(newDog);
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }
    }
    [HttpPut("{id}")]
    public ActionResult<Dog> Edit([FromBody] Dog editDog, string id)
    {
      try
      {
        Dog currentDog = FAKEDB.Dogs.Find(d => d.Id == id);
        if (editDog.Name != null)
        {
          currentDog.Name = editDog.Name;
        }
        if (editDog.Description != null)
        {
          currentDog.Description = editDog.Description;
        }
        return currentDog;
      }
      catch (System.Exception err)
      {
        throw new System.Exception("invalid id");
      }
    }

    [HttpDelete("{id}")]
    public ActionResult<string> Delete(string id)
    {
      try
      {
        Dog dogToRemove = FAKEDB.Dogs.Find(d => d.Id == id);
        if (FAKEDB.Dogs.Remove(dogToRemove))
        {
          return Ok("Deleted");
        }
        throw new System.Exception("invalid id");
      }
      catch (System.Exception err)
      {
        throw new System.Exception("invalid id");
      }
    }
  }
}