using UnityEngine;

namespace ShootEmUp
{
    public sealed class LevelBackground : IListenerFixUpdate, IListenerAwake
    {
        private float startPositionY;

        private float endPositionY;

        private float movingSpeedY;

        private float positionX;

        private float positionZ;

        private Transform myTransform;

        public LevelBackground(ServiceBackGround serviceBackGround)
        {
            startPositionY = serviceBackGround.StartPositionY;
            endPositionY = serviceBackGround.EndPositionY;
            movingSpeedY = serviceBackGround.MovingSpeedY;
            myTransform = serviceBackGround.BackGround;
            ListenerManager.Listeners.Add(this);
        }

        public void OnAwake()
        {
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