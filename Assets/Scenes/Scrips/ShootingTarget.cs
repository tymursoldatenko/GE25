using UnityEngine;
using static UnityEngine.GraphicsBuffer;

namespace AG3107
{
    public class ShootingTarget : MonoBehaviour
    {
        [SerializeField] private Transform[] targetEndPoints;
        public float speed = 1.0f;
        private Transform target;
        private int currentEndPointIndex = 0; 

        void Start()
        {
            target = targetEndPoints[0];
        }

        // Update is called once per frame
        void Update()
        {
            var step = speed * Time.deltaTime; // calculate distance to move
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);

            // Check if the position of the cube and sphere are approximately equal.
            if (Vector3.Distance(transform.position, target.position) < 0.001f)
            {
                SwapEndPointTarget();
            }

        }

        void SwapEndPointTarget()
        {
            currentEndPointIndex++;
            currentEndPointIndex %= targetEndPoints.Length;
            target = targetEndPoints[currentEndPointIndex];
        }

        
    }

}
