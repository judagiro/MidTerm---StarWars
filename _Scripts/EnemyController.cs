using UnityEngine;
using System.Collections;



[System.Serializable]
public class Speed {
	public float minSpeed, maxSpeed;
}

[System.Serializable]
public class Boundary {
	public float xMin, xMax, yMin, yMax;
}


public class EnemyController : MonoBehaviour
{
    // PUBLIC INSTANCE VARIABLES
    public Speed speed;
    public Boundary boundary;


    private Transform _transform;
    private GameObject _spawnPoint;
    public GameController gameController;

    // PRIVATE INSTANCE VARIABLES
    private float _CurrentSpeed;
    private float _CurrentDrift;

    // Use this for initialization
    void Start()
    {
        this._Reset();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 currentPosition = gameObject.GetComponent<Transform>().position;
        currentPosition.y -= this._CurrentSpeed;
        gameObject.GetComponent<Transform>().position = currentPosition;

        // Check bottom boundary
        if (currentPosition.y <= boundary.yMin)
        {
            this._Reset();
        }
    }

    // resets the gameObject
    private void _Reset()
    {
        this._CurrentSpeed = Random.Range(speed.minSpeed, speed.maxSpeed);
        Vector2 resetPosition = new Vector2(Random.Range(boundary.xMin, boundary.xMax), boundary.yMax);
        gameObject.GetComponent<Transform>().position = resetPosition;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            // move the player's position to the spawn point's position
            this._transform.position = this._spawnPoint.transform.position;

        }
        if (other.gameObject.CompareTag("EndPlane"))
        {
            // The player recieve 10 points
            this.gameController.ScoreValue += 10;

        }

    }

    
}