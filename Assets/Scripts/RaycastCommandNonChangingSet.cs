using UnityEngine;

namespace SampleProject.RaycastExamples
{
    public class RaycastCommandNonChangingSet : RaycastCommandExample
    {
        [SerializeField]
        private RayData _rayData;

        #region UNITY_FUNCTIONS
        protected override void Awake()
        {
            _raycastCount = _rayData.RandomRayDataCount;
            base.Awake();
            GenerateDataForRaycast();
        }

        protected override void Update()
        {
            if (_debugRays)
            {
                DebugRay();
            }

            RaycastCommandFunction();
        }
        #endregion

        #region NONUNITY_FUNCTIONS
        protected override void GenerateDataForRaycast()
        {
            for (int i = 0; i < _raycastCount; i++)
            {
                _raycastCommandArray[i] = new RaycastCommand(Vector3.zero, _rayData.rayStructs[i].Direction, distance: _rayData.rayStructs[i].Distance);
            }
        }

        private void DebugRay()
        {
            for (int i = 0; i < _raycastCount; i++)
            {
                Debug.DrawRay(Vector3.zero, _rayData.rayStructs[i].Direction * _rayData.rayStructs[i].Distance, Random.ColorHSV());
            }
        }
        #endregion
    }
}