namespace Banco
{
    public class ContaCorrente : Conta
    {
        public override void Deposita(double valorDeposito)
        {
            base.Deposita(valorDeposito - 0.05);
        }
    }
}