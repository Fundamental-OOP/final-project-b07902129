using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Behaviors
{
    public class Patrol : ABehavior
    {
        public float speed = 2f;
        private List<Vector2> points;
        private int index;
        private Vector2 target;
        private LifeformMovement movement;
        void Awake()
        {

            points = new List<Vector2>();
            Transform[] pointsTransform = GetComponentsInChildren<Transform>();
            foreach (Transform t in pointsTransform)
            {
                points.Add(new Vector2(t.position.x, t.position.y));
            }

            movement = GetComponent<LifeformMovement>();
            index = 0;
            target = points[0];
        }
        override public void go()
        {
            Debug.Log(target.x);
            if(Vector2.Distance(gameObject.transform.position,target) < 1f)
            {
                NextPoint();
            }
            if (target.x - gameObject.transform.position.x > 0)
            {
                Debug.Log(movement);
                movement.setLifeformDirection(LifeformMovement.LIFEFORM_FACING.LIFEFORM_FACING_RIGHT);
                movement.setWalking(true);
                movement.SetSpeed(speed);
            }
            else
            {
                movement.setLifeformDirection(LifeformMovement.LIFEFORM_FACING.LIFEFORM_FACING_LEFT);
                movement.setWalking(true);
                movement.SetSpeed(speed);
            }
        }

        private void NextPoint()
        {
            index = (index+1)%points.Count;
            target = points[index];
        }
    }
}
