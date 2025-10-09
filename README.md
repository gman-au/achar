# achar

<p align="center">
<img style="border-radius:10px;" alt="siren" width="300" src="https://github.com/user-attachments/assets/dbc036b1-406d-4faa-a571-cdea3f2968ed" />
</p>

![NuGet Version](https://img.shields.io/nuget/v/Achar?label=Achar)

## Summary
This is essentially a library of opinionated [SpecFlow / ReqnRoll](https://docs.reqnroll.net/latest/index.html) 
testing verbiage that can be referenced in a single package and used to generate
automated API and / or UI testing.

## Installation / usage
1. Add the [Achar nuget package](https://www.nuget.org/packages/Achar) to your test project.
2. In the test project, create a `reqnroll.json` file containing the following:
```json
{
  "$schema": "https://schemas.reqnroll.net/reqnroll-config-latest.json",
  "bindingAssemblies": [
    {
      "assembly": "Achar.Infrastructure.ReqnRoll"
    }
  ]
}
```
This will ensure that the Achar infrastructure and DI will be loaded prior to running the tests.


3. Create and run your feature files accordingly and they should be included in the tests for the project.

## [Command reference](https://github.com/gman-au/achar/blob/master/REFERENCE.md)