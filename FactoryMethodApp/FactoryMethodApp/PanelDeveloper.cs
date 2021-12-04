namespace FactoryMethodApp
{
    class PanelDeveloper : Developer
    {
        public PanelDeveloper(string n) : base(n){}
        public override House Create()
        {
            return new PanelHouse();
        }
    }
}