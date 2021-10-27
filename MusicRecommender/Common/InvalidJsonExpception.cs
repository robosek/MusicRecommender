using System;

namespace MusicRecommender.Common
{
    public class InvalidJsonExpception : Exception
    {
        public InvalidJsonExpception(string invalidJson)
            : base($"Provided text is not in valid json format. Value = {invalidJson}")
        { }
    }
}
