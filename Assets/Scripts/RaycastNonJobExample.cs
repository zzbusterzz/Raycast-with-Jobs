using UnityEngine;

namespace SampleProject.RaycastExamples
{
    public class RaycastNonJobExample : MonoBehaviour
    {
        [SerializeField]
        protected bool _debugRays;

        [SerializeField]
        protected bool _debugLog;

        [SerializeField]
        private int _raycastCount = 100;

        #region UNITY_FUNCTIONS
        private void Update()
        {
            RaycastFunction();
        }
        #endregion

        #region NONUNITY_FUNCTIONS
        protected virtual void RaycastFunction()
        {
            for (int i = 0; i < _raycastCount; i++)
            {
                Vector3 dir = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f));
                float distance = Random.Range(1f, 200f);
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
        #endregion
    }
}