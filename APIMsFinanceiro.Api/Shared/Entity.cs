namespace APIMsFinanceiro.API.Shared
{
    public class Entity
    {
        private readonly IList<string> _notifications;

        public Entity()
        {
            _notifications = new List<string>();
        }

        public int Id { get; set; }
        public bool IsValid { get { return Notifications.Count == 0; } }
        public IReadOnlyCollection<string> Notifications => _notifications.ToArray();

        public void AddNotification(string mensagem)
        {
            _notifications.Add(mensagem);
        }
    }
}
