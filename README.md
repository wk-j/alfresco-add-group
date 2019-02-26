## Add Group

[![NuGet](https://img.shields.io/nuget/v/wk.AlfrescoAddGroup.svg)](https://www.nuget.org/packages/wk.AlfrescoAddGroup)

## Installation

```bash
dotnet tool install -g wk.AlfrescoAddGroup

dotnet tool install  -g wk.AlfrescoAddGroup \
    --add-source https://dotnet.myget.org/F/system-commandline/api/v3/index.json  \
    --add-source ('pwd')/.publish
```

## Usage

```bash
wk-alfresco-add-group \
    --endpoint http://localhost:8082 \
    --user admin \
    --password admin \
    --groups G1 G2 G3
```