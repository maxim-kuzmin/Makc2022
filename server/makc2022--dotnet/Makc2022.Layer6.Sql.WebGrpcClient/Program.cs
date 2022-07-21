// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2022.Layer1.Apps.WebApp.Logging;
using Makc2022.Layer5.Sql.GrpcClient.Setting;

using var loggingSetting = new WebAppLoggingSetting();

loggingSetting.OnStart();

try
{
    var builder = WebApplication.CreateBuilder(args);

    loggingSetting.Configure(builder);

    builder.Services.AddAppServices(builder.Configuration);

    // Add services to the container.
    
    builder.Services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}
catch(Exception exception)
{
    loggingSetting.OnError(exception);

    throw;
}