using ToMars.Model.Parser;
using ToMars.Model.Settings;
using ToMars.Model.Models;

namespace ToMars.Model
{
    public interface IGeneralFacade
    {
        ISettings Settings { get; }
        ILogger Logger { get; }
        IParser Parser { get; }
        ITMRepositary Keeper { get; }
        IReader Reader { get; }
        IMessenger Messenger { get; }
        IConverter Converter { get; }
    }
    public class GeneralFacade : IGeneralFacade
    {
        public ISettings Settings { get; private set; }
        public ILogger Logger { get; private set; }
        public IParser Parser { get; private set; }
        public ITMRepositary Keeper { get; private set; }
        public IReader Reader { get; private set; }
        public IMessenger Messenger { get; private set; }
        public IConverter Converter { get; private set; }

        public GeneralFacade(ISettings _settings, ILogger _logger)
        {
            Settings = _settings;
            Logger = _logger;
            Keeper = new AnketaKeeper(Settings);
            Reader = new CSVReader();
            Parser = new AnketaParser(this);
            Messenger = new Messenger();
            Converter = new ToAnketa('\t');
        }

        public ISettings GetSettings()
        {
            return Settings;
        }

    }
}
