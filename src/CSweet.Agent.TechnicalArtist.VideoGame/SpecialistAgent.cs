using CrosswiredStudios.VideoGame.AgentKit;

namespace CSweet.Agent.TechnicalArtist.VideoGame;

public sealed class SpecialistAgent : VideoGameSpecialistAgentBase
{
    public override string AgentId => "com.csweet.video-game-technical-artist";
    public override string Version => "2.2.0";
    protected override string RoleKey => "technical-artist";
    protected override string ArtifactTypeKey => "video-game.technical-art-delivery.v1";
    protected override string RolePrompt => "Own asset import pipelines, materials, shaders, rigs, compression, engine readiness, and visual performance validation. Translate visual targets into measurable runtime constraints.";
    protected override IReadOnlyList<string> RequiredSections => ["Pipeline", "Imports", "Materials and Shaders", "Rigging", "Compression", "Performance Validation", "Engine Readiness"];
}
