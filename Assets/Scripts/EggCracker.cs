using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class EggCracker : MonoBehaviour
{

    public GameObject egg;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "WholeEgg")
        {
            Destroy(collision.gameObject);
            GameObject crackedEgg = Instantiate(egg, transform);
            crackedEgg.transform.position = new Vector3(crackedEgg.transform.position.x, (float)(crackedEgg.transform.position.y + GetComponent<BoxCollider>().size.y), crackedEgg.transform.position.z);
            crackedEgg.AddComponent<Rigidbody>();
            crackedEgg.AddComponent<BoxCollider>();
            crackedEgg.AddComponent<XRGrabInteractable>();
            crackedEgg.transform.localScale = new Vector3((float)1.5, (float)1.5, (float)1.5);
            crackedEgg.GetComponent<XRGrabInteractable>().interactionLayerMask = LayerMask.GetMask("Interactable");
        }
    }
}
