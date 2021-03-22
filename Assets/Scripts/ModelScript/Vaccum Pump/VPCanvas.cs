using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VPCanvas : MonoBehaviour
{
    public GameObject canvasWorld;

    private void Start()
    {
        foreach(Transform child in canvasWorld.transform)
        {
            child.gameObject.SetActive(false);
        }

    }
    /*private void Update()
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
                        OilFilter.SetActive(true);
                        OilSump.SetActive(false);
                        Housing.SetActive(false);
                        Radiator.SetActive(false);
                        Rotor.SetActive(false);
                        Vanes.SetActive(false);
                        Coupling.SetActive(false);
                        Cover.SetActive(false);
                        NRVBasePlate.SetActive(false);
                        BasePlate.SetActive(false);
                        OilLines.SetActive(false);
                        Outlet.SetActive(false);
                        break;
                    case "OilSump":
                        OilFilter.SetActive(false);
                        OilSump.SetActive(true);
                        Housing.SetActive(false);
                        Radiator.SetActive(false);
                        Rotor.SetActive(false);
                        Vanes.SetActive(false);
                        Coupling.SetActive(false);
                        Cover.SetActive(false);
                        NRVBasePlate.SetActive(false);
                        BasePlate.SetActive(false);
                        OilLines.SetActive(false);
                        Outlet.SetActive(false);

                        break;
                    case "Housing":
                        OilFilter.SetActive(false);
                        OilSump.SetActive(false);
                        Housing.SetActive(true);
                        Radiator.SetActive(false);
                        Rotor.SetActive(false);
                        Vanes.SetActive(false);
                        Coupling.SetActive(false);
                        Cover.SetActive(false);
                        NRVBasePlate.SetActive(false);
                        BasePlate.SetActive(false);
                        OilLines.SetActive(false);
                        Outlet.SetActive(false);

                        break;
                    case "Radiator":
                        OilFilter.SetActive(false);
                        OilSump.SetActive(false);
                        Housing.SetActive(false);
                        Radiator.SetActive(true);
                        Rotor.SetActive(false);
                        Vanes.SetActive(false);
                        Coupling.SetActive(false);
                        Cover.SetActive(false);
                        NRVBasePlate.SetActive(false);
                        BasePlate.SetActive(false);
                        OilLines.SetActive(false);
                        Outlet.SetActive(false);

                        break;
                    case "Rotor":
                        OilFilter.SetActive(false);
                        OilSump.SetActive(false);
                        Housing.SetActive(false);
                        Radiator.SetActive(false);
                        Rotor.SetActive(true);
                        Vanes.SetActive(false);
                        Coupling.SetActive(false);
                        Cover.SetActive(false);
                        NRVBasePlate.SetActive(false);
                        BasePlate.SetActive(false);
                        OilLines.SetActive(false);
                        Outlet.SetActive(false);

                        break;
                    case "Vanes":
                        OilFilter.SetActive(false);
                        OilSump.SetActive(false);
                        Housing.SetActive(false);
                        Radiator.SetActive(false);
                        Rotor.SetActive(false);
                        Vanes.SetActive(true);
                        Coupling.SetActive(false);
                        Cover.SetActive(false);
                        NRVBasePlate.SetActive(false);
                        BasePlate.SetActive(false);
                        OilLines.SetActive(false);
                        Outlet.SetActive(false);

                        break;
                    case "Coupling":
                        OilFilter.SetActive(false);
                        OilSump.SetActive(false);
                        Housing.SetActive(false);
                        Radiator.SetActive(false);
                        Rotor.SetActive(false);
                        Vanes.SetActive(false);
                        Coupling.SetActive(true);
                        Cover.SetActive(false);
                        NRVBasePlate.SetActive(false);
                        BasePlate.SetActive(false);
                        OilLines.SetActive(false);
                        Outlet.SetActive(false);

                        break;
                    case "Cover":
                        OilFilter.SetActive(false);
                        OilSump.SetActive(false);
                        Housing.SetActive(false);
                        Radiator.SetActive(false);
                        Rotor.SetActive(false);
                        Vanes.SetActive(false);
                        Coupling.SetActive(false);
                        Cover.SetActive(true);
                        NRVBasePlate.SetActive(false);
                        BasePlate.SetActive(false);
                        OilLines.SetActive(false);
                        Outlet.SetActive(false);

                        break;
                    case "NRVBasePlate":
                        OilFilter.SetActive(false);
                        OilSump.SetActive(false);
                        Housing.SetActive(false);
                        Radiator.SetActive(false);
                        Rotor.SetActive(false);
                        Vanes.SetActive(false);
                        Coupling.SetActive(false);
                        Cover.SetActive(false);
                        NRVBasePlate.SetActive(true);
                        BasePlate.SetActive(false);
                        OilLines.SetActive(false);
                        Outlet.SetActive(false);

                        break;
                    case "BasePlate":
                        OilFilter.SetActive(false);
                        OilSump.SetActive(false);
                        Housing.SetActive(false);
                        Radiator.SetActive(false);
                        Rotor.SetActive(false);
                        Vanes.SetActive(false);
                        Coupling.SetActive(false);
                        Cover.SetActive(false);
                        NRVBasePlate.SetActive(false);
                        BasePlate.SetActive(true);
                        OilLines.SetActive(false);
                        Outlet.SetActive(false);

                        break;
                    case "OilLines":
                        OilFilter.SetActive(false);
                        OilSump.SetActive(false);
                        Housing.SetActive(false);
                        Radiator.SetActive(false);
                        Rotor.SetActive(false);
                        Vanes.SetActive(false);
                        Coupling.SetActive(false);
                        Cover.SetActive(false);
                        NRVBasePlate.SetActive(false);
                        BasePlate.SetActive(false);
                        OilLines.SetActive(true);
                        Outlet.SetActive(false);

                        break;
                    case "Outlet":
                        OilFilter.SetActive(false);
                        OilSump.SetActive(false);
                        Housing.SetActive(false);
                        Radiator.SetActive(false);
                        Rotor.SetActive(false);
                        Vanes.SetActive(false);
                        Coupling.SetActive(false);
                        Cover.SetActive(false);
                        NRVBasePlate.SetActive(false);
                        BasePlate.SetActive(false);
                        OilLines.SetActive(false);
                        Outlet.SetActive(true);

                        break;
                    default:
                        break;
                }
            }
        }
    }*/

    public void SetDeactivate()
    {
        foreach (Transform child in canvasWorld.transform)
        {
            child.gameObject.SetActive(false);
        }
    }
    public void Activate()
    {
        /*OilFilter.SetActive(true);
        OilSump.SetActive(true);
        Housing.SetActive(true);
        Radiator.SetActive(true);
        Rotor.SetActive(true);
        Vanes.SetActive(true);
        Coupling.SetActive(true);
        Cover.SetActive(true);
        NRVBasePlate.SetActive(true);
        BasePlate.SetActive(true);
        OilLines.SetActive(true);
        Outlet.SetActive(true);*/

        StartCoroutine(ActivateImage());
    }

    IEnumerator ActivateImage()
    {
        yield return new WaitForSeconds(0.2f);
        foreach (Transform child in canvasWorld.transform)
        {
            child.gameObject.SetActive(true);
        }
    }
}
