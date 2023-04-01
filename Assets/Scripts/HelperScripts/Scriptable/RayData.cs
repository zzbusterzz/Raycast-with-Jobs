using System.ComponentModel;
using UnityEngine;

namespace SampleProject.RaycastExamples
{
    [System.Serializable]
    [CreateAssetMenu(fileName = "RayData", menuName = "ScriptableObjects/RayData", order = 1)]
    public class RayData : ScriptableObject
    {
        public int RandomRayDataCount = 100;
        public RayStruct[] rayStructs;

        [ContextMenu("Regenerate Data")]
        public void GenerateRayData()
        {
            rayStructs = new RayStruct[RandomRayDataCount];
            for (int i = 0; i < RandomRayDataCount; i++)
            {
                rayStructs[i] = new RayStruct();
                rayStructs[i].Direction = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f));
                rayStructs[i].Distance = Random.Range(1f, 200f);
            }
        }
    }
}