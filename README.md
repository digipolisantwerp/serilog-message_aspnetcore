# Serilog Message Enrichment Library

# -----------Deprecated-----------

Serilog enricher for logging messages.

## Table of Contents

<!-- START doctoc generated TOC please keep comment here to allow auto update -->
<!-- DON'T EDIT THIS SECTION, INSTEAD RE-RUN doctoc TO UPDATE -->


- [MessageEnricher](#messageenricher)
- [Installation](#installation)
- [Usage](#usage)
- [Enricher](#enricher)

<!-- END doctoc generated TOC please keep comment here to allow auto update -->

## MessageEnricher

This library contains an enricher for Serilog that adds properties to the LogEvent.

## Installation

This package is hosted on Myget on the following feed : https://www.myget.org/F/digipolisantwerp/api/v3/index.json.  
To add it to a project, you add the package to the csproj project file:

```xml
  <ItemGroup>
    <PackageReference Include="Digipolis.Serilog.Message" Version="3.0.0" />
  </ItemGroup>
``` 

In Visual Studio you can also use the NuGet Package Manager to do this.

## Usage

Register the MessageEnricher with the Serilog pipeline by calling the AddMessageEnricher method. This is done in combination with the Serilog Extensions library 
found here : [https://github.com/digipolisantwerp/serilog_aspnetcore](https://github.com/digipolisantwerp/serilog_aspnetcore) by calling the **AddMessageEnricher()** option 
when adding the Serilog extensions in the Configure method of the Startup class :

```csharp
services.AddSerilogExtensions(options => {
    options.AddMessageEnricher(x => x.MessageVersion = "1");
});
```  

## Enricher

The enricher adds the following field to the Serilog LogEvent :

- MessageVersion : the message's version. This can be used to reflect changes in the structure of the logged message during the lifetime of an application.

## Contributing

Pull requests are always welcome, however keep the following things in mind:

- New features (both breaking and non-breaking) should always be discussed with the [repo's owner](#support). If possible, please open an issue first to discuss what you would like to change.
- Fork this repo and issue your fix or new feature via a pull request.
- Please make sure to update tests as appropriate. Also check possible linting errors and update the CHANGELOG if applicable.

## Support

Peter Brion (<peter.brion@digipolis.be>)
