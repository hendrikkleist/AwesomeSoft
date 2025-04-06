# AwesomeSoft

## Running with In Memory database
No need to do anything other than to press F5

## Running with Entity Framework
Firstly you need to run database in either Docker or Podman container.
This is tested in Podman container. The command should also apply to Docker. 
If running with Docker then replace *podman* with *docker*

```
podman run -d -e 'ACCEPT_EULA=Y' -e 'MSSQL_SA_PASSWORD=sYb3jE6Vzg@#t8MD' --name MSSQL -p 1433:1433 mcr.microsoft.com/mssql/server:2022-latest
```

Also comment out and comment in following regions in AwesomSoft.WebAPI.Program Line 19 through 22 and Line 26 through 36

```
#region In memory database
builder.Services.AddSingleton(typeof(IGenericRepository<>), typeof(IMGenericRepository<>));
builder.Services.AddSingleton<IPeopleRepository, IMPeopleRepository>();
builder.Services.AddSingleton<IMeetingRoomRepository, IMMeetingRoomRepository>();
builder.Services.AddSingleton<IUnitOfWork, IMUnitOfWork>();
#endregion
```

Comment in
```
#region Entity Framework
// Add Database
//builder.Services.AddDbContext<ApplicationContext>(options =>
//options.UseSqlServer(
//    builder.Configuration.GetConnectionString("DefaultConnection"),
//    b => b.MigrationsAssembly(typeof(ApplicationContext).Assembly.FullName)));

//builder.Services.AddTransient<IUnitOfWork, EFUnitOfWork>();

//builder.Services.AddTransient(typeof(IGenericRepository<>), typeof(EFGenericRepository<>));
//builder.Services.AddTransient<IPeopleRepository, EFPeopleRepository>();
//builder.Services.AddTransient<IMeetingRoomRepository, EFMeetingRoomRepository>();
#endregion
```