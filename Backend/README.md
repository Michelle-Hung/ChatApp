# Kinder-Backend
[![Coverage Status](https://coveralls.io/repos/github/Michelle-Hung/Kinder-Backend/badge.svg?branch=main&service=github)](https://coveralls.io/github/Michelle-Hung/Kinder-Backend?branch=main)
![Build and Test](https://github.com/Michelle-Hung/Kinder-Backend/actions/workflows/dotnet.yml/badge.svg?event=push)

[![DeepSource](https://deepsource.io/gh/Michelle-Hung/Kinder-Backend.svg/?label=active+issues&show_trend=true&token=Lm-cRM9Z78ROKEqo44eSMMsT)](https://deepsource.io/gh/Michelle-Hung/Kinder-Backend/?ref=repository-badge)
[![DeepSource](https://deepsource.io/gh/Michelle-Hung/Kinder-Backend.svg/?label=resolved+issues&show_trend=true&token=Lm-cRM9Z78ROKEqo44eSMMsT)](https://deepsource.io/gh/Michelle-Hung/Kinder-Backend/?ref=repository-badge)

[![Quality Gate Status](https://sonarcloud.io/api/project_badges/measure?project=Michelle-Hung_Kinder-Backend&metric=alert_status)](https://sonarcloud.io/summary/new_code?id=Michelle-Hung_Kinder-Backend)


### How to migrate .net5 to .net6 in the project
1. Download .net6 SDK
2. Modify `TargetFramework` from v5.x.x to v6.0.0 in .csproj file
3. Update relative Nuget package to 6.0 with command `dotnet add <package name> --version <version>`
4. Build project and run test
5. Modify docker file from v5.x.x to v6.0.0
```
remove: 
FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
add: 
FROM mcr.microsoft.com/dotnet/aspnet:6.0.0-bullseye-slim AS base
```

```
remove:
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
add:
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
```
6. Build project with `docker build` and run project with `doker run` to verify
### How to create GitHub Actions in project
1. Click Actions tab in your project
2. Choose an action that you need
3. Do some modifying(ex. project name, folder name, etc.)
4. Push
### How to implement code coverage with Coverall in your project and display in README
Reference: https://samlearnsazure.blog/2021/01/05/code-coverage-in-github-with-net-core/

More details about `GITHUB_TOKEN`: https://docs.github.com/en/actions/security-guides/automatic-token-authentication
1. Download coverlet package in your project `coverlet.msbuild` and `coverlet.collect` NuGet package
2. Register in `Coverall` with GitHub account and link your repo that you want to implement code coverage
3. Add a step for generate coverage report in yaml file
4. Push code and yaml
5. Login `Coverall` and get Badage source code for README them copy it
6. Past the code to README in your project

**_NOTE:_**  The code coverage badge will be browser cache, it won't be updated immediately.😞
