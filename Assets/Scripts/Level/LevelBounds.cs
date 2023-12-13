using UnityEngine;

namespace ShootEmUp
{
    public sealed class LevelBounds
    {
        private Transform leftBorder;

        private Transform rightBorder;

        private Transform downBorder;

        private Transform topBorder;


        public LevelBounds(ServiceLevelBounds border)
        {
            leftBorder = border.LeftBorder;
            rightBorder = border.RightBorder;
            downBorder = border.DownBorder;
            topBorder = border.TopBorder;
        }

        public bool InBounds(Vector3 position)
        {
            var positionX = position.x;
            var positionY = position.y;
            return positionX > leftBorder.position.x
                   && positionX < rightBorder.position.x
                   && positionY > downBorder.position.y
                   && positionY < topBorder.position.y;
        } 
    }
}