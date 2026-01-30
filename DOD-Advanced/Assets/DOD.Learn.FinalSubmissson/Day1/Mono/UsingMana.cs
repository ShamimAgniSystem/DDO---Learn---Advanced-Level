using System;
using UnityEngine;

namespace DOD.Final.FinalSubmission
{
    public class UsingMana : MonoBehaviour
    {
        public ManaData PlayerManadata;

        private void OnEnable()
        {
            PlayerManadata.CurrentValue = 100;
            PlayerManadata.MaxMana = 100;
            PlayerManadata.RegenRate = 5f;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                float amountOfUse = 10f;
                bool success = PlayerManadata.TryUseMana(amountOfUse); // Logics are described into the Logic sections 
                Debug.Log($"Player used mana  {amountOfUse} ");
            }
             PlayerManadata.TickUpdate(Time.time);
        }
    }
}