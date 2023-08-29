using HR_Management.MVC.Contracts;
using Hanssens.Net;

namespace HR_Management.MVC.Services
{
	public class LocalStrogeService : ILocalStrogeService
	{
		LocalStorage _storage;

        public LocalStrogeService()
        {
            var config = new LocalStorageConfiguration()
			{
				AutoLoad = true,
				AutoSave = true,
				Filename = "HR.LEAVEMGMT"
			};

			_storage = new LocalStorage(config);
        }

        public void ClearStroge(List<string> keys)
		{
			foreach (string key in keys)
			{
				_storage.Remove(key);
			}
		}

		public void SetStrogeValue<T>(string key, T value)
		{
			_storage.Store(key, value);
			_storage.Persist();
		}

		public T GetStrogeValue<T>(string key)
		{
			return _storage.Get<T>(key);
		}

		public bool Exists(string Key)
		{
			return _storage.Exists(Key);
		}

	}
}
