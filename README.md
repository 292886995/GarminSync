# GarminSync
GarminSync is a .NET 9 tool for synchronizing activity data between Garmin China and Garmin International accounts. It automates login, downloads, extraction, and uploads of activity files, enabling seamless cross-region data migration for Garmin users.

## Solution Structure

- **GarminConnect**: Core library for Garmin Connect API integration (authentication, data retrieval, upload, download, etc.).
- **GarminModels**: Data models for activities, workouts, user profiles, golf scorecards, and more.
- **OAuth1.0**: OAuth 1.0 protocol support library.
- **UnitTestGarminSync**: NUnit-based unit test project.

## Features

- OAuth1.0/OAuth2.0 authentication for Garmin Connect (supports garmin.com and garmin.cn)
- Retrieve user profile, activity list, activity details
- Download and upload activity files (zip/gpx/tcx/kml)
- Manage workouts: list, add, get details
- Token import/export for automation
- .NET 9 support

## Getting Started

1. **Install Dependencies**

   Requires [.NET 9 SDK](https://dotnet.microsoft.com/).

2. **Reference the Core Library**

```csharp
using GarminConnect.Garmin;
```

3. **Sample Usage**

```csharp
var credentials = new GCCredentials { Username = "your_email", Password = "your_password" };
var client = new GarminConnectClient(credentials);
await client.LoginAsync();

// Get activity list
var activities = await client.GetActivitiesAsync(0, 10);

// Download activity file
await client.DownloadOriginalActivityDataAsync(activityId, "activity.zip", "zip");
```

4. **Run Unit Tests**

```sh
dotnet test UnitTestGarminSync/UnitTestGarminSync.csproj
```

## Dependencies

- [Newtonsoft.Json](https://www.newtonsoft.com/json/)
- [HtmlAgilityPack](https://html-agility-pack.net/)
- [NUnit](https://nunit.org/)

## Contributing

Contributions are welcome! Please open issues or submit pull requests.

## License

[MIT License](LICENSE)

---

For more details, please refer to the source code and inline documentation.