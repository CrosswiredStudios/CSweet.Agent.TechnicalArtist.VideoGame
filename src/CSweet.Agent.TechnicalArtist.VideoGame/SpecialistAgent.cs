using CrosswiredStudios.VideoGame.AgentKit;
using CSweet.Agent.SDK;
using Microsoft.Extensions.AI;

namespace CSweet.Agent.TechnicalArtist.VideoGame;

public sealed class SpecialistAgent : VideoGameSpecialistAgentBase
{
    internal const int DefaultContextWindowTokens = 128_000;
    internal const int DefaultOutputTokens = 16_000;
    private const int MinimumOutputTokens = 1_000;
    private const int MaximumOutputTokens = 200_000;
    public override string AgentId => "com.csweet.video-game-technical-artist";
    public override string Version => "2.3.1";
    protected override AgentConfigurationBuilder Configure(AgentConfigurationBuilder builder) =>
        base.Configure(builder)
            .Number("maxContextWindowTokens", "Maximum context-window tokens", required: true,
                description: "Planning ceiling for Technical Artist model requests; set this no higher than the selected model's real context window.",
                minimum: 16_000, maximum: 2_000_000, step: 1_000,
                defaultValue: DefaultContextWindowTokens)
            .Number("maxOutputTokens", "Maximum output tokens", required: true,
                description: "Budget for each Technical Artist model response, including reasoning. The provider may impose a lower ceiling.",
                minimum: MinimumOutputTokens, maximum: MaximumOutputTokens, step: 1_000,
                defaultValue: DefaultOutputTokens,
                lessThanFieldKey: "maxContextWindowTokens");

    protected override ChatOptions? ResponseOptions() =>
        new() { MaxOutputTokens = ResolveOutputTokens(Settings) };

    internal static int ResolveOutputTokens(AgentSettings settings)
    {
        var contextWindow = Math.Max(settings.GetInt32("maxContextWindowTokens", DefaultContextWindowTokens),
            MinimumOutputTokens + 1);
        var output = Math.Clamp(settings.GetInt32("maxOutputTokens", DefaultOutputTokens),
            MinimumOutputTokens, MaximumOutputTokens);
        return Math.Min(output, contextWindow - 1);
    }
    protected override string RoleKey => "technical-artist";
    protected override string ArtifactTypeKey => "video-game.technical-art-delivery.v1";
    protected override string RolePrompt => "Own asset import pipelines, materials, shaders, rigs, compression, engine readiness, and visual performance validation. Translate visual targets into measurable runtime constraints.";
    protected override IReadOnlyList<string> RequiredSections => ["Pipeline", "Imports", "Materials and Shaders", "Rigging", "Compression", "Performance Validation", "Engine Readiness"];
}
