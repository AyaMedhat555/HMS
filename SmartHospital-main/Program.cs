
using Domain.Context;
using Domain.Models.Labs;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Repository.IRepositories;
using Repository.IRepositories.Pharmacy;
using Repository.Repositories;
using Repository.Repositories.Pharmacy;
using Repository.UnitOfWorks;
using Service.IServices;
using Service.Services;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      builder =>
                      {
                          builder.WithOrigins("http://localhost:4200")//allows angular, which uses port 4200
                          .AllowAnyMethod()
                          .AllowAnyHeader();
                      });
});

// Add services to the container.


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(options => options
.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString")));



builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped<IReceptionistRepository, ReceptionistRepository>();


builder.Services.AddScoped<IPatientReportService, PatientReportService>();
builder.Services.AddScoped<IPatientReportRepository,PatientReportRepository>();


builder.Services.AddScoped< IIndoorPatientService ,IndoorPatientService >();
builder.Services.AddScoped<IIndoorPatientRepository, IndoorPatientRepository>();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddScoped<IRoomRepository, RoomRepository>();
builder.Services.AddScoped<IAdminService, AdminService>();
builder.Services.AddScoped< IBedRepository, BedRepository>();


builder.Services.AddScoped<IVitalSignsRepository, VitalSignsRepository>();
builder.Services.AddScoped<IVitalSignesService, VitalSignsService>();

builder.Services.AddScoped<IDoctorRepository, DoctorRepository>();
builder.Services.AddScoped<IDoctorService, DoctorService>();

builder.Services.AddScoped<IPrescriptionItemRepository, PrescriptionItemRepository>();
builder.Services.AddScoped<IPrescriptionRepository, PrescriptionRepository>();

builder.Services.AddScoped<INurseRepository, NurseRepository>();
builder.Services.AddScoped<INurseService, NurseService>();

builder.Services.AddScoped<IScheduleRepository, ScheduleRepository>();
builder.Services.AddScoped<IScheduleService, ScheduleService>();

builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
builder.Services.AddScoped<IDepartmentService, DepartmentService>();

builder.Services.AddScoped<ITimeSlotsRepository, TimeSlotsRepository>();
builder.Services.AddScoped<ITimeSlotService, TimeSlotService>();

builder.Services.AddScoped<IPatientRepository, PatientRepository>();
builder.Services.AddScoped<IPatientService, PatientService>();

builder.Services.AddScoped<IAppointmentRepository, AppointmentRepository>();

builder.Services.AddScoped<IGenericRepository<Test>, GenericRepository<Test>>();
builder.Services.AddScoped<IPatientTestRepository, PatientTestRepository>();
builder.Services.AddScoped<ILabRequestRepository, LabRequestRepository>();

builder.Services.AddScoped<IGenericRepository<Scan>, GenericRepository<Scan>>();
builder.Services.AddScoped<IPatientScanRepository, PatientScanRepository>();
builder.Services.AddScoped<IScanRequestRepository, ScanRequestRepository>();

builder.Services.AddScoped<IMedicalTestService, MedicalTestService>();
builder.Services.AddScoped<IMedicalScanService, MedicalScanService>();


builder.Services.AddScoped<IMedicineRepository, MedicineRepository>();
builder.Services.AddScoped<IStockRepository, StockRepository>();
builder.Services.AddScoped<IStockMedicineRepository, StockMedicineRepository>();

builder.Services.AddScoped<IPharmacyService, PharmacyService>();

builder.Services.AddScoped<IBillRepository, BillRepository>();



builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8
                .GetBytes(builder.Configuration.GetSection("AppSettings:Token").Value)),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseCors(MyAllowSpecificOrigins);

app.UseAuthentication();

app.UseAuthorization();
//app.UseMiddleware()

app.MapControllers();

app.Run();
