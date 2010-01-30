namespace momoney.boot
{
    class Hookup
    {
        static public Command the<Command>() where Command : gorilla.commons.utility.Command, new()
        {
            return new Command();
        }
    }
}