using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpStudy01
{
    public class OrderItem
    {
        public string ItemId { get; set; }
        public int Quantity { get; set; }
    }
    public class Customer
    {
        public string Name { get; set; }
        public string Address { get; set; }
    }
    public class Order
    {
        private readonly List<OrderItem> items = new List<OrderItem>();

        public string OrderId { get; set; }
        public Customer Customer { get; set; }
        public List<OrderItem> Items { get { return items; } }
    }

    class _02_객체초기화
    {
        public void Run()
        {
            //초기화 방법 1
            var customer = new Customer();
            customer.Name = "홍길동";
            customer.Address = "UK";

            var item1 = new OrderItem();
            item1.ItemId = "abcd1234";
            item1.Quantity = 1;
            var item2 = new OrderItem();
            item2.ItemId = "가나다라";
            item2.Quantity = 2;

            var order = new Order();
            order.OrderId = "xyz";
            order.Customer = customer;
            order.Items.Add(item1);
            order.Items.Add(item2);


            //초기화방법2, 객체초기화구문과 컬렉션 초기화구문을 이용
            //초기화 방법2가 직관적이고 쉽다.
            var new_order = new Order
            {                
                OrderId = "xyz",                    
                Customer = new Customer { Name="Jon", Address = "UK"},
                Items =
                {
                    new OrderItem { ItemId="abcd1234", Quantity=1},     //컬렉션 초기화
                    new OrderItem { ItemId="가나다라", Quantity=2}
                }
            };

            var o = new
            {
                order.OrderId,          // OrderId = order.OrderId 와 동일함. 추론에 의해 OrderId에 값이 들어간다.
                CustomerName = customer.Name,
                customer.Address,
                item1.ItemId,
                item1.Quantity
            };

            // SomeProperty = val.SomeProperty 이런 코드는
            // val.SomeProperty라고 써도 된다. 컴파일러가 이렇게 추론한다.


        }
    }
}
