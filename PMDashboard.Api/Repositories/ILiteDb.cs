using LiteDB;

namespace PMDashboard.Api.Repositories
{
	public interface ILiteDb
	{
		LiteDatabase Database { get; set; }
	}
}