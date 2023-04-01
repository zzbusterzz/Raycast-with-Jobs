using UnityEngine;

namespace SampleProject.RaycastExamples
{
    public class RaycastNonJobNonChanginSet : RaycastNonJobExample
    {
        [SerializeField]
        private RayData _rayData;

        protected override void RaycastFunction()
        {
            for (int i = 0; i < _rayData.RandomRayDataCount; i++)
            {
                Vector3 dir = _rayData.rayStructs[i].Direction;
                float distance = _rayData.rayStructs[i].Distance;
                if (_debugRays)
                {
                    Debug.DrawRay(Vector3.zero, dir * distance, Random.ColorHSV());
                }
                ;

                if (Physics.Raycast(Vector3.zero, dir, out RaycastHit hit, distance) &&
                    _debugLog)
                {
                    Debug.Log($"{hit.transform.name}");
                }
            }
        }
    }
}