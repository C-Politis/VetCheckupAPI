namespace VetCheckupAPI
{
    public static class App
    {
        public static IServiceProvider ServiceProvider { get; private set; }

        public static void SetServiceProvider(IServiceProvider serviceProvider)
        {
            // We never want to overwrite the existing ServiceProvider. If you need a new instance, create a Scope.
            if (ServiceProvider != null) { return; }

            ServiceProvider = serviceProvider;
        }

    }
}
