using ExtendedXmlSerialization; // More briefly and can serialize interfaces

namespace ToMars.Model.Settings
{
    // We can use Json instead of xml
    public interface ISettingsSerializer
    {
        string Serialize(BaseSettings _settings);
        BaseSettings Deserialize(string data);
    }
    public class MarsXmlSerializer : ISettingsSerializer
    {
        public string Serialize(BaseSettings _settings)
        {
            var x = new ExtendedXmlSerializer();
            return x.Serialize(_settings);
        }

        public BaseSettings Deserialize(string data)
        {
            ExtendedXmlSerializer serializer = new ExtendedXmlSerializer();
            return serializer.Deserialize<BaseSettings>(data);
        }
    }
}
