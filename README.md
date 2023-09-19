# Cadmus PURA Parts

Components for the [PURA project in Cadmus](https://github.com/vedph/cadmus_pura_doc).

## Setting up Graph

Preload nodes, mappings, and a selection of thesauri:

```ps1
.\cadmus-tool graph-add C:\Users\dfusi\Desktop\PresetNodes.json cadmus-pura .\plugins\Cadmus.Cli.Plugin.Pura\seed-profile.json repository-factory-provider.pura

.\cadmus-tool graph-add C:\Users\dfusi\Desktop\PresetMappings.json cadmus-pura .\plugins\Cadmus.Cli.Plugin.Pura\seed-profile.json repository-factory-provider.pura -t M

.\cadmus-tool graph-add C:\Users\dfusi\Desktop\PresetThesauri.json cadmus-pura .\plugins\Cadmus.Cli.Plugin.Pura\seed-profile.json repository-factory-provider.pura -t T -p x:categories/
```

Usually, this should be done only once.

You can find these files under `Cadmus.Pura.Parts.Test/Assets`. Note that currently the `x:` URIs are just for the sake of testing.

## History

### 6.0.0

- 2023-09-19: updated packages and migrated to PostgreSQL.

### 5.0.5

- 2023-05-19: updated packages.

### 5.0.4

- 2023-03-07: updated packages.

### 5.0.2

- 2023-02-06: migrated to new components factory. This is a breaking change for backend components, please see [this page](https://myrmex.github.io/overview/cadmus/dev/history/#2023-02-01---backend-infrastructure-upgrade). Anyway, in the end you just have to update your libraries and a single namespace reference. Benefits include:
  - more streamlined component instantiation.
  - more functionality in components factory, including DI.
  - dropped third party dependencies.
  - adopted standard MS technologies for DI.

### 4.0.1

- 2022-12-23: updated packages.

### 4.0.0

- 2022-11-10: upgraded to NET 7.

### 3.1.0

- 2022-10-11: updated packages and injection in `Startup.cs` for new `IRepositoryProvider`.

### 3.0.5

- 2022-08-14: updated packages.

### 3.0.4

- 2022-06-13: updated packages. Commented out legacy tests for graph as the graph subsystem is being refactored.

### 3.0.3

- 2022-05-23: updated packages.

### 3.0.2

- 2022-05-13: updated TGR dependencies to use correct version of Cadmus general parts.

### 3.0.1

- 2022-05-02: upgraded to NET 6.0.
- 2022-01-17: updated part and CLI libraries.
- 2021-12-20: upgraded to new shell.
- 2021-11-11: upgraded to NET 6.
- 2021-11-09: added graph resources to parts test and refactored tests to use them.
- 2021-10-24: added essential SQL seed code for graph.
- 2021-10-23: refactored word form's pins to be graph-compliant.
- 2021-10-16: updated removing dependency from Itinera (`MsSignaturesPart` is now in TGR).
