using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	private static GameManager instance;

	[SerializeField]
	private GameObject coinPrefab;

	[SerializeField]
	private Text coinTxt;

    [SerializeField]
    private Text TimerText;

	private int collectedCoins;

	public static GameManager Instance
	{
		get
		{
			if (instance == null) 
			{
				instance = FindObjectOfType<GameManager> ();
			}
			return instance;
		}

	}

	public GameObject CoinPrefab
	{
		get
		{
			return coinPrefab;
		}
	}

	public int CollectedCoins 
	{
		get 
		{
			return collectedCoins;
		}

		set 
		{
			coinTxt.text = value.ToString ();
			this.collectedCoins = value;
		}
	}


	// Use this for initialization
	void Start () {
        //TimerText.text = "TIME 00:00";
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
