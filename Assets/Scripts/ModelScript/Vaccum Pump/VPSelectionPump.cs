using UnityEngine;
using TMPro;

public class VPSelectionPump : MonoBehaviour
{
    public Description OilFilter;
    public Description OilSump;
    public Description Housing;
    public Description Radiator;
    public Description Rotor;
    public Description Vanes;
    public Description Coupling;
    public Description Cover;
    public Description NRVBasePlate;
    public Description BasePlate;
    public Description OilLines;
    public Description Outlet;

    public TMP_Text nameObj;
    public TMP_Text details;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                var selection = hit.transform;
                switch (selection.tag)
                {
                    case "OilFilter":
                        nameObj.text = OilFilter.nameof;
                        details.text = OilFilter.description;
                        break;
                    case "OilSump":
                        nameObj.text = OilSump.nameof;
                        details.text = OilSump.description;
                        break;
                    case "Housing":
                        nameObj.text = Housing.nameof;
                        details.text = Housing.description;
                        break;
                    case "Radiator":
                        nameObj.text = Radiator.nameof;
                        details.text = Radiator.description;
                        break;
                    case "Rotor":
                        nameObj.text = Rotor.nameof;
                        details.text = Rotor.description;
                        break;
                    case "Vanes":
                        nameObj.text = Vanes.nameof;
                        details.text = Vanes.description;
                        break;
                    case "Coupling":
                        nameObj.text = Coupling.nameof;
                        details.text = Coupling.description;
                        break;
                    case "Cover":
                        nameObj.text = Cover.nameof;
                        details.text = Cover.description;
                        break;
                    case "NRVBasePlate":
                        nameObj.text = NRVBasePlate.nameof;
                        details.text = NRVBasePlate.description;
                        break;
                    case "BasePlate":
                        nameObj.text = BasePlate.nameof;
                        details.text = BasePlate.description;
                        break;
                    case "OilLines":
                        nameObj.text = OilLines.nameof;
                        details.text = OilLines.description;
                        break;
                    case "Outlet":
                        nameObj.text = Outlet.nameof;
                        details.text = Outlet.description;
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
