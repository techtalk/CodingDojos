namespace CodingDojoWorkSmarterNotHarder.VSResharper
{
    public class BlocksWithoutBlocks
    {
        public void IfBlocks(bool shouldEnterIfBlock, object canBeNull)
        {
            // type "if" followed by <tab> and if you are satisified with the condition another <tab>



            // type "shou" <tab> ".if"



            // type "can" <tab> ".nu" <tab>


        }

        public void ForEachBlocks(string[] input)
        {
            // type "fore" followed by <tab> and, if you are satisified with the thing to iterate over, another <tab> twice
            // give the iterationvariable a name and a final <tab> puts you inside the block    
         


            // type "inp" <tab> ".fo" <tab>
         

        }

        public Person EncloseWith(bool shouldAssignDefaultNames)
        {
            var result = new Person();

            // select the next 2 statements then hit CTRL K + S type "if" then <tab> then the condition (in this case the argument of the method)

            result.FirstName = "John";
            result.LastName = "Doe";

            return result;
        }

        public class Person
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
        }
    }
}
