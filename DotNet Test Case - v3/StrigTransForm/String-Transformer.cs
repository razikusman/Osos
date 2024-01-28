using StrigTransForm.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrigTransForm
{
    public class String_Transformer : IStringTransformer
    {
        public string Transformer(string mystring = "Hello")
        {
            char[] Vowels = { 'A', 'E', 'I', 'O', 'U', 'a', 'e', 'i', 'o', 'u' };


            var list = mystring.ToCharArray();

            //convert the vowels to lovercase and other to uppsercase
            list = list.Select(l => Vowels.Contains(l) ? ConvertToLoverCase(l) : ConvertToUppserCase(l)).ToArray();

            //reverse the array
            var reverseStringArray = list.Reverse().ToArray();

            //make the string from char
            var reversString = String.Concat(reverseStringArray).ToString();

            //spceless string
            var spacelessString = reversString.Replace(" ", "");
            Console.WriteLine(spacelessString);

            return reversString;
        }

        private static char ConvertToUppserCase(char letter)
        {
            //if a digit return empty space character
            return Char.IsDigit(letter) ? ' ' : Char.ToUpper(letter);
        }

        private static char ConvertToLoverCase(char letter)
        {
            //if a digit return empty space character
            return Char.IsDigit(letter) ? ' ' : Char.ToLower(letter);
        }
    }
}
