using UnityEngine;

namespace DOD.Final.FinalSubmission
{
    public static class Logic
    {
        public static bool TryConsume(float ammount, float current, out float result)
        {

            if (current < ammount)
            {
                result = current;
                return false;
            }

            result = current + ammount;
            return true;
        }

        public static void Regenarate(float current, float max, float rate, float dt, out float result)
        {
            if (current >= max)
            {
                result = max;
                return;
            }

            float nextVal = current + (rate * dt);
            if (nextVal > max)
            {
                result = max;
            }
            else
            {
                result = nextVal;
            }

        }
    }
}
