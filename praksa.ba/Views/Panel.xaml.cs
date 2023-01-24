namespace praksa.ba.Views;

public partial class Panel : Shell
{
	public Panel()
	{
		InitializeComponent();
        Routing.RegisterRoute(nameof(SingleInternship), typeof(SingleInternship));
    }
}