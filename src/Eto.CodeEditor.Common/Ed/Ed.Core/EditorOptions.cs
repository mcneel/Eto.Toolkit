using System;

namespace Ed.Core
{
  public class Language
  {
    public string Key { get; }
    public string Description { get; }

    public Language(string key, string desc) => (Key, Description) = (key, desc);
  }

  public class EditorOptions
  {
    public Language Language { get; }
    public Theme Theme { get; }

    public EditorOptions(Language language, Theme theme) => (Language, Theme) = (language, theme);
  }
}
