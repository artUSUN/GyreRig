namespace Task3
{
    interface ISomeInterface
    {
        void Call();
    }
    struct SomeStruct : ISomeInterface
    {
        public void Call()
        { }
    }
        
    class SomeClass
    {
        public void Run()
        {
            var someStruct = new SomeStruct();
            SomeMethod(someStruct);
        }
        public void SomeMethod<T>(T @interface) where T : ISomeInterface 
        {
            @interface.Call();
        }
    }
}