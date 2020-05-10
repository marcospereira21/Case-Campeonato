using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Campeonato.Resourses
{
    public class StringHandler : IStringHandler
    {
        public StringHandler()
        {

        }

        public string ToUpper(string text)
        {
            return text.ToUpper();
        }

        public string RemoveAccents(string text)
        {
            StringBuilder sbReturn = new StringBuilder();
            var arrayText = text.Normalize(NormalizationForm.FormD).ToCharArray();
            foreach (char letter in arrayText)
            {
                if (CharUnicodeInfo.GetUnicodeCategory(letter) != UnicodeCategory.NonSpacingMark)
                    sbReturn.Append(letter);
            }
            return sbReturn.ToString();
        }

        public string RemoveSpecial(string text, string antigo, string novo)
        {
            return text.Replace(antigo, novo);
        }

        public string HiffenLastWord(string text, int letterLastWord)
        {
            StringBuilder sbReturn = new StringBuilder();

            var arrayText = text.Split(' ');

            if (arrayText == null || arrayText.Length == 1)
                return text;

            if (arrayText.Last().Trim().Length != letterLastWord)
                return text;

            for (int i = 0; i < arrayText.Length - 1; i++)
            {
                sbReturn.Append(arrayText[i].Trim());
            }

            sbReturn.Append($"-{arrayText.Last().Trim()}");


            return sbReturn.ToString();
        }
    }
}
