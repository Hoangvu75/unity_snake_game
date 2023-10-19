using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Food : MonoBehaviour
{
    private Player _playerScript;
    private PointText _pointTextScript;

    private void Start()
    {
        SetupPlayerObject();
        SetupPointTextObject();
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        var foodPosition = transform.position;
        if (collision.gameObject.CompareTag("Player"))
        {
            const float minX = -45;
            const float maxX = 45;
            const float minZ = -20;
            const float maxZ = 20;
        
            var newX = Random.Range(minX, maxX);
            var newZ = Random.Range(minZ, maxZ);
        
            var newY = foodPosition.y;
        
            var newPosition = new Vector3(newX, newY, newZ);
            transform.position = newPosition;

            _playerScript.moveSpeed += 1f;
            _playerScript.steerSpeed += 10f;
            _playerScript.GrowSnake();
            _pointTextScript.OnPointIncrease();
        }
    }

    private void SetupPlayerObject()
    {
        var playerObject = GameObject.FindWithTag("Player");
        _playerScript = playerObject.GetComponent<Player>();
    }

    private void SetupPointTextObject()
    {
        var pointTextObject = GameObject.FindWithTag("PointText");
        _pointTextScript = pointTextObject.GetComponent<PointText>();
    }
}