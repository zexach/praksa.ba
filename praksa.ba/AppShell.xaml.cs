﻿using praksa.ba.Views;

namespace praksa.ba;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
        Routing.RegisterRoute(nameof(SingleInternship), typeof(SingleInternship));
    }
}
