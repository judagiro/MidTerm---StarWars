using UnityEngine;
using System.Collections;

using UnityEngine.UI;

public class GameController : MonoBehaviour {
	// PUBLIC INSTANCE VARIABLES
	public int enemyCount;
	public GameObject enemy;
    private int _hullValue;
    private int _scoreValue;

    [Header("UI Objects")]
    public Text HullLabel;
    public Text ScoreLabel;


    

    public int HullValue
    {
        get
        {
            return this._hullValue;
        }

        set
        {
            this._hullValue = value;
            if (this._hullValue <= 0)
            {
                this._endGame();
            }
            else
            {
                this.HullLabel.text = "Hull: " + this._hullValue;
            }
        }
    }

    public int ScoreValue
    {
        get
        {
            return this._scoreValue;
        }

        set
        {
            this._scoreValue = value;
            this.ScoreLabel.text = "Score: " + this._scoreValue;
        }
    }

    // Use this for initialization
    void Start () {
        this.HullValue = 5;
        this.ScoreValue = 0;
        this._GenerateEnemies ();

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	// generate Clouds
	private void _GenerateEnemies() {
		for (int count=0; count < this.enemyCount; count++) {
			Instantiate(enemy);
		}
	}

    private void _endGame()
    {
        //this.GameOverLabel.gameObject.SetActive(true);
        this.ScoreLabel.text = "Final Score: " + this.ScoreValue;
        this.ScoreLabel.gameObject.SetActive(true);
        //this.RestartButton.gameObject.SetActive(true);
        this.ScoreLabel.gameObject.SetActive(false);
        this.HullLabel.gameObject.SetActive(false);
        
        
    }
}
