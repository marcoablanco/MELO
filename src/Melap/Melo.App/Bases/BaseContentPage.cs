namespace Melo.App.Bases;

using Microsoft.Extensions.Logging;
using ReactiveUI;
using ReactiveUI.Maui;
using ReactiveUI.Primitives.Disposables;

public class BaseContentPage<TViewModel> : ReactiveContentPage<TViewModel>
	where TViewModel : BaseViewModel
{
	private readonly ILogger<BaseContentPage<TViewModel>> logger;

	protected BaseContentPage(IServiceProvider services)
	{
		logger = services.GetRequiredService<ILogger<BaseContentPage<TViewModel>>>();
		ViewModel = services.GetRequiredService<TViewModel>();

		this.WhenActivated(OnActivated);
	}

	public new TViewModel ViewModel
	{
		get => base.ViewModel!;
		set => base.ViewModel = value;
	}

	protected virtual void OnActivated(MultipleDisposable disposables)
	{
	}

	protected override async void OnAppearing()
	{
		try
		{
			base.OnAppearing();
			await ViewModel.OnAppearingAsync();
		}
		catch (Exception e)
		{
			logger.LogError(e, "Error in OnAppearing.");
		}
	}

	protected override async void OnDisappearing()
	{
		try
		{
			base.OnDisappearing();
			await ViewModel.OnDisappearingAsync();
		}
		catch (Exception e)
		{
			logger.LogError(e, "Error in OnDisappearing.");
		}
	}
}

