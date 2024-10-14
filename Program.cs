var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(x => x.AddPolicy("x",
    y => y.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader())
);

var app = builder.Build();

// Configure the HTTP request pipeline.


app.UseHttpsRedirection();
app.UseRouting();
app.MapControllers();

app.UseSwagger();
app.UseSwaggerUI();

app.Run();