using Appbarbearia.Models;

namespace Appbarbearia;

public partial class LoginPage : ContentPage
{
    private Cliente _clienteLogado;

    public LoginPage()
    {
        InitializeComponent();
    }

    private async void Login_Clicked(object sender, EventArgs e)
    {
        
        if (string.IsNullOrWhiteSpace(EmailEntry.Text) ||
            string.IsNullOrWhiteSpace(SenhaEntry.Text))
        {
            await DisplayAlert("Erro!", "Digite nos campos indicados", "OK!");
            return;
        }

       
        var cliente = await App.Database.LoginAsync(
            EmailEntry.Text,
            SenhaEntry.Text);

        if (cliente != null)
        {
           
            _clienteLogado = cliente;

            await DisplayAlert("Sucesso", "Bem-Vindo!", "Seguir");

            await Navigation.PushAsync(new MainPage(cliente));
        }
        else
        {
            await DisplayAlert("Erro", "Dados Inválidos", "Ok");
        }
    }

    private async void ExcluirId_Clicked(object sender, EventArgs e)
    {
       
        if (_clienteLogado == null)
        {
            await DisplayAlert("Erro", "Nenhum usuário logado", "Ok");
            return;
        }

        var resultado = await App.Database
            .DeleteUsuarioAsync(_clienteLogado.Id);

        if (resultado > 0)
        {
            await DisplayAlert("Sucesso", "Conta Excluída", "Ok");
        }
        else
        {
            await DisplayAlert("Erro!", "Usuário não encontrado", "Ok");
        }
    }
}