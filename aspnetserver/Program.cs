using aspnetserver.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("CORSPolicy",
        builder =>
        {
            builder
            .AllowAnyMethod()
            .AllowAnyHeader()
            .WithOrigins("http://localhost:3000", "https://appname.azurestaticapps.net");
        });
});

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen( swaggerGenOptions =>
{
    swaggerGenOptions.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "ASP.NET React tutorial", Version = "v1" });
}
    );

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI( swaggerUIOptions =>
{
    swaggerUIOptions.DocumentTitle = "ASP.NET React tutorial";
    swaggerUIOptions.SwaggerEndpoint("/swagger/v1/swagger.json", "Web Api");
    swaggerUIOptions.RoutePrefix = string.Empty;
}
    );

app.UseHttpsRedirection();

app.UseCors("CORSPolicy");

app.MapGet(pattern: "/get-all-posts",handler: async () => await PostsReposytory.GetPostsAsync())
    .WithTags("Posts Endpoints");
app.MapGet("/get-post-by-id/{postId}", async (int postId) =>
{
    Post postToReturm = await PostsReposytory.GetPostById(postId);
    if (postToReturm !=null)
    {
        return Results.Ok(postToReturm);
    }
    else
    {
        return Results.BadRequest();
    }
}).WithTags("Posts Endpoints");

app.MapPost("/create-post", async (Post postToCreate) =>
{
    bool createSuccessful = await PostsReposytory.CreatePostAsync(postToCreate);    
    if (createSuccessful)
    {
        return Results.Ok("Create successful");
    }
    else
    {
        return Results.BadRequest();
    }
}).WithTags("Posts Endpoints");

app.MapPut("/update-post", async (Post postToUpdate) =>
{
    bool updateSuccessful = await PostsReposytory.updatePostAsync(postToUpdate);
    if (updateSuccessful)
    {
        return Results.Ok("Update successful");
    }
    else
    {
        return Results.BadRequest();
    }
}).WithTags("Posts Endpoints");

app.MapDelete("/delete-post-by-id/{postId}", async (int postId) =>
{
    bool deleteSuccessful = await PostsReposytory.deletePostAsync(postId);
    if (deleteSuccessful)
    {
        return Results.Ok("delete successful");
    }
    else
    {
        return Results.BadRequest();
    }
}).WithTags("Posts Endpoints");

app.Run();