namespace momoney.boot
{
    class hookup
    {
        static public Command the<Command>() where Command : gorilla.commons.utility.Command, new()
        {
            return new Command();
        }
    }
}