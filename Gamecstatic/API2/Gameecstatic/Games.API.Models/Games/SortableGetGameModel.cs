using System;
using System.Collections.Generic;
using System.Text;

namespace Games.API.Models.Games
{
    public class SortableGetGameModel
    {
        public string SearchTerm { get; set; }
        public string SortBy { get; set; }
        public int[] Tags { get; set; }
        public int[] Categories { get; set; }
        public int Page { get; set; }
    }
}
