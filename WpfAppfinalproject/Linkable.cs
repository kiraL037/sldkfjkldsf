namespace WpfAppfinalproject
{
    public class Linkable
	{
		public Linkable()
		{
			item = null; next = null;
		}
		Figure item;
		Linkable next;
		public Figure Item
		{
			get
			{
				return (item);
			}
			set
			{
				item = value;
			}
		}
		public Linkable Next
		{
			get
			{
				return (next);
			}
			set
			{
				next = value;
			}
		}
	}
	public class TwoLinkable
	{

		public TwoLinkable()
		{
			prev = next = null;
		}
		TwoLinkable prev, next;
		Figure item;
		public Figure Item
		{
			get
			{
				return (item);
			}
			set
			{
				item = value;
			}
		}
		public TwoLinkable Next
		{
			get
			{
				return (next);
			}
			set
			{
				next = value;
			}
		}
		public TwoLinkable Prev
		{
			get
			{
				return (prev);
			}
			set
			{
				prev = value;
			}
		}
	}
}

