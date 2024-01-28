using StrigTransForm;
using StrigTransForm.Interfaces;

namespace TransFormStringTes
{
    public class String_TransformerTest
    {
        //private readonly String_Transformer _transformer;
        //public String_TransformerTest(String_Transformer transformer)
        //{
        //    _transformer = transformer;
        //}
        public static string outPut = "oLLeH";

        [Fact]
        public void PlainText()
        {
            string inPut = "Hello";

            String_Transformer _transformer = new String_Transformer();

            var result = _transformer.Transformer(inPut);

            result.Equals(outPut);

        }

        [Fact]
        public void PlainTextWithUpperWowel()
        {
            string inPut = "hEllo";
            
            String_Transformer _transformer = new String_Transformer();

            var result = _transformer.Transformer(inPut);


            result.Equals(outPut);

        }

        [Fact]
        public void PlainTextWithNumbers()
        {
            string inPut = "1Hello1";

            String_Transformer _transformer = new String_Transformer();

            var result = _transformer.Transformer(inPut);

            result.Equals(outPut);

        }

        [Fact]
        public void PlainTextWithNumbersAtMidle()
        {
            string inPut = "He12l345lo";

            String_Transformer _transformer = new String_Transformer();

            var result = _transformer.Transformer(inPut);

            result.Equals(outPut);

        }
    }
}