##Try FireSharp

## Create project

```
yo fsharp
```

## Edit fsharp-firebase.fsproj

- Include following references

```xml
<Reference Include="System.Data" />
<Reference Include="System.ServiceModel" />
<Reference Include="System.Net.Http" />
```

## Eidt App.config

- Add assembly redirect

```xml
<runtime>
  <assemblyBinding xmlns="urn:schemas-microsoft-com:asm.v1">
    <dependentAssembly>
      <assemblyIdentity name="System.Net.Http" publicKeyToken="b03f5f7f11d50a3a" culture="neutral" />
      <bindingRedirect oldVersion="0.0.0.0-1.5.0.0" newVersion="4.0.0.0" />
    </dependentAssembly>
  </assemblyBinding>
</runtime>
```

## Install FireSharp

```bash
paket add nuget FireSharp project fsharp-firebase.fsproj
```

