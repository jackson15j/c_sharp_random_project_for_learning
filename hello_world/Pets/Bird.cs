/*
  Working through the dotnet tutorials. Now on multiple files:

  * https://docs.microsoft.com/en-us/dotnet/core/tutorials/using-with-xplat-cli#working-with-multiple-files
 */

using Pets;

public class Bird : IPet
{
    public string TalkToOwner() => "Cheep-cheep!";
}
