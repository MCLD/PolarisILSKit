# PolarisILSKit

PolarisILSKit was a [.NET Standard 2.0](https://github.com/dotnet/standard/blob/master/docs/versions/netstandard2.0.md) library for communicating with the Polaris ILS, which was available as a package from the NuGet Gallery.

**This project was archived in March of 2026.** If you wish to integrate with the [Polaris ILS](https://iii.com/products/polaris-ils/) using the [Polaris API](https://documentation.iii.com/product-documentation/polaris.php) using C#, investigate the [Clc.Polaris.Api](https://www.nuget.org/packages/Clc.Polaris.Api) NuGet package which utilizes the [CLC Polaris API Helper Library](https://bitbucket.org/clcdpc/polaris-api-csharp/src/master/) upon which this package was based.

## Using the Polaris API Helper Library

**Staff account credentials are only required for protected methods and overriding public methods**

### Installation

```c#
Install-Package PolarisILSKit -Pre
```


### Usage

#### Public Method

```c#
var papi = new PapiClient
            {
                AccessID = "your-access-id",
                AccessKey = "your-access-secret",
                BaseUrl = "https://papi.yoursite.org"
            };

            var patron = papi.PatronCirculateBlocksGet("123000000456", "0000");
            Console.WriteLine($"Hello {patron.Data.NameFirst}");
```

#### Protected Method 

```c#
var papi = new PapiClient
            {
                AccessID = "your-access-id",
                AccessKey = "your-access-secret",
                BaseUrl = "https://papi.yoursite.org",
                StaffOverrideAccount = new PolarisUser
                {
                    Domain = "domain",
                    Username = "staff",
                    Password = "password"
                }
            };

            var value = papi.SA_GetValueByOrg(1, "orgphone1");
            Console.WriteLine(value);
```

#### Public Method Override

```c#
var papi = new PapiClient
            {
                AccessID = "your-access-id",
                AccessKey = "your-access-secret",
                BaseUrl = "https://papi.yoursite.org",
                StaffOverrideAccount = new PolarisUser
                {
                    Domain = "domain",
                    Username = "staff",
                    Password = "password"
                }
            };

            var patron = papi.PatronBasicDataGetOverride("123000000456");
            Console.WriteLine($"Hello {patron.Data.PatronBasicData.NameFirst}");
```

## License

The basis of this project ([CLC Polaris API Helper Library](https://bitbucket.org/clcdpc/polaris-api-csharp/src/master/)) was released under the [GPL v3.0](https://bitbucket.org/clcdpc/polaris-api-csharp/src/master/LICENSE.txt) license requiring all changes to be released under the same license.
