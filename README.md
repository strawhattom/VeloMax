# VeloMax

BDD et interopérabilité Avril 2022 – A3

## Clone repository

```bash
git clone https://github.com/nami10/VeloMax && cd ./VeloMax/VeloMax
```

## Set the correct connection string
```cs
/* in ./Services/Config.cs */
namespace VeloMax.Services
{
    public static class Config
    {
        // to change
        public static string Connection => "database=dbname;server=host;uid=userid;pwd=password";
    }
}
```


## Run the project

```bash
# in VeloMax folder
dotnet run
```

