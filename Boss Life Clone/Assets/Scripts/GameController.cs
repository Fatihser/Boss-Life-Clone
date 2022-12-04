using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] private Animator panelAnimator;
    [SerializeField] private Animator girlCharacterAnimator;
    [SerializeField] private Animator guyCharacterAnimator;


    [SerializeField] private GameObject girlCharacter;
    [SerializeField] private GameObject guyCharacter;


    [SerializeField] private GameObject StarFallEffect;
    [SerializeField] private GameObject dollarEffect;
    [SerializeField] private GameObject[] greenConfetiEffect;
    [SerializeField] private GameObject[] redConfetiEffect;

    public Text stateText;
    private Animator stateTextAnimator;

    private void Start()
    {
        Invoke("OpenFirstPanel", 2.5f);
        stateTextAnimator = stateText.gameObject.GetComponent<Animator>();
    }

    private void OpenFirstPanel()
    {
        panelAnimator.SetTrigger("open");
    }
    private void OpenSecondPanel()
    {
        panelAnimator.SetTrigger("open2");
    }

    public void HireButton()
    {
        StarFallEffect.SetActive(true);
        girlCharacterAnimator.SetTrigger("clap");
        panelAnimator.SetTrigger("close");
        stateText.text ="Correct!";
        stateText.color = Color.green;
        stateTextAnimator.SetTrigger("decision");
        foreach (var item in greenConfetiEffect)
        {
            item.SetActive(true);
        }
        Invoke("GoStepTwo", 4f);
    }

    public void DismissButton()
    {
        girlCharacterAnimator.SetTrigger("disbelief");
        panelAnimator.SetTrigger("close");
        stateText.text = "Bad Decision!";
        stateText.color = Color.red;
        stateTextAnimator.SetTrigger("decision");
        foreach (var item in redConfetiEffect)
        {
            item.SetActive(true);
        }
        Invoke("GoStepTwo", 4f);
    }

    public void PromoteButton()
    {
        guyCharacterAnimator.SetTrigger("clap");
        panelAnimator.SetTrigger("close2");
        stateText.text = "Correct!";
        stateText.color = Color.green;
        stateTextAnimator.SetTrigger("decision");
        foreach (var item in greenConfetiEffect)
        {
            item.SetActive(true);
        }
        Invoke("levelComplated", 3.5f);
    }

    public void FireButton()
    {
        guyCharacterAnimator.SetTrigger("angry");
        panelAnimator.SetTrigger("close2");
        stateText.text = "Good Job!";
        stateText.color = Color.green;
        stateTextAnimator.SetTrigger("decision");
        foreach (var item in greenConfetiEffect)
        {
            item.SetActive(true);
        }
        Invoke("levelComplated", 3.5f);
    }

    private void GoStepTwo()
    {
        panelAnimator.SetTrigger("transition");
        Invoke("CharacterChange", 0.5f);
        Invoke("OpenSecondPanel", 4f);
    }

    private void CharacterChange()
    {
        Destroy(girlCharacter);
        guyCharacter.SetActive(true);
    }

    private void levelComplated()
    {
        Vibration.vibrate(500);
        dollarEffect.SetActive(true);
        panelAnimator.SetTrigger("complated");
    }
}
