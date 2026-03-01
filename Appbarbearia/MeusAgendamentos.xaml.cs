namespace Appbarbearia;

using Appbarbearia.Models;
using SQLite;



public partial class MeusAgendamentos : ContentPage
{
	private Cliente  _clienteLogado;
	public MeusAgendamentos(Cliente cliente)
	{
		InitializeComponent();
		_clienteLogado = cliente;


		CarregarAgendamento();
	}
	private async void CarregarAgendamento()
	{
		var lista = await App.Database.ListarAgendamentoPorCLiente(_clienteLogado.Id);
			{
			AgendamentoCollectionView.ItemsSource = lista;

			
		};
	}
	}