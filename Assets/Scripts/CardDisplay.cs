using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using LostDeck;

public class CardDisplay : MonoBehaviour
{
    public Card cardData;
    public Image cardImage;
    public TMP_Text nameText;
    public TMP_Text healthText;
    public TMP_Text damageText;
    public Image[] typeImages;

    private Color[] cardColors = {
         new Color( 0.3132f, 0.0165f, 0.0159f), // fire
        new Color(0.8f, 0.52f, 0.24f), //earth
        new Color(0.007f, 0.018f, 0.358f), // water
        new Color(0.2327042f, 0.05781015f, 0.2052875f ), //dark
        new Color(0.4792f, 0.4654f, 0.3752f), //light
        new Color(0.1472f, 0.4728f, 0.5169f) //air
    };

        private Color[] typeColors = {
        new Color(0.9773f, 0.4230f, 0.2710f), // fire
        new Color(0.45f, 0.32f, 0.21f), //earth
        new Color(0.2215f, 0.6146f, 0.9547f), // water
        new Color(0.5f, 0.05781015f, 0.4f ), //dark
        new Color(1f, 0.9934f, 0.3905f), //light
        new Color(0.6211f, 0.9030f, 0.9169f) //air
    };

    void Start()
    {
        UpdateCardDisplay();
    }

    public void UpdateCardDisplay(){
        //Update the maincard image color gebasseerd op de type
        cardImage.color = cardColors[(int)cardData.cardType[0]];

        nameText.text = cardData.cardName;
        healthText.text = cardData.health.ToString();
        damageText.text = $"{cardData.damageMin} - {cardData.damageMax}";

        //Update type images
        for(int i = 0; i < typeImages.Length; i++){
            if(i < cardData.cardType.Count){
                typeImages[i].gameObject.SetActive(true);
                typeImages[i].color = typeColors[(int)cardData.cardType[i]];
            }
            else {
                typeImages[i].gameObject.SetActive(false);
            }
        }
    }

}
