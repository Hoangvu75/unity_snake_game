using UnityEngine;
using UnityEngine.UI;

public class PointText : MonoBehaviour
{
    public Text textComponent;
    public int currentPoint = 0;
    void Start()
    {
        textComponent = GetComponent<Text>();
        textComponent.text = "Point: " + currentPoint;
    }

    private void Update()
    {
        textComponent.text = "Point: " + currentPoint;
    }

    public void OnPointIncrease()
    {
        currentPoint += 1;
    }
}