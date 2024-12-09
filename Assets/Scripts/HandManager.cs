using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LostDeck;
using System;
using System.Security;


public class HandManager : MonoBehaviour
{
    public DeckManager deckManager;
    public GameObject cardPrefab; //assign card prefab in de inspector
    public Transform handTransform; // root of the hand position
    public float fanSpread = 7.5f;
    public float cardSpacing = 100f;
    public float verticalSpacing = 100f;
    public List<GameObject> cardsInHand = new List<GameObject>(); // hold a list of the card objects in our hand

    void Start()
    {
        
    }

    public void AddCardToHand(Card cardData)
    {
        //Instantiate the card
        GameObject newCard = Instantiate(cardPrefab, handTransform.position, Quaternion.identity, handTransform);
        cardsInHand.Add(newCard);

        //set the CardData of the instaniated card
        newCard.GetComponent<CardDisplay>().cardData = cardData;

        UpdateHandVisuals();
    }

    void Update() {
        UpdateHandVisuals();
    }

    private void UpdateHandVisuals()
    {
        int cardCount = cardsInHand.Count;
        if(cardCount == 1){
            cardsInHand[0].transform.localRotation = Quaternion.Euler(0f,0f, 0f);
            cardsInHand[0].transform.localPosition = new Vector3(0f, 0f, 0f);
            return ;
        }

        for(int i = 0; i < cardCount; i++){
            float rotationAngle = (fanSpread * (i - (cardCount - 1) / 2F));
            cardsInHand[i].transform.localRotation = Quaternion.Euler(0f,0f, rotationAngle);

            float horizontalOffset = (cardSpacing * (i - (cardCount - 1) / 2F));

            float normalizedPosition = (2f * i / (cardCount - 1) - 1f); // Normalize card position between -1 and 1
            float verticalOffset = verticalSpacing * ( 1 - normalizedPosition * normalizedPosition);

            //set card positions
            cardsInHand[i].transform.localPosition = new Vector3(horizontalOffset, verticalOffset, 0f);
        }
    }
}
