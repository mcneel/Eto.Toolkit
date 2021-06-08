using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using Eto.Forms;
using System.Linq;

namespace Ed.Eto.TestApp
{
  internal class MainFormViewModel : INotifyPropertyChanged
  {
    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void RaisePropertyChanged (string propertyName)
    {
      var handler = PropertyChanged;
      handler?.Invoke (this, new PropertyChangedEventArgs (propertyName));
    }

    public bool EditorIsReady { get; private set; }

    public string LanguageId { get; set; }
    //public ObservableCollection<ListItem> LangugageIds { get; private set; }

    public bool TextEditorOptions_InsertSpaces { get; set; }

    public void InitializeData(
      //IList<string> languageIds,
      string languageId
    )
    {
      //LangugageIds = new ObservableCollection<ListItem>(languageIds.Select(lid => new ListItem { Key = lid, Text = lid }));
      LanguageId = languageId;
      EditorIsReady = true;

      //RaisePropertyChanged("LanguageIds");
      RaisePropertyChanged("LanguageId");
      RaisePropertyChanged("EditorIsReady");
    }
  }
}
