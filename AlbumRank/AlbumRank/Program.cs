using AlbumRank.Services;
using Amazon;
using Amazon.DynamoDBv2;
using Amazon.Extensions.NETCore.Setup;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddAWSService<IAmazonDynamoDB>();
builder.Services.AddDefaultAWSOptions(new AWSOptions()
{
    Region = RegionEndpoint.GetBySystemName("us-west-2")
});

builder.Services.AddSingleton<IAlbumRankService, AlbumRankService>();
// builder.Services.AddSingleton<IMovieRankRepository, MovieRankRepository>();
// builder.Services.AddSingleton<IMapper, Mapper>();

var app = builder.Build();

app.MapControllers();

app.Run();