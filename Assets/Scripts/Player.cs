using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float steerSpeed = 360f;
    public GameObject bodyPrefab;
    private readonly List<GameObject> _bodyParts = new();
    private readonly List<Vector3> _positionHistory = new();
    public int gap = 10;
    public string currentWay = "W";
    
    public float delayTimer = 3f;

    private void Start()
    {
        for (int i = 0; i < 15; i++)
        {
            GrowSnake();
        }
    }

    private void Update()
    {
        delayTimer -= Time.deltaTime;
        if (delayTimer <= 0)
        {
            _positionHistory.Insert(0, transform.position);
            var index = 0;
            foreach (var body in _bodyParts)
            {
                var point = _positionHistory[Mathf.Min(index * gap, _positionHistory.Count - 1)];
                body.transform.position = point;
                index++;
            }

            moveAD();
            // moveAWDS();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            QuitGame();
        }
    }
    
    public void GrowSnake()
    {
        var body = Instantiate(bodyPrefab);
        _bodyParts.Add(body);
    }

    private static void QuitGame()
    {
        #if UNITY_EDITOR
        EditorApplication.isPlaying = false; 
        #else
        Application.Quit();
        #endif
    }

    private void moveAWDS()
    {
        if (Input.GetKey(KeyCode.W) && currentWay != "S")
        {
            currentWay = "W";
        }
        else if (Input.GetKey(KeyCode.S) && currentWay != "W")
        {
            currentWay = "S";
        }
        else if (Input.GetKey(KeyCode.A) && currentWay != "D")
        {
            currentWay = "A";
        }
        else if (Input.GetKey(KeyCode.D) && currentWay != "A")
        {
            currentWay = "D";
        }

        var moveDir = currentWay switch
        {
            "W" => Vector3.forward,
            "S" => Vector3.back,
            "A" => Vector3.left,
            "D" => Vector3.right,
            _ => Vector3.zero
        };

        transform.position += moveDir * (moveSpeed * Time.deltaTime);
    }

    private void moveAD()
    {
        transform.position += transform.forward * (moveSpeed * Time.deltaTime);
        var steerDirection = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up * (steerDirection * steerSpeed * Time.deltaTime));
    }
}