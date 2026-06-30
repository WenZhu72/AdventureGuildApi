using AdventureGuildApi.Dtos;

namespace AdventureGuildApi.Validators
{
    public class CreateAdventurerDtoValidator : IValidator<CreateAdventurerDto>
    {
        public List<string> Validate(CreateAdventurerDto createAdventurerDto)
        {
            List<string> errors = new List<string>();

            if (string.IsNullOrWhiteSpace(createAdventurerDto.Name))
            {
                errors.Add("Name is required.");
            }

            if (createAdventurerDto.Level < 1)
            {
                errors.Add("Levels must be atleast 1.");
            }

            if (string.IsNullOrWhiteSpace(createAdventurerDto.GuildRank))
            {
                errors.Add("Guild Rank is required.");
            }

            if (createAdventurerDto.Gold < 0)
            {
                errors.Add("Gold can not be negative.");
            }
                
            if (createAdventurerDto.Experience < 0)
            {
                errors.Add("Experience can not be negative.");
            }

            return errors;
        }
    }
}
