using Domain;
using Microsoft.AspNetCore.Mvc;
using Persistence;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class HistEventsController : ControllerBase
{
    private readonly ILogger<HistEventsController> _logger;

    private readonly DataContext _context;

    public HistEventsController(ILogger<HistEventsController> logger, DataContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet(Name = "GetHistEvent")]
    public IEnumerable<HistEvent> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new HistEvent
        {
            Date = DateTime.Now.AddDays(index),
            Title = "Working on it",
            Tags = TagsGenerator.TestTags(10)
        })
        .ToArray();
        
    }

    [HttpPost]
    public ActionResult<HistEvent> Create() {
        // Post to console for easy debugging
        Console.WriteLine($"Database path: {_context.DbPath}");
        Console.WriteLine("Insert a new HistEvent");


        var History = new HistEvent()
        {
            Date = DateTime.Now,
            Title = "Oh No!",
            Tags = TagsGenerator.DONOTDISPLAY
        };

        _context.HistoryList.Add(History);
        var success = _context.SaveChanges() > 0;

        if (success)
        {
            return History;
        }

        throw new Exception("An Error occured while creating new HistEvent!");
    }
}