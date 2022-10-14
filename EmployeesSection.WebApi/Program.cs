using EmployeesSection.Application.Employees;
using EmployeesSection.Application.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using EmployeesSection.Domain;
using EmployeesSection.Domain.Employees;
using EmployeesSection.Domain.Infrastructure.Repositories;
using EmployeesSection.Infrastructure.EntityFrameworkCore;
using EmployeesSection.Infrastructure.EntityFrameworkCore.Repositories;

var builder = WebApplication.CreateBuilder(args);

string connection = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<EmployeesSectionContext>(options => options.UseSqlServer(connection));
builder.Services.AddTransient<IRepository<Employee, int>, EfCoreRepositoryBase<EmployeesSectionContext, Employee, int>>();
builder.Services.AddTransient<IEmployeeAppService, EmployeeAppService>();
builder.Services.AddAutoMapper(typeof(Program), typeof(IApplicationService));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();