using System;
using UnityEngine;
using System.Collections;
using Unity.Collections;
using Unity.Mathematics;
using Random = UnityEngine.Random;

namespace DOD.Learn.FinalSubmissson
{
    /// <summary>
    /// Testing native array for Memory allocation
    /// Here I am testing NativeArray[] as soldier
    /// </summary>
    public class NativeArrayTesting : MonoBehaviour
    {
        [Header("Settings")] 
        public int SoldierCount;
        public float SoldierSpwanRadius;

        public NativeArray<float3> SoldierStorePositions = new NativeArray<float3>();

        private void Start()
        {
            throw new NotImplementedException();
        }
        
        /// <summary>
        /// there are 3 types of allocation memory
        /// 1. For 1 frame
        /// 2. TempAlloc - For 4 frame
        /// 3. Alloc.Persistent - As Long As you Want
        /// </summary>
        public void Allocation()
        {
            SoldierStorePositions = new NativeArray<float3>(SoldierCount, Allocator.Persistent);
        }
        /// <summary>
        /// we already created memory allocations
        /// here we will assign value
        /// </summary>
        public void InitPositions()
        {
            for (int i = 0; i < SoldierStorePositions.Length; i++)
            {
                float3 soldierPos = Random.insideUnitSphere * SoldierSpwanRadius;
                SoldierStorePositions[i] = new float3(soldierPos.x,soldierPos.y,soldierPos.z);
            }
        }

        /// <summary>
        /// Now we have to destroy memory alloc data
        /// </summary>
        public void Dispose()
        {
            if (SoldierStorePositions.IsCreated)
            {
                SoldierStorePositions.Dispose();
                Debug.Log("Memory Cleaned Up (Disposed).");
            }
        }
        void OnDrawGizmos()
        {
            if (!SoldierStorePositions.IsCreated) return;

            Gizmos.color = Color.cyan;

            for (int i = 0; i < SoldierStorePositions.Length; i++)
            {
                Gizmos.DrawCube((Vector3)SoldierStorePositions[i], Vector3.one * 0.5f);
            }
        }

    }
}