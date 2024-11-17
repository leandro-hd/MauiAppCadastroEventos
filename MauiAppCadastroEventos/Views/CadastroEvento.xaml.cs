using MauiAppCadastroEventos.Models;

namespace MauiAppCadastroEventos.Views;

public partial class CadastroEvento : ContentPage
{
    App PropriedadesApp;

    public CadastroEvento()
	{
		InitializeComponent();

        PropriedadesApp = (App)Application.Current;

        dtpck_checkin.MinimumDate = DateTime.Now;
        dtpck_checkin.MaximumDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month + 1, DateTime.Now.Day);

        dtpck_checkout.MinimumDate = dtpck_checkin.Date.AddDays(1);
        dtpck_checkout.MaximumDate = dtpck_checkin.Date.AddMonths(6);
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        try
        {
            Hospedagem h = new Hospedagem
            {
                NomeEvento = txt_nome_evento.Text,
                LocalEvento = txt_local_evento.Text,
                CustoEvento = Convert.ToDouble(txt_custo_evento.Text),
                QntParticipantes = Convert.ToInt32(stp_numero_participantes.Value),
                DataCheckIn = dtpck_checkin.Date,
                DataCheckOut = dtpck_checkout.Date,
            };

            await Navigation.PushAsync(new EventoCadastrado()
            {
                BindingContext = h
            });

        }
        catch (Exception ex)
        {
            await DisplayAlert("Ops", ex.Message, "OK");
        }
    }

    private void dtpck_checkin_DateSelected(object sender, DateChangedEventArgs e)
    {
        DatePicker elemento = sender as DatePicker;

        DateTime data_selecionada_checkin = elemento.Date;

        dtpck_checkout.MinimumDate = data_selecionada_checkin.AddDays(1);
        dtpck_checkout.MaximumDate = data_selecionada_checkin.AddMonths(6);
    }
}