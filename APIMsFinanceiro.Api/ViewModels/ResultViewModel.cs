namespace APIMsFinanceiro.ViewModels
{
    public class ResultViewModel<T>
    {
        
        public ResultViewModel(T data, List<string> errors)
        {
            Data = data;
            Erros = errors;

            if (errors.Count > 0)
                Sucess = false;
        }

        public ResultViewModel(T data)
        {
            Data = data;
            Sucess = true;
        }

        public ResultViewModel(List<string> errors)
        {            
            Erros = errors;
            Sucess = false;
        }

        public ResultViewModel(string error)
        {            
            Erros.Add(error);
            Sucess = false;
        }


        public T Data { get; private set; }
        public List<String> Erros { get; private set; } = new();
        public bool Sucess { get; set; }
    }
}
