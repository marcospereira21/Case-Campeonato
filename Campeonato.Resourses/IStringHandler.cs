namespace Campeonato.Resourses
{
    public interface IStringHandler
    {
        string HiffenLastWord(string text, int letterLastWord);
        string RemoveAccents(string text);
        string ToUpper(string text);
    }
}