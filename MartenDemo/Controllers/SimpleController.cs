using Marten;
using MartenDemo.Entities;
using Microsoft.AspNetCore.Mvc;

namespace MartenDemo.Controllers;

[ApiController]
[Route("[controller]")]
public class SimpleController : ControllerBase
{
    // Per request/Scoped instance of IDocumentSession
    private readonly IDocumentSession _documentSession;
    // Singleton instance of IDocumentStore
    private readonly IDocumentStore _documentStore;

    public SimpleController(IDocumentSession documentSession,
                            IDocumentStore documentStore)
    {
        _documentSession = documentSession;
        _documentStore = documentStore;
    }

    /// <summary>
    /// Creates a new Cat entity in the database using Marten.
    /// </summary>
    /// <param name="cat"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> CreateCatAsync([FromBody] Cat cat)
    {
        // Create cat with lightweight session.
        // using (var session = _documentStore.LightweightSession())
        // {
        //     session.Store(cat);
        //     await session.SaveChangesAsync();
        // }

        if (cat == null)
        {
            return BadRequest("Cat cannot be null");
        }
        _documentSession.Store(cat);
        await _documentSession.SaveChangesAsync();
        return Ok(cat);
    }

    /// <summary>
    /// Retrieves a Cat entity by its ID from the database using Marten.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetCatByIdAsync(Guid id)
    {
        // Get cat with query session.
        // using (var session = _documentStore.QuerySession())
        // {
        //     var cat = await session.LoadAsync<Cat>(id);
        //     if (cat == null)
        //         return NotFound();
        //     return Ok(cat);
        // }

        var cat = await _documentSession.LoadAsync<Cat>(id);
        if (cat == null)
            return NotFound();
      
        return Ok(cat);
    }
}