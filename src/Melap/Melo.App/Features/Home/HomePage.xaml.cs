namespace Melo.App.Features.Home;

using Bases;

public partial class HomePage : BaseContentPage<HomeViewModel>
{
	public HomePage(IServiceProvider services) : base(services)
	{
		InitializeComponent();
	}
}

