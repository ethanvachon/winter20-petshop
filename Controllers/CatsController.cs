using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using petshop.db;
using petshop.Models;

namespace petshop.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class CatsController : ControllerBase
  {

    [HttpGet]
    public ActionResult<IEnumerable<Cat>> Get()
    {
      try
      {
        return Ok(FAKEDB.Cats);
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }
    }


    [HttpGet("{id}")]
    public ActionResult<Cat> GetCatById(string id)
    {
      try
      {
        Cat catToReturn = FAKEDB.Cats.Find(c => c.Id == id);
        return Ok(catToReturn);
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }
    }


    //frombody will create a new blank object with the properties set to null or their defaults
    //move data from the object sent to create your new class as long as it passes data sanitization.
    [HttpPost]
    public ActionResult<Cat> Create([FromBody] Cat newCat)
    {
      try
      {
        FAKEDB.Cats.Add(newCat);
        return Ok(newCat);

      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }
    }
    [HttpPut("{id}")]
    public ActionResult<Cat> Edit([FromBody] Cat editCat, string id)
    {
      try
      {
        Cat currentCat = FAKEDB.Cats.Find(c => c.Id == id);
        if (editCat.Name != null)
        {
          currentCat.Name = editCat.Name;
        }
        if (editCat.Description != null)
        {
          currentCat.Description = editCat.Description;
        }
        if (editCat.Lives != null)
        {
          currentCat.Lives = editCat.Lives;
        }
        return currentCat;
      }
      catch (System.Exception err)
      {
        throw new System.Exception("invalid id");
      }
    }


    [HttpDelete("{catId}")]
    public ActionResult<string> BuyCat(string catId)
    {
      try
      {
        Cat catToRemove = FAKEDB.Cats.Find(c => c.Id == catId);
        if (FAKEDB.Cats.Remove(catToRemove))
        {
          return Ok("Cat Purchased");
        };
        throw new System.Exception("Cat does not exist");
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }
    }



    //NOTE if you were needing to further specify your route, do so in the httpattribute accordingly.
    // [HttpGet("{id}/kittens")]
    // public ActionResult<IEnumerable<Cat>> GetTest()
    // {
    //   try
    //   {
    //     return Ok(FAKEDB.Cats);
    //   }
    //   catch (System.Exception err)
    //   {
    //     return BadRequest(err.Message);
    //   }
    // }
  }
}