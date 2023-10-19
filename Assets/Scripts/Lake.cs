using UnityEngine;

public class Lake : MonoBehaviour
{
    private Player _playerScript;
    private PointText _pointTextScript;
    private bool _isSlowed = false;

    private void Start()
    {
        var playerObject = GameObject.FindWithTag("Player");
        _playerScript = playerObject.GetComponent<Player>();

        var pointTextObject = GameObject.FindWithTag("PointText");
        _pointTextScript = pointTextObject.GetComponent<PointText>();
    }

    private void Update()
    {
        var distance = Vector3.Distance(_playerScript.transform.position, transform.position);
        if (distance < transform.localScale.x / 2)
        {
            if (_isSlowed == false)
            {
                _playerScript.moveSpeed /= 2;
            }

            _isSlowed = true;
        }
        else
        {
            _playerScript.moveSpeed = 10f + _pointTextScript.currentPoint * 1f;
            _isSlowed = false;
        }
    }
}