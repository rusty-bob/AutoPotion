using System.Windows.Forms;
using ExileCore2.Shared.Attributes;
using ExileCore2.Shared.Interfaces;
using ExileCore2.Shared.Nodes;

namespace AutoPotion;

public class AutoPotionSettings : ISettings
{
    public ToggleNode Enable { get; set; } = new(false);

    public FlaskSettings HealthPotionSettings { get; } = new(Keys.D1);
    public FlaskSettings ManaPotionSettings { get; } = new(Keys.D2);
}

[Submenu]
public class FlaskSettings(Keys hotkey)
{
    public RangeNode<int> Threshold { get; } = new (70, 1, 100);
    public HotkeyNode Hotkey  { get; } = new(hotkey);
}

