﻿using Microsoft.AspNetCore.Mvc;
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

    // Get sparrowgrass records, returns list if {userName, count, last changed datetime}
    [HttpGet]
    public async Task<IActionResult> GetModel()
    {
        var records = await _dataManager.EatRecords.GetEatRecordWithUsers();

        var result = new List<RecordGetModel>(records.Count);

        foreach (var record in records)
            result.Add(ToEatRecordModel(record));

        return Ok(result);
    }

    // Post request handling, user fills form with name and email inputs
    [HttpPost]
    public async Task<IActionResult> HandleFormPost(AddFormPostModel model)
    {
        if (!ModelState.IsValid) return UnprocessableEntity(ModelState);

        var user = await _dataManager.GetOrRegisterUser(model.Email, model.Name);

        if (user is not null)
            await _dataManager.EatRecords.IncrementOrCreateEatRecord(user.Id);

        return Ok();
    }

    // Entity EatRecord to return model item
    private RecordGetModel ToEatRecordModel(EatRecord record)
    {
        return new RecordGetModel()
        {
            Name = record.User.Name,
            Count = record.Count,
            LastUpdated = record.LastUpdated
        };
    }
}