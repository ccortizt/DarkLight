using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowShooter : MonoBehaviour {

    [SerializeField]
    GameObject arrowPrefab;

    private
    float timeInterval = 5f;
    private
    int burstCounter = 10;
    private
    float magnitude = 4f;

	void Start () {
        StartCoroutine(ShootArrows());	
	}
	
    public IEnumerator ShootArrows()
    {
        for (int i = 0; i < 100; i++)
        {

            for (int j = 0; j <= burstCounter; j++)
            {
                Shoot();
                yield return new WaitForSeconds(Random.Range(timeInterval, 5.5f));
            }

            yield return new WaitForSeconds(Random.Range(1, 4));
        }

    }
      public void Shoot(){


          Vector3 dir = transform.FindChild("SpawnPoint").right;

          int angle = -90;
          
          if (gameObject.transform.position.x < 0)
          {
              angle = 90;
          }
          
          GameObject projectile = Instantiate(arrowPrefab, transform.FindChild("SpawnPoint").position, Quaternion.Euler(0,-angle,0));
          
          projectile.GetComponent<Rigidbody>().velocity = dir * magnitude;
          Destroy(projectile, 5f);

      }


      public void SetArrowFrequency(float time)
      {
          timeInterval = time;
      }

      public void SetArrowForce(float force)
      {
          magnitude = force;
      }
}
