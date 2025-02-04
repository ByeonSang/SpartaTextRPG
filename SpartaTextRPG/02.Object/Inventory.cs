namespace SpartaTextRPG._02.Object
{
    internal class Inventory<T>
    {
        /// <summary>
        /// _x, _y : 인벤토리의 크기를 지정해줍니다.
        /// </summary>
        /// <param name="_x"></param>
        /// <param name="_y"></param>
        public Inventory(int _x, int _y)
        {
            items = new List<T>();

            x = _x;
            y = _y;
        }

        public T AddItem(T item)
        {
            if (item == null)
                return default(T);

            if (items.Count < x * y)
            {
                items.Add(item);
                return item;
            }
            else
            {
                Console.WriteLine("인벤토리가 꽉 찼습니다.");
                return default(T);
            }
        }

        public T RemoveItem(T item)
        {
            if (item == null)
                return default(T);

            if(items.Count > 0)
            {
                items.Remove(item);
                return item;
            }
            else
            {
                Console.WriteLine("인벤토리에 아이템이 없습니다.");
                return default(T);
            }
        }

        public List<T> GetItems()
        {
            return items;
        }

        List<T> items;

        int x;
        int y;
        public int Width { get => x; }
        public int Height { get => y; }
    }
}
