using AdventureGuildApi.Dtos;

namespace AdventureGuildApi.Validators
{
    public class UpdateAdventurerDtoValidator: IValidator<UpdateAdventurerDto>
    {
        public List<string> Validate(UpdateAdventurerDto updateAdventurerDto)
        {
            List<string> errors = new List<string>();

            if (string.IsNullOrWhiteSpace(updateAdventurerDto.Name))
            {
                errors.Add("Name is required.");
            }

            if (updateAdventurerDto.Level < 1)
            {
                errors.Add("Level must be at least 1.");
            }

            if (string.IsNullOrWhiteSpace(updateAdventurerDto.GuildRank))
            {
                errors.Add("Guild rank is required.");
            }

            if (updateAdventurerDto.Gold < 0)
            {
                errors.Add("Gold cannot be negative.");
            }

            if (updateAdventurerDto.Experience < 0)
            {
                errors.Add("Experience cannot be negative.");
            }

            return errors;
        }
    }
}