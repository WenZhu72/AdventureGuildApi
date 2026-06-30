namespace AdventureGuildApi.Endpoints;

public static class GuildEndpoints
{
    public static WebApplication MapGuildEndpoints(this WebApplication app)
    {
        app.MapGet("/guild", () =>
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