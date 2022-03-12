using System;
using System.Collections.Generic;

namespace CardSortAPI.Models
{
	public class Card
	{
		public string suite { get; set; }
		public string face { get; set; }
		public Dictionary<string, int> suiteDict { get; set; }
		public Dictionary<string, int> faceDict { get; set; }

		public Card(string suite, string face, Dictionary<string, int> suiteDict, Dictionary<string, int> faceDict)
		{
			this.suite = suite;
			this.face = face;
			this.suiteDict = suiteDict;
			this.faceDict = faceDict;
		}

		public int	CompareTo(Card otherCard)
		{
			int ourSuite = suiteDict[this.suite];
			int theirSuite = suiteDict[otherCard.suite];
			int theirFace = faceDict[this.face];
			int ourFace = faceDict[otherCard.face];

			if (theirSuite > ourSuite)
				return -1;
			else if (theirSuite < ourSuite)
				return 1;
			else
			{
				if (theirFace > ourFace)
					return 1;
				else if (theirFace < ourFace)
					return -1;
				else
					return 0;
			}
		}
	}
}
