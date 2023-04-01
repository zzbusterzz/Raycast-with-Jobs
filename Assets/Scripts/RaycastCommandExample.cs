using Unity.Collections;
using Unity.Jobs;
using UnityEngine;

namespace SampleProject.RaycastExamples
{
    public class RaycastCommandExample : MonoBehaviour
    {
        [SerializeField]
        protected bool _debugRays;

        [SerializeField]
        private bool _debugLog;

        [SerializeField]
        protected int _raycastCount = 100;

        protected NativeArray<RaycastCommand> _raycastCommandArray;

        private NativeArray<RaycastHit> _raycastHitArray;
        private RaycastHit[] _batchedHit;

        #region UNITY_FUNCTIONS
        protected virtual void Awake()
        {
            _raycastHitArray = new NativeArray<RaycastHit>(_raycastCount, Allocator.Persistent);
            _raycastCommandArray = new NativeArray<RaycastCommand>(_raycastCount, Allocator.Persistent);
            _batchedHit = new RaycastHit[_raycastCount];
        }
        
        protected virtual void Update()
        {
            GenerateDataForRaycast();
            RaycastCommandFunction();
        }

        private void OnDestroy()
        {
            _raycastHitArray.Dispose();
            _raycastCommandArray.Dispose();
        }
        #endregion

        #region NONUNITY_FUNCTIONS
        protected virtual void GenerateDataForRaycast()
        {
            for (int i = 0; i < _raycastCount; i++)
            {
                Vector3 dir = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f));
                float distance = Random.Range(1f, 200f);
                if (_debugRays)
                {
                    Debug.DrawRay(Vector3.zero, dir * distance, Random.ColorHSV());
                }
                _raycastCommandArray[i] = new RaycastCommand(Vector3.zero, dir, distance: distance);
            }
        }

        protected void RaycastCommandFunction()
        {
            JobHandle handle = RaycastCommand.ScheduleBatch(_raycastCommandArray, _raycastHitArray, 1, default(JobHandle));

            handle.Complete();

            for (int i = 0; i < _raycastCount; i++)
            {
                _batchedHit[i] = _raycastHitArray[i];

                if (_debugLog &&
                    _batchedHit[i].transform != null)
                {
                    Debug.Log($"{_batchedHit[i].transform.name}");
                }
            }
        }
        #endregion
    }
}