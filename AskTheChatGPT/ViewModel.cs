using System;
using System.Linq;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Data;
using System.Data.OleDb;
using OpenAI_API;

namespace AskTheChatGPT
{
    public class ViewModel : INotifyPropertyChanged
    {


        public RelayCommand SaveQuestion => new RelayCommand(async foo =>
        {
            OpenAIAPI ai = new OpenAIAPI("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");
            var chat = ai.Chat.CreateConversation();

            /// give instruction as System
            chat.AppendUserInput(Question.Question);
            Question.Answer = string.Empty;
            await chat.StreamResponseFromChatbotAsync(res => Question.Answer += res);

            //using (OleDbConnection conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0; Data Source=Questions.accdb"))
            //{
            //    conn.Open();

            //    int id;
            //    using (OleDbDataAdapter ad = new OleDbDataAdapter("SELECT Id FROM Questions ORDER BY Id DESC", conn))
            //    {
            //        DataTable tab = new DataTable();
            //        ad.Fill(tab);
            //        id = tab.Rows.Count < 1 ? 1 : int.Parse(tab.Rows[0][0].ToString());
            //    }

            //    using (OleDbCommand comm = new OleDbCommand($"INSERT INTO Questions VALUES ({id}, {Question.Question})", conn))
            //        comm.ExecuteNonQuery();
            //}
        });

        private QuestionClass _question = new QuestionClass();
        public QuestionClass Question
        {
            get => _question;
            set
            {
                _question = value;
                OnPropertyChanged(nameof(Question));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
    }
}