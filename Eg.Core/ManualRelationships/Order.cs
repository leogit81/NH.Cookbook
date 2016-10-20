using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManualRelationships
{
    public class Order
    {
        public virtual Guid Id { get; protected set; }

        private Iesi.Collections.Generic.ISet<OrderItem> _items;
        public virtual IEnumerable<OrderItem> Items
        {
            get { return _items; }
        }

        public virtual bool AddItem(OrderItem newItem)
        {
            if (newItem != null && _items.Add(newItem))
            {
                newItem.SetOrder(this);
                return true;
            }

            return false;
        }

        public virtual bool RemoveItem(OrderItem itemToRemove)
        {
            if (itemToRemove != null && _items.Remove(itemToRemove))
            {
                itemToRemove.SetOrder(null);
                return true;
            }
            return false;
        }

        public Order()
        {
            _items = new Iesi.Collections.Generic.HashedSet<OrderItem>();
        }
    }
}
