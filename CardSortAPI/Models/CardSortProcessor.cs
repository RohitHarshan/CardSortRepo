using System;
using System.Collections.Generic;

namespace CardSortAPI.Models
{
    public class CardSortProcessor
    {
        
        public List<Card> Cards { get; set; }
        public Dictionary<string, int>  SuiteDict { get; set; }

        public Dictionary<string ,int>  FaceDict { get; set; }


        public CardSortProcessor()
        {
            SuiteDict = MakeSuitDictionary();
            FaceDict = MakeFaceDictionary();
        }
                

        public Dictionary<string, int> MakeSuitDictionary()
        {
            Dictionary<string, int> suitDictionary = new Dictionary<string, int>();
            suitDictionary.Add("T", 1);
            suitDictionary.Add("D", 2);
            suitDictionary.Add("S", 3);
            suitDictionary.Add("C", 4);
            suitDictionary.Add("H", 5);
            return suitDictionary;
        }

        public Dictionary<string, int> MakeFaceDictionary()
        {
            Dictionary<string, int> faceDict = new Dictionary<string, int>();
            faceDict.Add("F", 1);
            faceDict.Add("W", 2);
            faceDict.Add("S", 3);
            faceDict.Add("P", 4);
            faceDict.Add("R", 5);
            faceDict.Add("2", 6);
            faceDict.Add("3", 7);
            faceDict.Add("4", 8);
            faceDict.Add("5", 9);
            faceDict.Add("6", 10);
            faceDict.Add("7", 11);
            faceDict.Add("8", 12);
            faceDict.Add("9", 13);
            faceDict.Add("10", 14);
            faceDict.Add("J", 15);
            faceDict.Add("Q", 16);
            faceDict.Add("K", 17);
            faceDict.Add("A", 18);
            return faceDict;
        }
        public List<Card> Sort()
        {
            Cards.Sort(delegate (Card x, Card y)
            {
                return x.CompareTo(y);
            });
            return Cards;
        }


    }
}
