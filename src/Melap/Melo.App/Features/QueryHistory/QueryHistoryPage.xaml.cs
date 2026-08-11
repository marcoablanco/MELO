namespace Melo.App.Features.QueryHistory;

using Bases;

public partial class QueryHistoryPage : BaseContentPage<QueryHistoryViewModel>
{
	public QueryHistoryPage(IServiceProvider services) : base(services)
	{
		InitializeComponent();
	}
}

