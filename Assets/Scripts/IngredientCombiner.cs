using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class IngredientCombiner : MonoBehaviour
{

    public GameObject ingredient1;
    public GameObject ingredient2;
    public GameObject dish;
    public AudioSource soundEffect;
    public float approxDishHeight;
    public float cookingTime;
    public Vector3 dishScale;
    private Dictionary<string, GameObject> touchingIngredients;
    private int count;

    // Start is called before the first frame update
    void Start()
    {
        touchingIngredients = new Dictionary<string, GameObject>();
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject obj = collision.gameObject;

        count++;

        if (obj.name.StartsWith(ingredient1.name))
        {
            obj.name = ingredient1.name + count;
        }
        else if (obj.name.StartsWith(ingredient2.name))
        {
            obj.name = ingredient2.name + count;
        }

        touchingIngredients[obj.name] = obj;

        GameObject firstIngredient = null;
        GameObject secondIngredient = null;

        for (int i = 1; i <= count; i++)
        {
            if (touchingIngredients.ContainsKey(ingredient1.name + i) && firstIngredient == null)
            {
                firstIngredient = touchingIngredients[ingredient1.name + i];
            }

            if (touchingIngredients.ContainsKey(ingredient2.name + i) && secondIngredient == null)
            {
                secondIngredient = touchingIngredients[ingredient2.name + i];
            }
        }

        if (firstIngredient != null && secondIngredient != null)
        {
            CombineIngredients(firstIngredient, secondIngredient);
        }

    }

    private void OnCollisionExit(Collision collision)
    {
        GameObject obj = collision.gameObject;
        string name = obj.name;

        touchingIngredients.Remove(name);

    }

    private void CombineIngredients(GameObject firstIngredient, GameObject secondIngredient)
    {
        
        StartCoroutine(Cook(firstIngredient, secondIngredient));    
        
    }

    IEnumerator Cook(GameObject firstIngredient, GameObject secondIngredient)
    {
        
        if (cookingTime > 0)
        {
            soundEffect.Play();
            yield return new WaitForSeconds(cookingTime);
            soundEffect.Stop();
        }

        touchingIngredients.Remove(firstIngredient.name);
        touchingIngredients.Remove(secondIngredient.name);
        Destroy(firstIngredient);
        Destroy(secondIngredient);
        GameObject createdDish = Instantiate(dish, transform);
        createdDish.transform.position = new Vector3(createdDish.transform.position.x, (float)(createdDish.transform.position.y + approxDishHeight), createdDish.transform.position.z);
        createdDish.AddComponent<Rigidbody>();
        createdDish.AddComponent<BoxCollider>();
        createdDish.AddComponent<XRGrabInteractable>();
        createdDish.transform.localScale = dishScale;
        createdDish.GetComponent<XRGrabInteractable>().interactionLayerMask = LayerMask.GetMask("Interactable");
        createdDish.name = dish.name;

    }
}
