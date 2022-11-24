using Microsoft.AspNetCore.Mvc;
using SparrowgrassForum.Server.Domain.Entities;
using SparrowgrassForum.Server.Domain.Repositories;
using SparrowgrassForum.Server.Models;

namespace SparrowgrassForum.Server.Controllers;

[ApiController]
[Route("/api")]
public class MainController : ControllerBase
{
    private readonly DataManager _dataManager;

    public MainController(DataManager dataManager)
    {
        _dataManager = dataManager;
    }

    [HttpPost]
    public async Task<IActionResult> HandleFormPost(EatRecordAddModel model)
    {
        if (!ModelState.IsValid) return UnprocessableEntity(ModelState);
        
        var user = await _dataManager.GetOrRegisterUser(model.Email, model.Name);
            
        if (user is not null)
            await _dataManager.EatRecords.IncrementOrCreateEatRecord(user.Id);
            
        return Ok();
    }
}