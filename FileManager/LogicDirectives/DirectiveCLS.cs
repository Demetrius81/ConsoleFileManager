
namespace FileManager
{
    /// <summary>
    /// Класс директивы очистки консоли
    /// </summary>
    internal class DirectiveCLS : Directive, IDirective
    {
        private const string _directiveName = "CLS";
        public string DirectiveName { get => _directiveName; }

        public Varibles RunDirective(Varibles varibles)
        {
            NameToSerch = DirectiveName;

            SVarible = varibles;

            DirectivesConsole();

            PrintDirectiveSelection();

            return SVarible;
        }
    }
}
