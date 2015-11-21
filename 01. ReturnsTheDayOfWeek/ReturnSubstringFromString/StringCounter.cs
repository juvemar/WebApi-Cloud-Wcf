namespace ReturnSubstringFromString
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.ServiceModel;
    using System.Text;

    public class StringCounter : IStringCounter
    {
        public int CountStringAppearances(string textPart, string fullText)
        {
            if (textPart == null || fullText == null)
            {
                throw new NullReferenceException("Cannot use null as a string.");
            }

            var count = 0;

            for (int i = 0; i < fullText.Length; i++)
            {
                for (int j = 0; j < textPart.Length; j++)
                {
                    var currentLetter = fullText[i + j].ToString().ToLower();

                    if (currentLetter != textPart[j].ToString().ToLower())
                    {
                        break;
                    }

                    if (j == textPart.Length - 1)
                    {
                        count++;
                    }
                }
            }

            return count;
        }
    }
}
