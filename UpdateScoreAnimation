using UnityEngine;
using TMPro;
using System;

public class ScoreUI : MonoBehaviour
{
    //score text
    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] private ScoreManager _scoreManager;
    [SerializeField] private SpriteRenderer _innerRing;
    [SerializeField] private SpriteRenderer _outerRing;
    //if the rings are spinning
    bool spinning;
    //if the rings are growing
    bool growing;
    //the current dimension of the outer ring
    float currentDimension;
    //the minimum dimension of the outer ring
    float minDimension;
    //the maximum dimension of the outer ring
    float maxDimension;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spinning = false;
        growing = false;
        minDimension = 140f;
        maxDimension = 180f;
        currentDimension = minDimension;
    }

    void UpdateScoreUI(int newScore)
    {
        //show the new score
        _scoreText.text = newScore.ToString();
        //grow and spin the rings
        Grow();
    }

    void OnEnable()
    {
        _scoreManager.OnScoreChanged += UpdateScoreUI;
        _scoreText.text = "0";
    }

    void OnDisable()
    {
        _scoreManager.OnScoreChanged -= UpdateScoreUI;
    }

    void Grow()
    {
        //if the rings are already spinning
        if (spinning)
        {
            //The rings will now be growing
            growing = true;
        }
        //if the rings are not already spinning
        else
        {
            spinning = true;
            growing = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //if the rings are not spinning
        if (!spinning) { return; }

        float sizeIncrement = 90f * Time.deltaTime;

        //if the rings are growing
        if (growing)
        {
            //add the increment to the current dimension
            currentDimension += sizeIncrement;
            //if the current dimension is too large
            if (currentDimension >= maxDimension)
            {
                currentDimension = maxDimension;
                growing = false;
            }
        }
        //if the score circle is shrinking in size
        else
        {
            //subtract the increment from the current dimensions
            currentDimension -= sizeIncrement;
            //if the dimensions are too small
            if (currentDimension <= minDimension)
            {
                currentDimension = minDimension;

                //the spinner is no longer spinning
                spinning = false;
            }
        }

        //calculate the respective scales of the rings
        float outerScale = currentDimension / minDimension;
        _outerRing.transform.localScale = new Vector3(outerScale, outerScale);
        float innerScale = (currentDimension - 10f) / (minDimension - 10f);
        _innerRing.transform.localScale = new Vector3(innerScale, innerScale);

        //rotate the rings
        _innerRing.transform.rotation *= Quaternion.AngleAxis(-120f * Time.deltaTime, new Vector3(0, 0, 1f));
        _outerRing.transform.rotation *= Quaternion.AngleAxis(120f * Time.deltaTime, new Vector3(0, 0, 1f));
    }
}
