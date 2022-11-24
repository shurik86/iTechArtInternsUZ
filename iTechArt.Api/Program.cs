using iTechArt.Database.DbContexts;
using iTechArt.Domain.IExcelGenerate;
using iTechArt.Domain.ParserInterfaces;
using iTechArt.Domain.ParserInterfaces.IPoliceParsers;
using iTechArt.Domain.ParserInterfaces.IXmlGenerate;
using iTechArt.Domain.RepositoryInterfaces;
using iTechArt.Domain.ServiceInterfaces;
using iTechArt.Repository.Mappers;
using iTechArt.Repository.Repositories;
using iTechArt.Serivce.Services;
using iTechArt.Service.Graphs;
using iTechArt.Service.Helpers;
using iTechArt.Service.Parsers;
using iTechArt.Service.Services;
using ITechArt.Parsers.ExcelGenerate;
using ITechArt.Parsers.Parsers;
using ITechArt.Parsers.PoliceParsers;
using ITechArt.Parsers.XmlGenerate;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddScoped<IPupilRepository, PupilRepository>();
builder.Services.AddScoped<IAirportRepository, AirportRepository>();
builder.Services.AddScoped<IPoliceRepository, PoliceRepository>();
builder.Services.AddScoped<IMedStaffRepository, MedStaffRepository>();
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<IGroceryRepository, GroceryRepository>();
builder.Services.AddScoped<IRetirementRepository, RetirementRepository>();


builder.Services.AddScoped<ITotalStatisticsService, TotalStatisticsService>();
builder.Services.AddScoped<IAirportsService, AirportService>();
builder.Services.AddScoped<IStudentsService, StudentsService>();
builder.Services.AddScoped<IGroceryService, GroceryService>();
builder.Services.AddScoped<IMedStaffService, MedStaffService>();
builder.Services.AddScoped<IPoliceService, PoliceService>();
builder.Services.AddScoped<IPupilService, PupilService>();
builder.Services.AddScoped<IStreamToArray, StreamToArray>();
builder.Services.AddScoped<IGetRetirementInfo, GetRetirementInfoService>();

// Parser Services
builder.Services.AddScoped<IExcelParse, ParseExcel>();
builder.Services.AddScoped<IXmlParse, ParseXml>();
builder.Services.AddScoped<ICsvParse, ParseCsv>();
builder.Services.AddScoped<IMedStaffParser, MedStaffParser>();
builder.Services.AddScoped<IGroceryParser, GroceryParser>();
builder.Services.AddScoped<IAirportParsers, AirportParser>();
builder.Services.AddScoped<IParser, Parser>();

builder.Services.AddScoped<IGraphRepository, GraphRepository>();
builder.Services.AddScoped<IGenderGraphService, GenderGraphService>();


builder.Services.AddScoped<IExcelGenerator, GenerateExcelFile>();
builder.Services.AddScoped<IAirportXmlGenerate, AirportXmlGenerate>();
builder.Services.AddScoped<IAirportExcelGenerate, AirportExcelGenerate>();
builder.Services.AddScoped<IGroceryExcelGenerate, GroceryExcelGenerate>();
builder.Services.AddScoped<IMedStaffExcelGenerate, MedStaffExcelGenerate>();
builder.Services.AddScoped<IPoliceExcelGenerate, PoliceExcelGenerate>();
builder.Services.AddScoped<IPupilExcelGenerate, PupilExcelGenerate>();
builder.Services.AddScoped<IStudentExcelGenerate, StudentExcelGenerate>();
builder.Services.AddScoped<IGroceryXmlGenerate, GroceryXmlGenerate>();
builder.Services.AddScoped<IMedStaffXmlGenerate, MedStaffXmlGenerate>();
builder.Services.AddScoped<IPoliceXmlGenerate, PoliceXmlGenerate>();
builder.Services.AddScoped<IPupilXmlGenerate, PupilXmlGenerate>();
builder.Services.AddScoped<IStudentXmlGenerate, StudentXmlGenerate>();


builder.Services.AddCors(option =>
{
    option.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});

builder.Services.AddDbContext<AppDbContext>(option =>
    option.UseNpgsql(builder.Configuration.GetConnectionString("iTechArtConnection")));

builder.Services.AddAutoMapper(typeof(MappingProfile));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

EnvironmentHelper.WebRootPath = app.Services.GetService<IWebHostEnvironment>().WebRootPath;

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();
