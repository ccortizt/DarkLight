using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProximityController : MonoBehaviour {

	
    private bool canHit;
	
    void OnTriggerEnter(Collider coll)
    {
        
        if (coll.gameObject.name.Contains("Player") && canHit)
        {
            canHit = false;
            transform.parent.transform.Translate(0, 2, 0);
            
            Vector3 dif = transform.parent.transform.position - coll.transform.position;

            dif.x = (dif.x > 0) ? dif.x - 0.6f : dif.x + 0.6f;
            transform.parent.transform.Translate(-dif.x, -dif.y, 0, Space.World);
            StartCoroutine(CanHitAgain());

        }
    }

    public void SetCanHit(bool can)
    {
        this.canHit = can;
    }

    IEnumerator CanHitAgain()
    {
        yield return new WaitForSeconds(2f);

        canHit = true;
    }
}
