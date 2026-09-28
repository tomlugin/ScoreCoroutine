using System.Collections;
using UnityEngine;
using TMPro;
public class ShowScore : MonoBehaviour
{
    //the outer spinner
    public GameObject outerSpinner;
    //the inner spinner
    public GameObject innerSpinner;
    //the score text amount
    public TextMeshPro amount;
    //is the spinner spinning?
    bool spinning;
    //is the spinner growing?
    bool growing;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //set the starting score
        amount.text = ScoreManager.score.ToString();
        spinning = false;
        growing = false;
    }

    public void UpdateScoreCircle()
    {
        //update the score text
        amount.text = ScoreManager.score.ToString();
        //if the coroutine is already going
        if (spinning == true)
        {
            //make the score circle grow
            growing = true;
        }
        else
        {
            //start the coroutine
            StartCoroutine("AnimateSpinner");
        }

    }

    //animate the score circle when adding to the score
    public IEnumerator AnimateSpinner()
    {
        //the spinner is spinning
        spinning = true;
        //the score circle must first grow
        growing = true;
        //the current height and width of the outer spinner
        float currentDimension = GameConstants.scoreCircleDimension;
        //the maximum dimension of the score circle
        float maxDimension = 205f;
        //the increment to add and subtract from the score circle's dimensions
        float increment = 1f * 30f * Time.deltaTime;

        //while the score circle is changing in size
        while (spinning == true)
        {
            //if the score circle is growing in size
            if (growing == true)
            {
                //add the increment to the current dimensions
                currentDimension += increment;
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
                currentDimension -= increment;
                //if the dimensions are too small
                if (currentDimension <= GameConstants.scoreCircleDimension)
                {
                    currentDimension = GameConstants.scoreCircleDimension;
                    //set the outer and inner spinner scale
                    outerSpinner.transform.localScale = Vector3.one;
                    innerSpinner.transform.localScale = Vector3.one;

                    //the spinner is no longer spinning
                    spinning = false;
                    //finish the coroutine
                    yield break;
                }
            }

            //calculate the scale of the spinners
            float outerScale = currentDimension / GameConstants.scoreCircleDimension;
            outerSpinner.transform.localScale = new Vector3(outerScale, outerScale);
            //inner spinner's size is 20 less than the outer spinner
            float innerScale = (currentDimension - 20f) / (GameConstants.scoreCircleDimension - 20);
            innerSpinner.transform.localScale = new Vector3(innerScale, innerScale);

            //rotate the outer and inner spinner
            outerSpinner.transform.Rotate(0, 0, 5f * 30f * Time.deltaTime, Space.World);
            innerSpinner.transform.Rotate(0, 0, -5f * 30f * Time.deltaTime, Space.World);
            yield return null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
