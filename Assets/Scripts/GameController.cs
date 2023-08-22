
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] Button RollButton, OkButton;
    [SerializeField] PlayerIngameData[] Players;
    [SerializeField] GameObject[] FirstDice;
    [SerializeField] GameObject[] SecondDice;
    [SerializeField] GameObject[] FirstDiceFilled;
    [SerializeField] GameObject[] SecondDiceFilled;
    [SerializeField] GameObject EndGamePanel;
    [SerializeField] TextMeshProUGUI WinnerText;
    [SerializeField] GameObject RollButtonUI, FilledRollButtonUI;
    [SerializeField] GameObject OKButtonUI, FilledOKButtonUI;

    public UserData userData;

    int turn = 0;
    int currentSum = 0;
    bool rolled;

    public void Start()
    {
        Players[0].name = userData.PlayerName;
        UpdatePlayerText();

        turn = 0;
        RollButton.onClick.AddListener(() => Roll());
        OkButton.onClick.AddListener(() => AcceptCurrent());
    }

    public async Task Roll()
    {
        RollButtonUI.SetActive(false);
        FilledRollButtonUI.SetActive(true);

        await Task.Delay(100);

        RollButtonUI.SetActive(true);
        FilledRollButtonUI.SetActive(false);

        rolled = true;
        int firstVal = 0, secondVal = 0;

        for (int i = 0; i < 20; i++)
        {
            await Task.Delay(100);
            firstVal = Random.Range(1, 7);
            secondVal = Random.Range(1, 7);

            UpdateDiceImage("left", firstVal);
            UpdateDiceImage("right", secondVal);
        }
        

        if (firstVal + secondVal == 7)
        {
            Players[turn].total = 0;
            turn = (turn + 1) % 2;
            rolled = false;
            UpdateDiceImageFilled("left", firstVal);
            UpdateDiceImageFilled("right", secondVal);
            await Task.Delay(1000);

            UpdatePlayerText();
            return;
        }
         
        else
        {
            currentSum = firstVal + secondVal;
        }

    }

    public async Task AcceptCurrent()
    {
        if (!rolled)
            return;

        OKButtonUI.SetActive(false);
        FilledOKButtonUI.SetActive(true);

        await Task.Delay(100);

        OKButtonUI.SetActive(true);
        FilledOKButtonUI.SetActive(false);

        rolled = false;
        Players[turn].total += currentSum;

        if (Players[turn].total >= 50)
        {
            WinnerText.text = Players[turn].name + " Wins!";
            Players[turn].nameText.color = Color.white;
            EndGamePanel.SetActive(true);
        }

        else
        {
            turn = (turn + 1) % 2;
            UpdatePlayerText();
        }

        
    }

    public void UpdatePlayerText()
    {
        foreach (var p in Players)
        {
            p.nameText.text = p.name;
            p.totalText.text = p.total.ToString();
        }

        Players[turn].nameText.color = Color.yellow;
        Players[(turn + 1) % 2].nameText.color = Color.white;

        UpdateDiceImage("left", 7);
        UpdateDiceImage("right", 7);

    }

    public void UpdateDiceImage(string dice, int number)
    {
        if (dice == "left")
        {
            for (int i = 0; i < 6; i++)
            {
                FirstDice[i].SetActive(false);
                FirstDiceFilled[i].SetActive(false);
            }
            FirstDice[number - 1].SetActive(true);
        }

        if (dice == "right")
        {
            for (int i = 0; i < 6; i++)
            {
                SecondDice[i].SetActive(false);
                SecondDiceFilled[i].SetActive(false);
            }
            SecondDice[number - 1].SetActive(true);
        }

    }

    public void UpdateDiceImageFilled(string dice, int number)
    {
        if (dice == "left")
        {
            for (int i = 0; i < FirstDiceFilled.Length; i++)
            {
                FirstDiceFilled[i].SetActive(false);
                FirstDice[i].SetActive(false);
            }
            FirstDiceFilled[number - 1].SetActive(true);
        }

        if (dice == "right")
        {
            for (int i = 0; i < SecondDiceFilled.Length; i++)
            {
                SecondDiceFilled[i].SetActive(false);
                SecondDice[i].SetActive(false);
            }
            SecondDiceFilled[number - 1].SetActive(true);
        }

    }

    [System.Serializable]
    struct PlayerIngameData
    {
        public string name;
        public int total;
        public TextMeshProUGUI nameText;
        public TextMeshProUGUI totalText;
    }
}
