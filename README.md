# Serilog Message Enrichment Library

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
    <PackageReference Include="Digipolis.Serilog.Message" Version="2.0.0" />
  </ItemGroup>
``` 

or if your project still works with project.json :

``` json 
"dependencies": {
    "Digipolis.Serilog.Message":  "2.0.0",
 }
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
