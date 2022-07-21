// Copyright (c) 2022 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

using Makc2022.Layer1.Apps.WebApp.Logging;
using Makc2022.Layer5.Sql.Server.Pages.DummyMain.Item;
using Makc2022.Layer5.Sql.Server.Pages.DummyMain.List;
using Makc2022.Layer5.Sql.Server.Setting;

using var loggingSetting = new WebAppLoggingSetting();

loggingSetting.OnStart();

try
{
    var builder = WebApplication.CreateBuilder(args);

    loggingSetting.Configure(builder);

    builder.Services.AddAppServices(builder.Configuration);

    builder.Services.AddGrpc();

    var app = builder.Build();

    app.Services.UseAppServices();

    if (app.Environment.IsDevelopment())
    {
        app.UseDeveloperExceptionPage();
    }

    app.UseRouting();

    app.UseEndpoints(endpoints =>
    {
        endpoints.MapGrpcService<DummyMainItemPageService>();
        endpoints.MapGrpcService<DummyMainListPageService>();

        endpoints.MapGet("/", async context =>
        {
            await context.Response.WriteAsync("Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");
        });
    });

    app.Run();
}
catch(Exception exception)
{
    loggingSetting.OnError(exception);

    throw;
}