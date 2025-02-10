using System;
using System.ComponentModel;
using TaskManagementSystem.DAL.Enums;

namespace TaskManagementSystem.DAL.Models
{
    public class Comment : INotifyPropertyChanged
    {
        private string _content;

        public int Id { get; set; }
        public int TaskId { get; set; }
        public Task Task { get; set; }
        public DateTime DateAdded { get; set; } = DateTime.UtcNow;

        public string Content
        {
            get => _content;
            set
            {
                if (_content != value)
                {
                    _content = value;
                    OnPropertyChanged(nameof(Content));
                }
            }
        }

        public CommentType Type { get; set; }
        public DateTime? ReminderDate { get; set; }
        public bool IsEditable { get; set; } = true;

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}