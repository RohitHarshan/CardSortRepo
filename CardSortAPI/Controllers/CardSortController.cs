using System.Collections.Generic;
using System.Linq;
using CardSortAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CardSortAPI.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class CardSortController : ControllerBase
    {
        private readonly ILogger<CardSortController> _logger;

        public CardSortController(ILogger<CardSortController> logger)
        {
            _logger = logger;
        }
        /// <summary>
        /// Method to sort cards based on suit and face value
        /// </summary>
        /// <param name="cardsList"></param>
        /// <returns>List<string></string></returns>
        [HttpPost(Name = "SortCards")]
        public List<string> Sort(List<string> cardsList)
        {
            try
            {
                CardSortProcessor cardSortProcessor = new CardSortProcessor();
                if (cardsList != null)
                {
                    var finalCardsList = cardsList.Select(x =>
                  {
                      if (x.Contains(Constants.T))
                      {
                          x = x.Replace(Constants.FOUR, Constants.F); // replacing 4 to F for removing duplicates
                          x = x.Replace(Constants.TWO, Constants.W); // replacing 4 to F for removing duplicates
                          return new Card(x[1].ToString(),
                            x[0].ToString(), cardSortProcessor.SuiteDict, cardSortProcessor.FaceDict);
                      }
                      else if (x.Length > 2) // condition for '10' digit
                      {
                          return new Card(x[2].ToString(),
                       x[0].ToString() + x[1].ToString(), cardSortProcessor.SuiteDict, cardSortProcessor.FaceDict);
                      }
                      else
                      {
                          return new Card(x[1].ToString(),
                          x[0].ToString(), cardSortProcessor.SuiteDict, cardSortProcessor.FaceDict);
                      }
                  }).ToList();

                    cardSortProcessor.Cards = finalCardsList;

                    var sortedList = cardSortProcessor.Sort();
                    var responseList = sortedList.Select(x => string.Concat(x.Face.Replace(Constants.F, Constants.FOUR).Replace(Constants.W, Constants.TWO), x.Suite)).ToList();

                    return responseList;
                }
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return null;
        }
    }
}
