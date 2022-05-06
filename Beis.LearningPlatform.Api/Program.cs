using Beis.LearningPlatform.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
var connectionString = builder.Configuration.GetConnectionString("AppConfig");
if (connectionString != null)
{
    builder.Configuration.AddAzureAppConfiguration(connectionString);
}

builder.Services.RegisterAppServices(builder.Configuration);
builder.Services.AddControllers(
		config => config.ReturnHttpNotAcceptable = true
	)
	.AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore)
	.AddXmlDataContractSerializerFormatters();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseDeveloperExceptionPage();
	app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
	app.UseExceptionHandler(b =>
	{
		b.Run(async context =>
		{
			context.Response.StatusCode = 500;
			await context.Response.WriteAsync("Unexpected error");
		});
	});
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
	app.UseHttpsRedirection();
}

app.UseRouting();

// TP-TODO: What do we need here?
app.UseAuthorization();

app.UseEndpoints(endpoints => endpoints.MapControllers());

app.Run();