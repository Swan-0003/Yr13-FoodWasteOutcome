namespace FoodWasteAPP;

public partial class TipsPage : ContentPage
{
    public TipsPage()
    {
        InitializeComponent();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        LoadNotes();
    }

    private void OnAddNoteClicked(object? sender, EventArgs e)
    {
        string note = NoteEditor.Text;

        if (!string.IsNullOrWhiteSpace(note))
        {
            List<string> notes = LoadSavedNotes();

            notes.Add(note);

            SaveNotes(notes);

            NoteEditor.Text = "";

            LoadNotes();
        }
    }

    private void LoadNotes()
    {
        NotesList.Children.Clear();

        List<string> notes = LoadSavedNotes();

        foreach (string note in notes.ToList())
        {
            Border noteCard = new Border
            {
                BackgroundColor = Color.FromArgb("#FFFFFF"),
                Stroke = Color.FromArgb("#D8DFDA"),
                StrokeThickness = 1,
                Padding = 15,

                StrokeShape = new Microsoft.Maui.Controls.Shapes.RoundRectangle
                {
                    CornerRadius = 18
                }
            };

            Grid noteRow = new Grid
            {
                ColumnDefinitions =
                {
                    new ColumnDefinition
                    {
                        Width = GridLength.Star
                    },

                    new ColumnDefinition
                    {
                        Width = GridLength.Auto
                    }
                },

                ColumnSpacing = 10
            };

            Label noteLabel = new Label
            {
                Text = note,
                FontSize = 17,
                TextColor = Color.FromArgb("#26352F"),
                LineBreakMode = LineBreakMode.WordWrap
            };

            Button deleteButton = new Button
            {
                Text = "Delete",
                FontSize = 15,
                BackgroundColor = Color.FromArgb("#E2EBE3"),
                TextColor = Color.FromArgb("#26352F"),
                CornerRadius = 14
            };

            deleteButton.Clicked += (sender, e) =>
            {
                notes.Remove(note);
                SaveNotes(notes);
                LoadNotes();
            };

            Grid.SetColumn(noteLabel, 0);
            Grid.SetColumn(deleteButton, 1);

            noteRow.Children.Add(noteLabel);
            noteRow.Children.Add(deleteButton);

            noteCard.Content = noteRow;

            NotesList.Children.Add(noteCard);
        }
    }

    private List<string> LoadSavedNotes()
    {
        string savedNotes = Preferences.Get("SavedTipNotes", "");

        if (string.IsNullOrWhiteSpace(savedNotes))
        {
            return new List<string>();
        }

        return savedNotes
            .Split("|||")
            .ToList();
    }

    private void SaveNotes(List<string> notes)
    {
        string savedNotes = string.Join("|||", notes);

        Preferences.Set("SavedTipNotes", savedNotes);
    }
}