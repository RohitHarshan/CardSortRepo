using System;
using System.Collections.Generic;

namespace CardSortAPI.Models
{
    public class Card
    {
        public string Suite { get; set; }
        public string Face { get; set; }
        public Dictionary<string, int> SuiteDict { get; set; }
        public Dictionary<string, int> FaceDict { get; set; }

        public Card(string suite, string face, Dictionary<string, int> suiteDict, Dictionary<string, int> faceDict)
        {
            Suite = suite;
            Face = face;
            SuiteDict = suiteDict;
            FaceDict = faceDict;
        }

        public int CompareTo(Card otherCard)
        {
            int ourSuite = SuiteDict[this.Suite];
            int theirSuite = SuiteDict[otherCard.Suite];
            int theirFace = FaceDict[this.Face];
            int ourFace = FaceDict[otherCard.Face];

            if (theirSuite > ourSuite)
            {
                return -1;
            }
            else if (theirSuite < ourSuite)
            {
                return 1;
            }
            else
            {
                if (theirFace > ourFace)
                {
                    return 1;
                }
                else if (theirFace < ourFace)
                {
                    return -1;
                }
                else
                {
                    return 0;
                }
            }
        }
    }
}
