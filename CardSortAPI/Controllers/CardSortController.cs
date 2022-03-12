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
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<CardSortController> _logger;

        public CardSortController(ILogger<CardSortController> logger)
        {
            _logger = logger;
        }

        [HttpPost(Name = "SortCards")]
        public List<string> Sort(List<string> cardsList)
        {
            CardSortProcessor cardSortProcessor = new CardSortProcessor();
            var finalCardsList = cardsList.Select(x =>
            {
                if (x.Contains("T"))
                {
                    x = x.Replace("4", "F");
                    x = x.Replace("2", "W");
                    return new Card(x[1].ToString(),
                    x[0].ToString(), cardSortProcessor.SuiteDict, cardSortProcessor.FaceDict);
                }   
                else if (x.Length > 2)
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
            var responseList = sortedList.Select(x => string.Concat(x.face.Replace("F","4").Replace("W","2"), x.suite)).ToList();

            return responseList;

        }
    }
}
