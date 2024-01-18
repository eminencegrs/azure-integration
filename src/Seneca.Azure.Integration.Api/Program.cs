using Microsoft.Extensions.Azure;
using Seneca.Azure.Integration.DataLake;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<DataLakeSettings>(builder.Configuration.GetSection(DataLakeSettings.SectionName));

// TODO: register all dependencies.
builder.Services.AddScoped<DataLakeServiceV1>();

builder.Services.AddAzureClients(clientBuilder =>
{
    clientBuilder.AddDataLakeServiceClient(builder.Configuration.GetSection(DataLakeSettings.SectionName));
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
