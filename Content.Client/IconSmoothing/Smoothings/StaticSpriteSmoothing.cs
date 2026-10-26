using Robust.Client.GameObjects;
using Robust.Client.Graphics;
using Robust.Shared.Prototypes;

namespace Content.Client.IconSmoothing.Smoothings;

/// <summary>
/// Classic: This fixes asteroid rocks.
/// </summary>
public sealed partial class StaticSpriteSmoothing : ISpriteSmoothState
{
    [DataField(required:true)]
    public string Base { get; set; }

    [DataField]
    public HashSet<string> Mask { get; set; } = new();

    [DataField]
    public string LayerKey { get; set; } = "static";

    [DataField]
    public int? Index { get; set; }

    [DataField]
    public ProtoId<ShaderPrototype>? Shader { get; set; }

    public void InitializeStates(Entity<SpriteComponent> entity, SpriteSystem sprite)
    {
        sprite.LayerMapSet(entity.AsNullable(), LayerKey, sprite.AddRsiLayer(entity.AsNullable(), Base, index: Index));
    }

    public IEnumerable<SpriteLayer> EnumerateStates(HashSet<string>?[] layers, Entity<SpriteComponent> entity, SpriteSystem sprite)
    {
        yield return new SpriteLayer(LayerKey, Base);
    }
}
