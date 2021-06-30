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
            foreach (Transform t in transform) //get children transform
            {
                points.Add(new Vector2(t.position.x, t.position.y));
            }
            movement = host.GetComponent<LifeformMovement>();
            index = 0;
            target = points[0];
        }
        override public void go()
        {
            if(Vector2.Distance(host.transform.position,target) < 1f) //close enough
            {
                NextPoint();
            }
            
            movement.SetSpeed(speed);
            movement.RelativeMovement(target, true);
        }

        private void NextPoint()
        {
            index = (index+1)%points.Count;
            target = points[index];
        }
    }
}
