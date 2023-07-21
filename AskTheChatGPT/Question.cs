using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace AskTheChatGPT
{
    public class QuestionClass : INotifyPropertyChanged
    {
        private int _questionId, _answerId;
        private string _question, _answer = string.Empty;

        public int QuestionId
        {
            get => _questionId;
            set
            {
                _questionId = value;
                OnPropertyChanged(nameof(QuestionId));
            }
        }

        public int AnswerId
        {
            get => _answerId;
            set
            {
                _answerId = value;
                OnPropertyChanged(nameof(AnswerId));
            }
        }

        public string Question
        {
            get => _question;
            set
            {
                _question = value;
                OnPropertyChanged(nameof(Question));
            }
        }

        public string Answer
        {
            get => _answer;
            set
            {
                _answer = value;
                OnPropertyChanged(nameof(Answer));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
    }
}