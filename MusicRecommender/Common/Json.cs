using System;

namespace MusicRecommender.Common
{
    public class Json
    {
        public string Value { get; }

        public Json(string value)
        {
            ValidateJson(value);
            Value = value;
        }

        private void ValidateJson(string maybeJson)
        {
            var isValid = true;  //Some validation form 3d party library

            if (!isValid)
                throw new InvalidJsonExpception(maybeJson);
        }

        public T ConvertFrom<T>()
        {
            try
            {
                //Convert logic here
                return default(T);
            }
            catch(Exception ex)
            {
                throw new ConvertFromJsonException<T>(Value, ex.Message);
            }
        }

        public Json ConvertTo<T>(T type)
        {
            try
            {
                var maybeJson = "[]"; //Deserialize logic here
                return new Json(maybeJson);
            }
            catch (Exception ex)
            {
                throw new ConvertToJsonException<T>(Value, ex.Message);
            }
        }
    }
}