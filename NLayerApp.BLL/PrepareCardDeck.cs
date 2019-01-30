using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic
{
    public class PrepareCardDeck
    {
        public static List<OneCard> DoOneDeck()
        {
            var cards = new List<OneCard>(52);
            foreach (var suitName in Enum.GetNames(typeof(Enums.Suit)))
            {
                foreach (KeyValuePair<string, int> keyValue in CardPointDiction.CardPointDict)
                {
                    cards.Add(new OneCard
                    {
                        CardSuit = suitName,
                        CardNumber = keyValue.Key
                    });
                }
            }

            return cards;
        }

        public static int GetCardRandomIndex(int deckLength)
        {
            if (deckLength > 0)
            {
                var random = new Random();
                int value = random.Next(0, deckLength);
                return value;
            }

            return 0;
        }

        public static OneCard GetSomeCard(List<OneCard> newCardDeck)
        {
            int indexCard = GetCardRandomIndex(newCardDeck.Count);
            if (indexCard >= 0)
            {
                var someCard = newCardDeck[indexCard];
                newCardDeck.RemoveAt(indexCard);

                return someCard;
            }

            return newCardDeck[0];
        }
    }
}
