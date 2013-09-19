using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InOutGenerics
{
    class A
    {
        
    }

    class B:A
    {
        
    }

    interface ITestIn<in TIn>
    {
        void Set(TIn v);
    }
    interface ITestOut<out TOut>
    {
        TOut Get();
    }

    class TestOut<TOut> : ITestOut<TOut>
    {
        public TOut Get()
        {
            throw new System.NotImplementedException();
        }
    }

    class TestIn<TIn> : ITestIn<TIn>
    {
        public void Set(TIn v)
        {
        }
    }

    class Test
    {
        void TestInA(ITestIn<A> inst)
        {
            inst.Set(new A());
        }

        void TestOutA(ITestOut<A> inst)
        {
            A a = inst.Get();
        }

        void TestInB(ITestIn<B> inst)
        {
            inst.Set(new B());
        }

        void TestOutB(ITestOut<B> inst)
        {
            B b = inst.Get();
        }
        
        void TestM()
        {
            TestInA(new TestIn<A>());
            TestOutA(new TestOut<A>());

            TestInA(new TestIn<B>());
            TestOutA(new TestOut<B>());

            //----------------------------

            TestOutB(new TestOut<A>());
            TestInB(new TestIn<A>());

            TestOutB(new TestOut<B>());
            TestInB(new TestIn<B>());
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
