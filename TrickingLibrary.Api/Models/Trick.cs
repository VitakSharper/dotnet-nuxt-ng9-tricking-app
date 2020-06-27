using System;

namespace TrickingLibrary.Api.Models
{
    public class Trick
    {
        public string Id { get; set; }=Guid.NewGuid().ToString();
        public string Name { get; set; }    
    }
}