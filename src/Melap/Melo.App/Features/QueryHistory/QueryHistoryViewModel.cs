namespace Melo.App.Features.QueryHistory;

using Bases;

public class QueryHistoryViewModel : BaseViewModel
{
	private readonly IQueryHistoryService queryHistoryService;

	public QueryHistoryViewModel(IServiceProvider services) : base(services)
	{
		queryHistoryService = services.GetRequiredService<IQueryHistoryService>();
	}
}

