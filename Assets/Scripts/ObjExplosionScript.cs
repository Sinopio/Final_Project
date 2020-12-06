using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjExplosionScript : MonoBehaviour
{
    [SerializeField]
    private GameObject fragment;
    [SerializeField]
    private GameObject effect;
    [SerializeField]
    private float power;

    private void Update()
    {
        explosion();
    }

    void explosion()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(effect, transform.position, Quaternion.identity);
            GameObject createFragmentObj = Instantiate(fragment, gameObject.transform.position, Quaternion.identity) as GameObject;
            Rigidbody[] allRig = createFragmentObj.GetComponentsInChildren<Rigidbody>();
            if(allRig.Length > 0)
            {
                foreach(var body in allRig)
                {
                    body.AddExplosionForce(power, transform.position, 1);
                }
            }
            Destroy(gameObject);
        }
    }
}
