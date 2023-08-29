namespace HR_Management.MVC.Contracts
{
	public interface ILocalStrogeService
	{
		void ClearStroge(List<string> keys);

		bool Exists(string Key);

		T GetStrogeValue<T>(string key);

		void SetStrogeValue<T>(string key, T value);
	}
}
