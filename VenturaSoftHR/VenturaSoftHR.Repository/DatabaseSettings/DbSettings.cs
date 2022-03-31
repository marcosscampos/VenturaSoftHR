using VenturaSoftHR.Domain.Abstractions.Settings;

namespace VenturaSoftHR.Repository.DatabaseSettings;

public class DbSettings : IDbSettings
{
    public string ConnectionStringSQLite { get; set; }
}
