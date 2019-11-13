# Change Log
All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](http://keepachangelog.com/).

## Unreleased

## [0.0.1] - 2019-11-13
### Added
- bitbucket.org/[clcdpc/polaris-api-csharp](https://bitbucket.org/clcdpc/polaris-api-csharp/src/master/) code
- PapiHelper to provide front-end validation and interface
- Automatic packaging to the [NuGet Gallery](https://www.nuget.org/packages/PolarisILSKit/)
- Docker build and deployment of NuGet package
- Add Travis CI configuration for automated builds

### Changed
- Update framework to [.NET Standard 2.0](https://github.com/dotnet/standard/blob/master/docs/versions/netstandard2.0.md)

### Fixed
- Modify Patron data model to allow nullable RegistrationDate and AddrCheckDate
- Typo in TxnGroupQualifer property - now matches the API

### Removed
- Package files for [CLCDPC package](https://www.nuget.org/packages/PolarisApiLibrary/) 

[0.0.1]: https://github.com/mcld/PolarisILSKit/releases/v0.0.1
