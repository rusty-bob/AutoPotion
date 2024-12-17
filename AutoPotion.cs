using System.Linq;
using ExileCore2;
using ExileCore2.PoEMemory.Components;

namespace AutoPotion;

public class AutoPotion : BaseSettingsPlugin<AutoPotionSettings>
{
    private static readonly string[] ManaBuffs =
    [
        "flask_effect_mana",
        "flask_effect_mana_not_removed_when_full",
        "flask_instant_mana_recovery_at_end_of_effect"
    ];
    
    public override void Tick()
    {
        if (GameController.Area.CurrentArea.IsTown)
        {
            return;
        }

        if (GameController.Player.TryGetComponent<Life>(out var lifeComp) && GameController.Player.TryGetComponent<Buffs>(out var buffs))
        {
            var hp = (float)lifeComp.CurHP / lifeComp.MaxHP * 100;
            var mp = (float)lifeComp.CurMana / lifeComp.MaxMana * 100;

            if (hp < Settings.HealthPotionSettings.Threshold)
            {
                if (!buffs.HasBuff("flask_effect_life"))
                {
                    Input.KeyPressRelease(Settings.HealthPotionSettings.Hotkey);
                }
            }
            
            if (mp < Settings.ManaPotionSettings.Threshold)
            {
                if (ManaBuffs.Any(buffs.HasBuff))
                {
                    Input.KeyPressRelease(Settings.ManaPotionSettings.Hotkey);
                }
            }
        }

        base.Tick();
    }
}