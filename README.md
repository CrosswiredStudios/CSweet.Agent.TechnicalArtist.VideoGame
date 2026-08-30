# Video Game Technical Artist

Owns import pipelines, shaders, materials, rigs, compression, engine readiness, and visual performance.

## Contract

- Package ID: `com.csweet.video-game-technical-artist`
- Version: `1.0.0`
- Provides: `video-game.technical-artist.execute.v1`
- Activation: manual
- Requested platform/provider capabilities: none
- Event subscriptions: none
- Network access: none

## Develop

```powershell
dotnet test
dotnet run --project src/CSweet.Agent.TechnicalArtist.VideoGame -- --self-test
```

The tests run entirely in memory and require no C-Sweet instance or credentials.

## Install

Keep `csweet-plugin.json` at the repository root. Import a reviewed GitHub commit in C-Sweet, or
clone this repository as an immediate child of C-Sweet's configured local agent catalog. Review
the exact manifest, grants, activation mode, and source before approving installation.

Built with `CSweet.Agent.SDK` 4.0.0.
