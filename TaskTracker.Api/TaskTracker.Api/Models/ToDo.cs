namespace TaskTracker.Api.Models
{
    /// <summary>
    /// Named Task from the front-end, ToDo in the back-end. I know ... I know ... 
    /// But since Task already exists in the Threading namespace, it's a bit easier this way.
    /// </summary>
    public class ToDo
    {
        public ToDo(string text, string day, bool reminder)
        {
            Text = text;
            Day = day;
            Reminder = reminder;
        }

        public ToDo(int id, string text, string day, bool reminder)
        {
            Id = id;
            Text = text;
            Day = day;
            Reminder = reminder;
        }

        public int Id { get; set; }
        public string Text { get; set; }
        public string Day { get; set; }
        public bool Reminder { get; set; }
    }
}
