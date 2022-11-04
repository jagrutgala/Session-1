namespace BoilerDemo.Exceptions
{
    public class PolicyNotAcceptedError: ApplicationException
    {
        public PolicyNotAcceptedError()
            :base( "Policy was not accepted ")
        {

        }
    }
}
