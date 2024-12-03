namespace OSTasksAPI.Helper
{
    public class ConfigurationHelper
    {
        public static readonly ConfigurationHelper Instance = new();
        public static ConfigurationHelper GetInstance
        {
            get { return Instance; }
        }

        public IConfigurationRoot Configuration { get; set; }

        static ConfigurationHelper() { }

        private ConfigurationHelper()
        {
            Configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .AddUserSecrets<ConfigurationHelper>()
                .Build();
        }

        public T? GetProperty<T>(string propertyName)
        {
            return Configuration.GetValue<T>(propertyName);
        }

        public T? GetConfiguration<T>()
        {
            var configSection = Configuration.GetSection(typeof(T).Name);
            var config = configSection.Get<T>();

            return config;
        }
    }
}
