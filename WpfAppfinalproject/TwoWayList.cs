namespace WpfAppfinalproject
{
    public class TwoWayList
	{
		public TwoWayList()
		{
			first = cursor = last = null;
			count = index = 0;
			search_res = false;
		}
		protected TwoLinkable first, cursor, last;
		protected int count, index;
		protected bool search_res;
		public int Count
		{
			get
			{
				return (count);
			}
		}
		public int Index
		{
			get
			{
				return (index);
			}
		}
		public bool Search_res
		{
			get
			{
				return (search_res);
			}
		}
		public bool empty()
		{
			return (first == null);
		}
		public Figure item()
		{
			return (cursor.Item);
		}
		public void put_left(Figure elem)
		{
			TwoLinkable newitem = new TwoLinkable();
			newitem.Item = elem;
			newitem.Next = cursor;
			if (empty())    //список пуст
			{
				first = cursor = last = newitem;
				index = 1; count = 1;
			}
			else
			{
				if (index == 1)
					first = newitem;
				else
					cursor.Prev.Next = newitem;
				newitem.Prev = cursor.Prev; cursor.Prev = newitem;
				count++; index++;
			}
		}
		public void put_right(Figure elem)
		{
			TwoLinkable newitem = new TwoLinkable();
			newitem.Item = elem;
			newitem.Prev = cursor;
			if (empty())    //список пуст
			{
				first = cursor = last = newitem;
				index = 1; count = 1;
			}
			else
			{
				if (index == count)
					last = newitem;
				else
					cursor.Next.Prev = newitem;

				newitem.Next = cursor.Next; cursor.Next = newitem;
				count++;
			}
		}
		public void remove()
		{
			if (count == 1)
			{
				first = last = cursor = null;
				index = 0;
			}
			else if (index == 1)
			{
				first = cursor.Next;
				cursor.Prev = null;
				cursor = cursor.Next;
			}
			else if (index == count)
			{
				last = cursor.Prev;
				cursor.Next = null;
				cursor = cursor.Prev;
				index--;
			}
			else
			{
				cursor.Prev.Next = cursor.Next;
				cursor.Next.Prev = cursor.Prev;
				cursor = cursor.Next;
			}
			count--;
		}
		public void start()
		{
			cursor = first; index = 1;
		}
		public void finish()
		{
			cursor = last; index = count;
		}
		public void go_prev()
		{
			cursor = cursor.Prev; index--;
		}
		public void go_next()
		{
			cursor = cursor.Next; index++;
		}
		public void go_i(int i)
		{
			if (i > index)
				while (i > index)
				{
					cursor = cursor.Next; index++;
				}
			else if (i < index)
				while (i < index)
				{
					cursor = cursor.Prev; index--;
				}
		}
		public virtual void search_prev(Figure elem)
		{
			bool found = false;
			while (!found && (index != 1))
			{
				cursor = cursor.Prev; index--;
				found = (elem == item());
			}
			search_res = found;
		}
		public virtual void search_next(Figure elem)
		{
			bool found = false;
			while (!found && (index != count))
			{
				cursor = cursor.Next; index++;
				found = (elem == item());
			}
			search_res = found;
		}
	}
}

