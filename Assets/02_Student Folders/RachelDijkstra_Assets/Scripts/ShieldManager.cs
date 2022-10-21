using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Unity.FPS.AI
{
    public class CrystalManager : MonoBehaviour
    {
        public GameObject crystal;
        public GameObject crystal1;
        public GameObject crystal2;
        public GameObject shield;

        bool CrystalGetOfCounter;
        bool Crystal1GetOfCounter;
        bool Crystal2GetOfCounter;
        bool shieldDeactivated;

        private int NumberOfCrystalsTotal;
        private int NumberOfCrystalsRemaining;

        void Start()
        {
            NumberOfCrystalsTotal = 3;
            NumberOfCrystalsRemaining = NumberOfCrystalsTotal;
            CrystalGetOfCounter = true;
            Crystal1GetOfCounter = true;
            Crystal2GetOfCounter = true;
            shieldDeactivated = false;
        }

        void Update()
        {
            if (crystal == null && CrystalGetOfCounter)
            {
                CrystalGetOfCounter = false;
                NumberOfCrystalsRemaining--;
            }
            if (crystal1 == null && Crystal1GetOfCounter)
            {
                Crystal1GetOfCounter = false;
                NumberOfCrystalsRemaining--;
            }
            if (crystal2 == null && Crystal2GetOfCounter)
            {
                Crystal2GetOfCounter = false;
                NumberOfCrystalsRemaining--;
            }

            DisableShield();
        }

        void DisableShield()
        {
            if (NumberOfCrystalsRemaining == 0 && !shieldDeactivated)
            {
                shield.SetActive(false);
                shieldDeactivated = true;
            }
        }
    }
}
