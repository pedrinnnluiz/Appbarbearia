using Appbarbearia.Models;

namespace Appbarbearia
{
    public partial class MainPage : ContentPage
    {
        private Cliente _clienteLogado;

        public MainPage(Cliente cliente)
        {
            InitializeComponent();
            _clienteLogado = cliente;
        }

        private async void ConfirmarAgendamento_Clicked(object sender, EventArgs e)
        {
            
            if (BarbeiroPicker.SelectedIndex == -1)
            {
                await DisplayAlert("Erro", "Selecione ao menos um barbeiro", "Ok");
                return;
            }

            if (ServicoPicker.SelectedIndex == -1)
            {
                await DisplayAlert("Erro", "Selecione ao menos um serviço", "Ok");
                return;
            }


            string barbeiroSelecionado = BarbeiroPicker.SelectedItem.ToString();
            string servicoSelecionado = ServicoPicker.SelectedItem.ToString();
            DateTime dataCompleta = EscolherDataPicker.Date + EscolherHoraPicker.Time;

   
            var agendamento = new Agendamento()
            {
                ClienteID = _clienteLogado.Id,
                Barbeiro = barbeiroSelecionado,
                ServicoSelecionado = servicoSelecionado,
                DataCompleta = dataCompleta
            };

            string resumo = agendamento.GerarResumo();
           
            await DisplayAlert("Resumo do agendamento", resumo, "Confirmar");

            await App.Database.SalvarAgendamento(agendamento);

            await DisplayAlert("Sucesso", "Agendamento realizado!", "Ok");

            await Navigation.PushAsync(new MeusAgendamentos(_clienteLogado));
        }
    }
}