namespace SWD392.OutfitBox.API.Configurations.JsonReaders
{
    public static  class JsonReader
    {
        public static void JsonReaderConfiguration(this IConfigurationBuilder  configuration)
        {
            configuration.AddJsonFile("./appsettings.Development.json").AddJsonFile("./firebase-storage-key.json").AddJsonFile("./appsettings.json", optional: false, reloadOnChange: true);
        }
    }
}
