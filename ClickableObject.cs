using UnityEngine;

public class ClickableObject : MonoBehaviour
{
    public bool hasHiddenItem = false;

    void Start()
    {
        if (hasHiddenItem)
        {
            GameManager.Instance.RegisterHiddenItem(gameObject.name);
            GameManager.Instance.totalItemsInLevel++;
        }
    }

    public void OnClick()
    {
        if (hasHiddenItem)
        {
            Debug.Log($"{gameObject.name} contains the item!");
            GameManager.Instance.AddScore(10);
            GameManager.Instance.FoundItem(gameObject.name);
            gameObject.SetActive(false);
        }
        else
        {
            Debug.Log($"{gameObject.name} has nothing.");
        }
    }

    public void OnMouseOver()
    {
        GetComponent<Renderer>().material.color = Color.green;
    }

    public void OnMouseExit()
    {
        GetComponent<Renderer>().material.color = Color.white;
    }
}
