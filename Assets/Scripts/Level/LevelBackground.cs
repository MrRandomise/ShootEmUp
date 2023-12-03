using UnityEngine;

namespace ShootEmUp
{
    public sealed class LevelBackground : MonoBehaviour, IListenerFixUpdate, IListenerAwake
    {
        [SerializeField] private float startPositionY;

        [SerializeField] private float endPositionY;

        [SerializeField] private float movingSpeedY;

        private float positionX;

        private float positionZ;

        private Transform myTransform;

        public void OnAwake()
        {
            myTransform = transform;
            var position = myTransform.position;
            positionX = position.x;
            positionZ = position.z;
        }

        public void OnFixUpdate(float deltaTime)
        {
            if (myTransform.position.y <= endPositionY)
            {
                myTransform.position = new Vector3(
                    positionX,
                    startPositionY,
                    positionZ
                );
            }

            myTransform.position -= new Vector3(
                positionX,
                movingSpeedY * Time.fixedDeltaTime,
                positionZ
            );
        }
    }
}