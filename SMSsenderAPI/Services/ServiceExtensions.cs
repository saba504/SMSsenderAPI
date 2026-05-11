namespace SMSsenderAPI.Services
{
    public static class ServiceExtensions
    {
        public static void AddThisLayer(this IServiceCollection services, IConfiguration configuration)
        {
            // todo: მივაქციო ყურადღება, ზოგგან მუშაობს ზოგგან არა
            services.AddHttpContextAccessor(); // IHttpContextAccessor -ის ინექციისთვის
            services.AddScoped<ITemplateService, TemplateService>();
            services.AddScoped<ISmsService, SmsService>();
            services.AddScoped<ISmsSendService, SmsSendService>();
        }
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(name: "AnyPolicy", builder => builder
                    .AllowAnyOrigin() // დაშვება ეძლევა მოთხოვნას ნებისმიერი წყაროდან
                    .AllowAnyMethod() // დაშვებას იძლევა HTTP ყველა მეთოდზე
                    .AllowAnyHeader()
                    .WithExposedHeaders("AccessToken"));
            });
        }

        public static void ConfigureXml(this IServiceCollection services)
        {
            services.AddMvc(options =>
            {
                // Add XML Content Negotiation
                //options.RespectBrowserAcceptHeader = true;
                //options.InputFormatters.Add(new XmlSerializerInputFormatter(options));
                //options.OutputFormatters.Add(new XmlSerializerOutputFormatter());
            });
        }
    }
}
