using System.Collections.Generic;
using TrickingLibrary.Api.Models;

namespace TrickingLibrary.Api
{
    public class TrickyStore
    {
        private readonly List<Trick> _tricks;

        public TrickyStore()
        {
            _tricks = new List<Trick>();
        }

        public IEnumerable<Trick> All => _tricks;

        public void Add(Trick trick)=>
            _tricks.Add(trick);
    }
}