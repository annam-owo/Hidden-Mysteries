using UnityEngine;

public class PlayerClick : MonoBehaviour
{
    Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main; 
    }

    void Update()
{
    if (Input.GetMouseButtonDown(0)) 
    {
        GameManager.Instance.RegisterClick(); // ← Add this line

        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition); 
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            ClickableObject clickable = hit.transform.GetComponent<ClickableObject>(); 
            if (clickable != null) 
            {
                clickable.OnClick(); 
            }
        }
    }
}

}

