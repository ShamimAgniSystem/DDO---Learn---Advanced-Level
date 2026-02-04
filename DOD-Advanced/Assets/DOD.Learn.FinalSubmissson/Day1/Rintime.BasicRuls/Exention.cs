using UnityEngine;
using Variable;

namespace DOD.Final.FinalSubmission
{
    
    public static class Exention
    {
        public static bool TryUseMana(ref this ManaData data, float amount)
        {
            bool success = Logic.TryConsume(data.CurrentValue, amount, out float newCurrent);
        
            if (success)
            {
                data.CurrentValue = newCurrent;
            }
        
            return success;
        }
        
        public static void TickUpdate(ref this ManaData data, float dt)
        {
            Logic.Regenarate(data.CurrentValue, data.MaxMana, data.RegenRate, dt, out float newCurrentManaData);
            data.CurrentValue = newCurrentManaData;
        }
    }
}
