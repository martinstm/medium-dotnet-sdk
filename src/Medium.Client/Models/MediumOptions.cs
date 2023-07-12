using Medium.Client.Exceptions;
using Microsoft.Extensions.Configuration;

namespace Medium.Client.Models
{
    public class MediumOptions
    {
        public string Apikey { get; set; }

        public MediumOptions(IConfiguration configuration)
        {
            configuration.Bind("Medium", this);

            if (string.IsNullOrEmpty(Apikey))
            {
                throw new MissingConfigurationException($"The {nameof(Apikey)} variable is not defined...");
            }

        }
    }
}
