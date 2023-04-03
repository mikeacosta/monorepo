using Amazon;
using Amazon.DynamoDBv2;
using Amazon.Extensions.NETCore.Setup;
using MovieRank.Libs.Repositories;
using MovieRank.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddAWSService<IAmazonDynamoDB>();
builder.Services.AddDefaultAWSOptions(new AWSOptions()
{
    Region = RegionEndpoint.GetBySystemName("us-west-2")
});

builder.Services.AddSingleton<IMovieRankService, MovieRankService>();
builder.Services.AddSingleton<IMovieRankRepository, MovieRankRepository>();

var app = builder.Build();

app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();