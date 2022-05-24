using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Behaviors
{
    public class Shoot : ABehavior
    {
        public GameObject target;
        public GameObject projectile;
        public float shootInterval = 1f;
        public float projectileSpeed = 10f;
        public float projectileExistTime = 5f;
        private float previousShootTime = -100f;
        public float scale = 5f;
        private Dictionary <GameObject,float> projectileSpawnTime;

        void Awake()
        {
            target = GameObject.Find("MainCharacter");
            projectileSpawnTime = new Dictionary<GameObject, float>();
            projectile.SetActive(false);
        }
        void Update()
        {
            List<GameObject> expired = new List<GameObject>();
            foreach(var projectile in projectileSpawnTime)
            {
                if(Time.time - projectile.Value > projectileExistTime)
                {
                    expired.Add(projectile.Key);
                }
            }
            foreach (GameObject projectile in expired)
            {
                projectileSpawnTime.Remove(projectile);
                Destroy(projectile);
            }
        }
        override public void go()
        {
            if(Time.time - previousShootTime > shootInterval)
            {
                ShootOne();
                previousShootTime = Time.time;
            }
        }
        private void ShootOne()
        {
            GameObject newObject = Instantiate(projectile, transform.position, Quaternion.identity) as GameObject;
            newObject.transform.name = newObject.transform.name.Replace("(Clone)", "").Trim();
            newObject.tag = "EnemyFire";
            Vector2 direction = target.transform.position - transform.position;
            direction /= direction.magnitude;
            newObject.transform.SetParent(gameObject.transform);
            newObject.transform.localScale = new Vector3(scale,scale,scale);
            newObject.SetActive(true);
            newObject.GetComponent<Rigidbody2D>().velocity = direction * projectileSpeed;


            projectileSpawnTime.Add(newObject,Time.time);
        }
    }
}
