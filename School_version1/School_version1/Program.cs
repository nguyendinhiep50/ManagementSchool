using Microsoft.EntityFrameworkCore;
using School_version1.Context;
using School_version1.Entities;
using School_version1.Interface;
using School_version1.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddControllers();
builder.Services.AddDbContext<DbContextSchool>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SchoolHiep")));
builder.Services.AddScoped<DbContextSchool>();
builder.Services.AddScoped<IStudent,StudentBLL>();
builder.Services.AddScoped<ITeacher, TeacherBLL>();
builder.Services.AddScoped<ISubject, SubjectBLL>();
builder.Services.AddScoped<ISemesters, SemesterBLL>();
builder.Services.AddScoped<IFaculty, FacultyBLL>();
builder.Services.AddScoped<IAcademicProgram, AcademicProgramBLL>();
builder.Services.AddScoped<IClassLearn, ClassLearnsBLL>();




// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader();
                      });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseCors(MyAllowSpecificOrigins);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
