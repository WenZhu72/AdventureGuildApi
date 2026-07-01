using AdventureGuildApi.Dtos;
using AdventureGuildApi.Infrastructure.Filters;
using AdventureGuildApi.Mappings;
using AdventureGuildApi.Models;
using AdventureGuildApi.Services;

namespace AdventureGuildApi.Endpoints;

public static class AdventurerEndpoints
{
    public static WebApplication MapAdventurerEndpoints(this WebApplication app)
    {
        var adventurers = app.MapGroup("/adventurers").WithTags("Adventurers");

        adventurers.MapGet("/", async (IAdventurerService adventurerService) =>
        {
            List<Adventurer> adventurers = await adventurerService.GetAllAsync();

            List<AdventurerResponseDto> adventurerResponseDtos = adventurers
                .Select(adventurer => adventurer.ToResponseDto())
                .ToList();

            return Results.Ok(adventurerResponseDtos);
        })
        .Produces<List<AdventurerResponseDto>>(StatusCodes.Status200OK)
        .WithName("GetAdventurers");

        adventurers.MapGet("/{id}", async (int id, IAdventurerService adventurerService) =>
        {
            Adventurer? foundAdventurer = await adventurerService.GetByIdAsync(id);

            if (foundAdventurer is null)
            {
                return Results.NotFound();
            }

            AdventurerResponseDto adventurerResponseDto = foundAdventurer.ToResponseDto();

            return Results.Ok(adventurerResponseDto);
        })
        .Produces<AdventurerResponseDto>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound)
        .WithName("GetAdventurerById");

        adventurers.MapPost("/", async (
            CreateAdventurerDto createAdventurerDto,
            IAdventurerService adventurerService) =>
        {
            Adventurer newAdventurer = createAdventurerDto.ToEntity();

            Adventurer createdAdventurer = await adventurerService.CreateAsync(newAdventurer);

            AdventurerResponseDto adventurerResponseDto = createdAdventurer.ToResponseDto();

            return Results.Created($"/adventurers/{adventurerResponseDto.Id}", adventurerResponseDto);
        })
        .AddEndpointFilter<ValidationFilter<CreateAdventurerDto>>()
        .Produces<AdventurerResponseDto>(StatusCodes.Status201Created)
        .Produces<ValidationErrorResponseDto>(StatusCodes.Status400BadRequest)
        .WithName("CreateAdventurer");

        adventurers.MapPut("/{id}", async (
            int id,
            UpdateAdventurerDto updateAdventurerDto,
            IAdventurerService adventurerService) =>
        {
            Adventurer updatedAdventurer = updateAdventurerDto.ToEntity();

            Adventurer? updatedAdventurerResult = await adventurerService.UpdateAsync(id, updatedAdventurer);

            if (updatedAdventurerResult is null)
            {
                return Results.NotFound();
            }

            AdventurerResponseDto adventurerResponseDto = updatedAdventurerResult.ToResponseDto();

            return Results.Ok(adventurerResponseDto);
        })
        .AddEndpointFilter<ValidationFilter<UpdateAdventurerDto>>()
        .Produces<AdventurerResponseDto>(StatusCodes.Status200OK)
        .Produces<ValidationErrorResponseDto>(StatusCodes.Status400BadRequest)
        .Produces(StatusCodes.Status404NotFound)
        .WithName("UpdateAdventurer");

        adventurers.MapDelete("/{id}", async (
            int id,
            IAdventurerService adventurerService) =>
        {
            bool wasDeleted = await adventurerService.DeleteAsync(id);

            if (!wasDeleted)
            {
                return Results.NotFound();
            }

            return Results.NoContent();
        })
        .Produces(StatusCodes.Status204NoContent)
        .Produces(StatusCodes.Status404NotFound)
        .WithName("DeleteAdventurer");

        return app;
    }
}