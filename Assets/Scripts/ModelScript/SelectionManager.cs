using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SelectionManager : MonoBehaviour
{
    public Description arms;
    public Description sArms;
    public Description rails;
    public Description Engine;
    public Description cabin;
    public Description cockpit;
    public Description bucket;

    public TMP_Text nameObj;
    public TMP_Text details;

    private void Start()
    {
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        { 
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray,out hit))
            {
                var selection = hit.transform;
                switch (selection.tag)
                {
                    case "Arms":
                        print("Arms");
                        nameObj.text = arms.nameof;
                        details.text = arms.description;
                        break;
                    case "SmallArm":
                        print("Arms");
                        nameObj.text = sArms.nameof;
                        details.text = sArms.description;
                        break;
                    case "Bucket":
                        print("Bucket");
                        nameObj.text = bucket.nameof;
                        details.text = bucket.description;
                        break;
                    case "Engine":
                        print("Engine");
                        nameObj.text = Engine.nameof;
                        details.text = Engine.description;
                        break;
                    case "Rails":
                        print("Rails");
                        nameObj.text = rails.nameof;
                        details.text = rails.description;
                        break;
                    case "Cabin":
                        print("Cabin");
                        nameObj.text = cabin.nameof;
                        details.text = cabin.description;
                        break;
                    case "Cockpit":
                        print("Cockpit");
                        nameObj.text = cockpit.nameof;
                        details.text = cockpit.description;
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
