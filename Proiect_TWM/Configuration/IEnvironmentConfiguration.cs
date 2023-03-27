namespace Proiect_TWM.Configuration
{
    public interface IEnvironmentConfiguration
    {
        string GetKeys(string parentSection, string keySection);
    }
}