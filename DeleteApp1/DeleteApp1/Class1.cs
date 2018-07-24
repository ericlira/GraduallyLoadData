using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace DeleteApp1
{
	public class MyItem
	{
		public string Text { get; set; }
		public string Image { get; set; }
		public MyItem() { }
		public MyItem(string text, string image) { Text = text; Image = image; }
	}

	public class ExampleData
	{
		private static ExampleViewModel dataViewModel;
		public static ExampleViewModel ViewModel => dataViewModel ?? (dataViewModel = new ExampleViewModel());
		public class ExampleViewModel : ViewModelBase
		{
			public ExampleViewModel()
			{
				ItemAppearingCommand = new Command<object>((object args) => ActionItemAppearing(args));
				MyList.CollectionChanged += NameList_CollectionChanged;
				Count = MyList.Count;
			}

			public ObservableCollection<MyItem> MyList { get; set; } = new ObservableCollection<MyItem>()
			{
				new MyItem("Test1", "buying64.png"),
				new MyItem("Test2", "company64.png"),
				new MyItem("Test3", "exit64.png"),
				new MyItem("Test4", "buying64.png"),
				new MyItem("Test5", "company64.png"),
				new MyItem("Test6", "exit64.png"),
				new MyItem("Test7", "buying64.png"),
				new MyItem("Test8", "company64.png"),
				new MyItem("Test9", "exit64.png"),
				new MyItem("Test10", "buying64.png"),
				new MyItem("Test11", "company64.png"),
				new MyItem("Test12", "exit64.png"),
				new MyItem("Test13", "buying64.png"),
				new MyItem("Test14", "company64.png"),
				new MyItem("Test15", "exit64.png"),
				new MyItem("Test16", "buying64.png"),
				new MyItem("Test17", "company64.png"),
				new MyItem("Test18", "exit64.png"),
			};

			private int count;
			public int Count
			{
				set { SetProperty(ref count, value); }
				get { return count; }
			}

			public ICommand ItemAppearingCommand { get; set; }

			private void ActionItemAppearing(object args)
			{
				if (args is ItemVisibilityEventArgs itemArgs)
				{
					if (itemArgs.Item.Equals(MyList.LastOrDefault()) && MyList.Count < 50)
					{
						MyList.Add(new MyItem($"Test{MyList.Count + 1}", "buying64.png"));
						MyList.Add(new MyItem($"Test{MyList.Count + 1}", "company64.png"));
						MyList.Add(new MyItem($"Test{MyList.Count + 1}", "exit64.png"));
						MyList.Add(new MyItem($"Test{MyList.Count + 1}", "buying64.png"));
						MyList.Add(new MyItem($"Test{MyList.Count + 1}", "company64.png"));
						MyList.Add(new MyItem($"Test{MyList.Count + 1}", "exit64.png"));
					}
				}
			}

			private void NameList_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
			{
				if (e.Action == NotifyCollectionChangedAction.Add || e.Action == NotifyCollectionChangedAction.Remove || e.Action == NotifyCollectionChangedAction.Reset)
				{
					Count = MyList.Count;
				}
			}
		}
	}
}
