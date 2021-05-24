using ARPG.Stats;

namespace ARPG.Stats
{
    public interface IModifierProvider
    {
        void Modify(CharacterStats characterStats);
    }
}
