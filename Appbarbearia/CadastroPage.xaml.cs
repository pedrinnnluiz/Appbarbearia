using Appbarbearia.Models;

namespace Appbarbearia;

public partial class CadastroPage : ContentPage
{
	public CadastroPage()
	{
		InitializeComponent();
	}

	private async void ConcluirCadastro_Clicked(object sender, EventArgs e)
	{
        var cliente = new Cliente
        {
            Nome = NomeEntry.Text,
            Email = EmailEntry.Text,
            Senha = SenhaEntry.Text
        };
        await App.Database.SalvarClienteAsync(cliente);

        if (string.IsNullOrWhiteSpace(NomeEntry.Text) ||
       string.IsNullOrWhiteSpace(EmailEntry.Text) ||
       string.IsNullOrWhiteSpace(SenhaEntry.Text))
        {
            await DisplayAlert("ERRO", "Preencha todos os campos.", "Ok");
            return;
        }
        await DisplayAlert("Sucesso!", "Seu Cadastro Foi concluído com Sucesso", "ok");
        await Navigation.PushAsync(new MainPage());
    }
    
}
	
