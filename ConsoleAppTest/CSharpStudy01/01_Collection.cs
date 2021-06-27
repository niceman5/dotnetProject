using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpStudy01
{
    class _01_Collection
    {
        // 타입 매개변수 T를 이용해서 메서드를 선언하고 메서드의 일반 매개변수와 반환 타입으로 활용
        // 이런 방식으로 하면 모든 타입에 대응이 가능함.
        private List<T> CopyAtMost<T>(List<T> input, int maxElements)
        {
            int Count = Math.Min(input.Count, maxElements);
            List<T> ret = new List<T>(Count);       //메서드 본문에서도 타입매개변수를 사용한다.
            for (int i = 0; i < Count; i++)
            {
                ret.Add(input[i]);
            }
            return ret;
        }
        private void PrintType<T>()
        {
            Console.WriteLine($"typeof(T) = {typeof(T)}");
            Console.WriteLine($"typeof(List<T>) = {typeof(List<T>)}");
        }


        public void Run()
        {
            Console.WriteLine("_01_Collection");

            //Array
            //배열을 생성할때 미리 크기를 알아야 한다.
            string[] names = new string[4];
            names[0] = "홍길동1";
            names[1] = "홍길동2";
            names[2] = "홍길동3";
            names[3] = "홍길동4";
            foreach (var name in names)
            {
                Console.WriteLine(name);
            }
            Console.WriteLine("---------------------------------------------------------------------------");

            //ArrayList 배열을 크기를 추적하고 배열을 재할당하는 작업을 수행한다. 
            //문제는 add시 object형으로 저장하기 때문에 필요한 형태가 아닌 형태가 저장되는것을 막을수 없음
            //출력시 object가 string으로 casting되고 있음. 만약 예상과 전혀다른 형태가 들어가면 오류발생
            ArrayList names2 = new ArrayList();
            names2.Add("홍길동1");
            names2.Add("홍길동2");
            names2.Add("홍길동3");
            names2.Add("홍길동4");
            foreach (var name in names2)
            {
                Console.WriteLine(name);
            }
            Console.WriteLine("---------------------------------------------------------------------------");

            //StringCollection은 문자열만 저장가능한 collection으로 잘못된 형이 들어가는건 막아줄수 있음.
            //만약 임의의 타입을 저장하려면 그에 맞는 collection을 계속 만들어 제공해야함 함.
            StringCollection names3 = new StringCollection();
            names3.Add("홍길동1");
            names3.Add("홍길동2");
            names3.Add("홍길동3");
            names3.Add("홍길동4");
            foreach (var name in names3)
            {
                Console.WriteLine(name);
            }

            Console.WriteLine("---------------------------------------------------------------------------");

            //List<T>의 제네릭타입을 이용하면 개선이 가능함. 모든 타입으로 확장이 가능함.
            List<string> names4 = new List<string>();
            names4.Add("홍길동1");
            names4.Add("홍길동2");
            names4.Add("홍길동3");
            names4.Add("홍길동4");
            foreach (var name in names4)
            {
                Console.WriteLine(name);
            }

            Console.WriteLine("---------------------------------------------------------------------------");
            List<int> numbers = new List<int>();
            numbers.Add(5);
            numbers.Add(10);
            numbers.Add(20);
            List<int> firstTwo = CopyAtMost<int>(numbers, 2);   //타입 매개변수로 int를 지정하여 메서드 호출
            Console.WriteLine(firstTwo.Count);
            foreach (var val in firstTwo)
            {
                Console.WriteLine(val);
            }

            /*
             * Tuple<T1, T2> Create<T1, T2>(T1 item, T2 item) 
             * -> new Tuple<int, string>(10, "X")
             * -> Tuple.Create(10, "X") 이런식으로 선언 가능 위의 방식보다 더 간단함.
             * */
            Console.WriteLine("---------------------------------------------------------------------------");
            PrintType<string>();
            PrintType<int>();
        }
    }
}
