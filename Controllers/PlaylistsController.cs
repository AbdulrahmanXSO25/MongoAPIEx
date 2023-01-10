using System;
using Microsoft.AspNetCore.Mvc;
using MongoAPIEx.DTOs;
using MongoAPIEx.Models;
using MongoAPIEx.Services;

namespace MongoAPIEx.Controllers;

[ApiController]
[Route("api/[controller]")]

public class PlaylistsController : Controller
{
    private readonly MongDbService _mongodbService;

    public PlaylistsController(MongDbService mongDbService)
    {
        _mongodbService = mongDbService;
    }

    [HttpGet]
    public async Task<List<Playlist>> Get()
    {
        return await _mongodbService.GetAsync();
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] PlaylistDTO playlist)
    {
        await _mongodbService.CreateAsync(playlist);

        return CreatedAtAction(nameof(Get), playlist);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Edit(string id ,[FromBody] string movieId)
    {
        await _mongodbService.UpdateAsync(id,movieId);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        await _mongodbService.DeleteAsync(id);

        return NoContent();
    }

}