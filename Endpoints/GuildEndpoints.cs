namespace AdventureGuildApi.Endpoints;

public static class GuildEndpoints
{
    public static WebApplication MapGuildEndpoints(this WebApplication app)
    {
        var guild = app.MapGroup("/guild").WithTags("Guild");

        guild.MapGet("/", () =>
        {
            var guildInfo = new
            {
                Name = "Adventure Guild",
                Location = "Ironhaven",
                RankSystem = "Bronze to Mythril"
            };

            return Results.Ok(guildInfo);
        })
        .WithName("GetGuildInfo");

        return app;
    }
}