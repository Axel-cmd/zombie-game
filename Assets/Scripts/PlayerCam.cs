using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    // variable pour la sensibilité
    public float sensX;
    public float sensY;
    // orientation du joueur
    public Transform orientation;

    // rotation de la caméra
    float xRotation;
    float yRotation;

    // Start is called before the first frame update
    void Start()
    {
        // faire en sorte de bloquer le curseur au centre et le rendre invisible 
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        // récupérer les inputs de souris 
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

        yRotation += mouseX;
        xRotation -= mouseY;

        // pour faire en sorte que la caméra soit bloquer sur l'axe X 
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        // tourner la caméra et orienter le joueur 
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);
    }
}
