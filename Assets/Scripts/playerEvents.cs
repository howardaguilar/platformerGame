using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerEvents : MonoBehaviour
{
    //public Display message;
    // Start is called before the first frame update
    void Start()
    {
        //message = GameObject.Find("Display").GetComponent<Display>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnMouseDown()
    {
        /*
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;
        if (gameObject.name == "Brick(Clone)")
        {
            if (Physics.Raycast(ray, out hit, 100.0f) && hit.transform.gameObject != null)
            {
                GameObject.Destroy(hit.transform.gameObject);
                message.updatePoint();
            }
        }
        else if (gameObject.name == "QuestionBox(Clone)")
        {
            message.updateCoin();
        }
        */

        // Works but not using physics
        /*if (gameObject.name == "Brick(Clone)")
        {
            Destroy(gameObject);
        }
        if (gameObject.name == "QuestionBox(Clone)")
        {
            Debug.Log("INCREASE COINS\n");
        }*/
        
    }
    
}
