using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerChecker : MonoBehaviour {
    public static TriggerChecker instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerExit(Collider col)
	{
		if(col.gameObject.tag=="Ball")
			Invoke("FallDown",0.2f);
	}
	
	public void FallDown(){
		GetComponentInParent<Rigidbody>().useGravity=true;
        GetComponentInParent<Rigidbody>().isKinematic = false;
        Destroy(transform.parent.gameObject,2f);
		
	}
}
