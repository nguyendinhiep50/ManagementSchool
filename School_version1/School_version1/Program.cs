using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using School_version1.Context;
using School_version1.Entities;
using School_version1.Interface;
using School_version1.Models.DTOs;
using School_version1.Repositories;
using School_version1.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection;
using System.Security.Claims;
using System.Text; 

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
builder.Services.AddScoped<IListStudentClassLearn, ListStudentClassLearnsBLL>();
builder.Services.AddScoped<IBaseRepositories<Management, ManagementDto,ManagementAddDto>, BaseRepositories<Management, ManagementDto,ManagementAddDto>>();
builder.Services.AddScoped<IJwtUtils, JwtUtils>();
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Your API", Version = "v1" });

    // Đây là cấu hình để Swagger không yêu cầu xác thực
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme.",
        Type = SecuritySchemeType.Http,
        Scheme = "bearer"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                },
                Array.Empty<string>()
            }
        });
});
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
var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("nguyendinhiep_key_longdaithonglong"));

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = "your-issuer",
            ValidAudience = "your-audience",
            IssuerSigningKey = key
        };
    });
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminPolicy", policy =>
    {
        policy.RequireRole("Admin");
        policy.RequireRole("Teacher");
        policy.RequireRole("Student");

    });

    options.AddPolicy("TeacherPolicy", policy =>
    {
        policy.RequireRole("Teacher");
        policy.RequireRole("Student");
    });
    options.AddPolicy("StudentPolicy", policy =>
    { 
        policy.RequireRole("Student");
    });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

}
app.UseAuthentication();
app.UseAuthorization();
app.UseCors(MyAllowSpecificOrigins);

app.UseHttpsRedirection();
  
app.MapControllers();

app.Run();
