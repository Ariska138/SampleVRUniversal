using UnityEngine;

public class TeleportUniversal : MonoBehaviour
{

    void Update()
    {
        RaycastHit hit;
        Vector3 posMainCam = Camera.main.transform.position;
        Vector3 direction = Camera.main.transform.TransformDirection(Vector3.forward);
        if (Physics.Raycast(posMainCam, direction, out hit))
        {
            if (hit.transform.name.Equals("Cube"))
            {
                // ketika pointer diatas object yang bermana Cube
                IsSelected(true);

                if (Input.GetMouseButtonDown(0))
                {
                    // ketika klik Object yang bernama Cube
                    Teleport();
                }
            }
        }
        else
        {
            // Ketika pointer diluar object
            IsSelected(false);
        }

        if (Input.GetKeyUp(KeyCode.Escape))
        {
            Application.Quit();
        }
    }


    public void Teleport()
    {
        Vector3 direction = Random.onUnitSphere;
        float distance = 5 * Random.value + 1.5f;
        transform.localPosition = Camera.main.transform.localPosition + direction * distance;
    }


    public void IsSelected(bool selected)
    {
        GetComponent<Renderer>().material.color = selected ? Color.green : Color.red;
    }
}