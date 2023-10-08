using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using MyApiNetCore6.Repositories;
using School_version1.Context;
using School_version1.Entities;
using School_version1.Interface;
using School_version1.Models.DTOs;
using School_version1.Repositories;
using School_version1.Services;
using System.Reflection;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
//builder.Services.AddControllers(options =>
//{
//    options.OutputFormatters.Add(new XmlDataContractSerializerOutputFormatter());
//}).AddXmlSerializerFormatters();
//builder.Services.AddControllers();
builder.Services.AddControllers();    // Formatter Xml

builder.Services.AddDbContext<DbContextSchool>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("SchoolHiep")));

// Đăng ký các dịch vụ của Identity
builder.Services.AddIdentity<CustomIdentityUser, IdentityRole<Guid>>()
    .AddEntityFrameworkStores<DbContextSchool>()
    .AddDefaultTokenProviders();

builder.Services.Configure<EmailSettingsDto>(builder.Configuration.GetSection("EmailSettings"));

builder.Services.AddTransient<IEmailService, EmailService>();
builder.Services.AddTransient<IStudent, StudentServices>();
builder.Services.AddTransient<ITeacher, TeacherServices>();
builder.Services.AddTransient<ISubject, SubjectServices>();
builder.Services.AddTransient<ISubjectGrades, SubjectGradesServices>();
builder.Services.AddTransient<ISemesters, SemesterServices>();
builder.Services.AddTransient<IFaculty, FacultyServices>();
builder.Services.AddTransient<IAcademicProgram, AcademicProgramServices>();
builder.Services.AddTransient<IClassLearn, ClassLearnsServices>();
builder.Services.AddTransient<IListStudentClassLearn, ListStudentClassLearnsServices>();
builder.Services.AddTransient<IBaseRepositories<Management, ManagementDto, ManagementAddDto>, BaseRepositories<Management, ManagementDto, ManagementAddDto>>();
builder.Services.AddTransient<ILoginAccountRepository, LoginAccountServices>();
builder.Services.AddTransient<ISupportToken, Handle_TokenServices>();

builder.Services.AddTransient<IManagementRepositories, ManagementRepositories>();

//builder.Services.AddScoped<UserManager<CustomIdentityUser>>();

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

// Truy cập IdentityOptions
builder.Services.Configure<IdentityOptions>(options =>
{
    // Thiết lập về Password
    options.Password.RequireDigit = false; // Không bắt phải có số
    options.Password.RequireLowercase = false; // Không bắt phải có chữ thường
    options.Password.RequireNonAlphanumeric = false; // Không bắt ký tự đặc biệt
    options.Password.RequireUppercase = false; // Không bắt buộc chữ in
    options.Password.RequiredLength = 3; // Số ký tự tối thiểu của password
    options.Password.RequiredUniqueChars = 1; // Số ký tự riêng biệt 

    // Cấu hình Lockout - khóa user
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5); // Khóa 5 phút
    options.Lockout.MaxFailedAccessAttempts = 5; // Thất bại 5 lầ thì khóa
    options.Lockout.AllowedForNewUsers = true;

    // Cấu hình về User.
    options.User.AllowedUserNameCharacters = // các ký tự đặt tên user
        "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
    options.User.RequireUniqueEmail = true; // Email là duy nhất

    // Cấu hình đăng nhập.
    options.SignIn.RequireConfirmedEmail = true; // Cấu hình xác thực địa chỉ email (email phải tồn tại)
    options.SignIn.RequireConfirmedPhoneNumber = false; // Xác thực số điện thoại

});

// Cấu hình Cookie
//builder.Services.ConfigureApplicationCookie(options =>
//{
//    // options.Cookie.HttpOnly = true;  
//    options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
//    options.LoginPath = $"/login/";                                 // Url đến trang đăng nhập
//    options.LogoutPath = $"/logout/";
//    options.AccessDeniedPath = $"/Identity/Account/AccessDenied";   // Trang khi User bị cấm truy cập
//});
builder.Services.Configure<SecurityStampValidatorOptions>(options =>
{
    // Trên 5 giây truy cập lại sẽ nạp lại thông tin User (Role)
    // SecurityStamp trong bảng User đổi -> nạp lại thông tinn Security
    options.ValidationInterval = TimeSpan.FromSeconds(5);
});
var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("nguyendinhiep_key_longdaithonglong"));

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
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
        policy.RequireRole("Management");
        policy.RequireRole("Teacher");
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
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseCors(MyAllowSpecificOrigins);
app.UseMiddleware<JwtMiddleware>();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers(); // Cấu hình endpoint cho controllers
});
app.UseHttpsRedirection();

app.MapControllers();

app.Run();
