using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject cardObject;
    public Dictionary<string, string> cards = new Dictionary<string, string>();
    public TMP_InputField perguntaText, respostaText;
    private LinkedList<KeyValuePair<string, string>> currentCards = new LinkedList<KeyValuePair<string, string>>();

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this.gameObject);
    }

    public void GenerateCards()
    {
        foreach (string card in cards.Keys)
        {
            if (!currentCards.Contains(new KeyValuePair<string, string>(card, cards[card])))
                currentCards.AddLast(new KeyValuePair<string, string>(card, cards[card]));
        }

        SetCardObject();
    }

    public void RevealCard()
    {
        if (cardObject.GetComponentInChildren<TextMeshProUGUI>().text == cards[currentCards.First.Value.Key])
        {
            SkipCard();
            return;
        }

        cardObject.GetComponentInChildren<TextMeshProUGUI>().text = cards[currentCards.First.Value.Key];
    }

    public void SkipCard()
    {
        currentCards.AddLast(currentCards.First.Value);
        currentCards.RemoveFirst();
        SetCardObject();
    }

    public void DeleteCard()
    {
        currentCards.RemoveFirst();
        SetCardObject();
    }

    public void CreateCard()
    {
        cards.Add(perguntaText.text, respostaText.text);

        ClearCard();
    }

    public void ClearCard()
    {
        perguntaText.text = "";
        respostaText.text = "";
    }


    private void SetCardObject()
    {
        if (currentCards.Count > 0)
            cardObject.GetComponentInChildren<TextMeshProUGUI>().text = currentCards.First.Value.Key;
        else
            cardObject.GetComponentInChildren<TextMeshProUGUI>().text = "";
    }
}
